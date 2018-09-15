namespace sys3_rocketa_game
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.pictureBoxBackground = new System.Windows.Forms.PictureBox();
			this.pictureBoxFire = new System.Windows.Forms.PictureBox();
			this.rocketModel = new System.Windows.Forms.PictureBox();
			this.labelCounter = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxFire)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.rocketModel)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBoxBackground
			// 
			this.pictureBoxBackground.BackgroundImage = global::sys3_rocketa_game.Properties.Resources.background1;
			this.pictureBoxBackground.Location = new System.Drawing.Point(-7, -2367);
			this.pictureBoxBackground.Name = "pictureBoxBackground";
			this.pictureBoxBackground.Size = new System.Drawing.Size(500, 3000);
			this.pictureBoxBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBoxBackground.TabIndex = 3;
			this.pictureBoxBackground.TabStop = false;
			// 
			// pictureBoxFire
			// 
			this.pictureBoxFire.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxFire.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFire.Image")));
			this.pictureBoxFire.Location = new System.Drawing.Point(68, 372);
			this.pictureBoxFire.Name = "pictureBoxFire";
			this.pictureBoxFire.Size = new System.Drawing.Size(24, 24);
			this.pictureBoxFire.TabIndex = 1;
			this.pictureBoxFire.TabStop = false;
			this.pictureBoxFire.Visible = false;
			// 
			// rocketModel
			// 
			this.rocketModel.BackColor = System.Drawing.Color.Transparent;
			this.rocketModel.Image = ((System.Drawing.Image)(resources.GetObject("rocketModel.Image")));
			this.rocketModel.Location = new System.Drawing.Point(57, 332);
			this.rocketModel.Name = "rocketModel";
			this.rocketModel.Size = new System.Drawing.Size(45, 45);
			this.rocketModel.TabIndex = 0;
			this.rocketModel.TabStop = false;
			// 
			// labelCounter
			// 
			this.labelCounter.AutoSize = true;
			this.labelCounter.BackColor = System.Drawing.Color.Black;
			this.labelCounter.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCounter.ForeColor = System.Drawing.Color.Chartreuse;
			this.labelCounter.Location = new System.Drawing.Point(421, 433);
			this.labelCounter.Name = "labelCounter";
			this.labelCounter.Size = new System.Drawing.Size(68, 26);
			this.labelCounter.TabIndex = 4;
			this.labelCounter.Text = "1943";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(482, 455);
			this.Controls.Add(this.labelCounter);
			this.Controls.Add(this.pictureBoxBackground);
			this.Controls.Add(this.pictureBoxFire);
			this.Controls.Add(this.rocketModel);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Text = "Rocketa VS Steroids";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxFire)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.rocketModel)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.PictureBox pictureBoxBackground;
		private System.Windows.Forms.PictureBox pictureBoxFire;
		private System.Windows.Forms.PictureBox rocketModel;
		private System.Windows.Forms.Label labelCounter;
	}
}

