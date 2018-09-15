using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sys3_rocketa_game
{
	public partial class MainForm : Form
	{
		Rocket player;
		int Level_Lenght = 2000;
		bool GameInProcess;
		bool ForceRestart;
		DateTime startTime;
		enum Difficulty
		{
			HARD = 2,
			MEDIUM = 5,
			EASY = 10
		}
		Difficulty difficulty = Difficulty.HARD; // 4 - easy, 3 - medium, 2 - hard
		struct Moving
		{
			public bool left, up, right, down;
		}
		Moving moving;

		public MainForm()
		{
			InitializeComponent();
			CenterToScreen();
			player = new Rocket();
			Load += Form1_Load;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Start();
		}

		private void Start()
		{
			ForceRestart = false;
			startTime = DateTime.Now;

			// background position
			pictureBoxBackground.Size = new Size(ClientSize.Width, Level_Lenght);
			pictureBoxBackground.Location = new Point(0, Size.Height - Level_Lenght);
			pictureBoxBackground.Paint += PictureBoxBackground_Paint;

			// adding controls to front
			objectSpawnRandomizer();
			//pictureBoxBackground.Controls.Add(new Asteroid() { Location = new Point(80, pictureBoxBackground.Height - ClientSize.Height) });
			//pictureBoxBackground.Controls.Add(new Asteroid() { Location = new Point(140, pictureBoxBackground.Height - ClientSize.Height) });
			//pictureBoxBackground.Controls.Add(new Asteroid() { Location = new Point(260, pictureBoxBackground.Height - ClientSize.Height) });
			//pictureBoxBackground.Controls.Add(new Asteroid() { Location = new Point(190, pictureBoxBackground.Height - ClientSize.Height) });

			pictureBoxBackground.Controls.Add(player);

			player.Left = ClientSize.Width / 2 - player.Width / 2;
			player.Top = pictureBoxBackground.Height - 114;

			Graphics graphics = pictureBoxBackground.CreateGraphics();
			graphics.DrawLine(new Pen(Brushes.Red, 4), player.Location, new Point(player.Location.X+300, player.Location.Y+300));
			

			GameInProcess = true;

			// check collisions timer
			Task task = Task.Run(() => checkCollisions());
			
			// controls
			KeyDown += Form1_KeyDown;
			KeyUp += Form1_KeyUp;

			// controls timer
			System.Windows.Forms.Timer controlsTimer = new System.Windows.Forms.Timer();
			controlsTimer.Tick += controlsTimerTick;
			controlsTimer.Interval = 5;
			controlsTimer.Start();

			// level movement timer
			System.Windows.Forms.Timer levelTimer = new System.Windows.Forms.Timer();
			levelTimer.Tick += levelTimerTick; ;
			levelTimer.Interval = 50;
			levelTimer.Start();
		}

		private void PictureBoxBackground_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
			TextRenderer.DrawText(e.Graphics, "Hello World", new Font("Microsoft Sans Serif", 16F, FontStyle.Bold), new Point(ClientSize.Width / 3, ClientSize.Height / 3), Color.White);
		}

		private void controlsTimerTick(object sender, EventArgs e)
		{
			if (GameInProcess == false)
				return;

			doMovement();
		}

		private void levelTimerTick(object sender, EventArgs e)
		{
			if (ForceRestart)
				ResetForm();
			if (GameInProcess == false)
				return;

			if (pictureBoxBackground.Location.Y < 0)
				pictureBoxBackground.Top = moving.up ? pictureBoxBackground.Top + 3 : pictureBoxBackground.Top + 1;

			player.Top = moving.up ? player.Top - 3 : player.Top - 1;
			labelCounter.Text = $"{player.Top}";
			if (player.Top <= 0)
			{
				GameInProcess = false;
				MessageBox.Show($"You've finished level 1 in {(DateTime.Now - startTime)}", "Congratiolations!");
				ForceRestart = true;
			}
		}

		void checkCollisions()
		{
			const int refresh_time = 100;
			while(GameInProcess) // TODO
			{
				if(pictureBoxBackground.Controls.Cast<Control>()
					.Where(c => c is Asteroid)
					.Where(c => AABBvsAABB(c, player))
					.FirstOrDefault() != null)
				{
					GameInProcess = false;
					if (MessageBox.Show("Loser?!!!", "Loser!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.No)
					{
						ForceRestart = true;
					}
					else
						Invoke(new Action(() => Close()));
					break;
				}
				Thread.Sleep(refresh_time);
			}
		}

		bool AABBvsAABB(Control a, Control b)
		{
			Point aMin = a.Location;
			Point aMax = new Point(a.Location.X + a.Width, a.Location.Y + a.Height);
			Point bMin = (b is Rocket) ? player.Location : b.Location;
			Point bMax = (b is Rocket) ? new Point(player.Location.X + player.rSize.Width, player.Location.Y + player.rSize.Height) :
				new Point(b.Location.X + b.Width, b.Location.Y + b.Height);

			if (aMax.X < bMin.X || aMin.X > bMax.X) return false;
			if (aMax.Y < bMin.Y || aMin.Y > bMax.Y) return false;
			
			return true;
		}

		void doMovement()
		{
			if (moving.left) player.MoveTo.Left();
			//if (moving.up) player.MoveTo.Up();
			if (moving.right) player.MoveTo.Right();
			//if (moving.down) player.MoveTo.Down();
		}
		
		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Left:	moving.left = true; break;
				case Keys.Up:	moving.up = true;	break;
				case Keys.Right: moving.right = true; break;
				case Keys.Down: moving.down = true; break;
			}
		}
		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Left: moving.left = false; break;
				case Keys.Up: moving.up = false; break;
				case Keys.Right: moving.right = false; break;
				case Keys.Down: moving.down = false; break;
			}
		}

		void objectSpawnRandomizer()
		{
			int curPosY = ClientSize.Height;
			Control obj;
			Random rand = new Random();
			Size tmpSz;
			
			while(curPosY < pictureBoxBackground.Height - ClientSize.Height)
			{
				obj = new Asteroid();
				obj.Location = new Point(rand.Next(0, pictureBoxBackground.Width-obj.Width),
										(curPosY + rand.Next(-obj.Height, obj.Height)));
				tmpSz = obj.Size;
				obj.Size = new Size(obj.Width * (int)difficulty, obj.Height * (int)difficulty);

				if (pictureBoxBackground.Controls.Cast<Control>()
					.Where(c => c is Asteroid)
					.Where(c => AABBvsAABB(c, obj))
					.FirstOrDefault() != null)
				{
					obj.Dispose();
				}
				else
				{
					obj.Size = tmpSz;
					pictureBoxBackground.Controls.Add(obj);
				}
				curPosY += 10;
			}
			
		}

		void ResetForm()
		{
			pictureBoxBackground.Controls.Clear();
			moving.up = moving.down = moving.left = moving.right = false;
			Start();
		}
	}
}
