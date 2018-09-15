using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sys3_rocketa_game
{
	public partial class Asteroid : PictureBox
	{
		private const int MinSize = 24;
		private const int MaxSize = 48;
		private Random random;
		public Asteroid()
		{
			random = new Random(DateTime.Now.Millisecond);
			BackColor = Color.Transparent;
		//	BackgroundImage = RotateImageByAngle((Bitmap)Properties.Resources.ResourceManager
		//		.GetObject("asteroid" + random.Next(0, 5)), random.Next(0, 360)); // random rotate
			BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject("asteroid" + random.Next(0, 4));
			BackgroundImageLayout = ImageLayout.Stretch;
			Size = new Size(MinSize, MinSize);
			Tag = "asteroid";
			randomize();

			InitializeComponent();
		}
		public Asteroid randomize()
		{
			int side = random.Next(MinSize, MaxSize);
			Size = new Size(side, side);
			
			return this;
		}
		private Bitmap RotateImageByAngle(Image oldBitmap, float angle)
		{
			var newBitmap = new Bitmap(oldBitmap.Width, oldBitmap.Height);
			newBitmap.SetResolution(oldBitmap.HorizontalResolution, oldBitmap.VerticalResolution);
			var graphics = Graphics.FromImage(newBitmap);
			graphics.TranslateTransform((float)oldBitmap.Width / 2, (float)oldBitmap.Height / 2);
			graphics.RotateTransform(angle);
			graphics.TranslateTransform(-(float)oldBitmap.Width / 2, -(float)oldBitmap.Height / 2);
			graphics.DrawImage(oldBitmap, new Point(0, 0));
			return newBitmap;
		}
	}
}
