using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sys3_rocketa_game
{
	class Rocket : PictureBox
	{
		public Movement MoveTo { get; }
		PictureBox backFire;
		public Size rSize { get; } // real rocket size
		public Rocket()
		{
			BackColor = Color.Transparent;
			BackgroundImage = Properties.Resources.rocket;
			BackgroundImageLayout = ImageLayout.None;
			Size = new Size(Properties.Resources.rocket.Width, Properties.Resources.rocket.Height+ Properties.Resources.fire.Height);
			rSize = new Size(Properties.Resources.rocket.Width, Properties.Resources.rocket.Height);

			backFire = new PictureBox();
			backFire.BackColor = Color.Transparent;
			backFire.BackgroundImage = Properties.Resources.fire;
			backFire.Size = Properties.Resources.fire.Size;
			backFire.Visible = false;
			this.Controls.Add(backFire);
			backFire.Location = new Point(Properties.Resources.rocket.Width / 2 - backFire.Width / 2, Properties.Resources.rocket.Height-3);

			MoveTo = new Movement(this);
			
		}

		public void toggleBackFire()
		{
			backFire.Visible = !backFire.Visible;
		}

		public Rocket(Control rocketModel, Control rocketFire)
		{
			MoveTo = new Movement(rocketModel);
		}
	}
	class Movement
	{
		public int xStepPixels = 3;
		public int yStepPixels = 2;
		Control rocketModel;
		public Movement(Control rocketModel)
		{
			this.rocketModel = rocketModel;
		}
		void moveX(int value)
		{
			int newPosition = rocketModel.Left + value;
			if (newPosition > 0 && newPosition < rocketModel.Parent.Width - rocketModel.Width)
				rocketModel.Left = newPosition;
		}
		public void Left() => moveX(-xStepPixels);
		public void Right() => moveX(xStepPixels);

		void moveY(int value)
		{
			int absolutePositionOnForm = rocketModel.FindForm()
				.PointToClient(rocketModel.Parent.PointToScreen(rocketModel.Location)).Y + value;
			//Point parentPos = rocketModel.Parent.Location;
			//int newPosition = rocketModel.Top + value;
			if (absolutePositionOnForm > 0 && absolutePositionOnForm < rocketModel.FindForm().ClientSize.Height - rocketModel.Height/2)
				rocketModel.Top += value;
		}
		public void Up() => moveY(-yStepPixels);
		public void Down() => moveY(yStepPixels);
	}
}
