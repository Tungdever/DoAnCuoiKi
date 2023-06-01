namespace QuanLyNhaHang
{
    partial class ucClock
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ptbClock = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2TileButton1 = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptbClock)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbClock
            // 
            this.ptbClock.BackColor = System.Drawing.Color.Transparent;
            this.ptbClock.Image = global::QuanLyNhaHang.Properties.Resources.CLOCK1;
            this.ptbClock.ImageRotate = 0F;
            this.ptbClock.Location = new System.Drawing.Point(40, 15);
            this.ptbClock.Name = "ptbClock";
            this.ptbClock.Size = new System.Drawing.Size(250, 250);
            this.ptbClock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbClock.TabIndex = 0;
            this.ptbClock.TabStop = false;
            this.ptbClock.UseTransparentBackground = true;
            // 
            // guna2TileButton1
            // 
            this.guna2TileButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2TileButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2TileButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2TileButton1.FillColor = System.Drawing.Color.Transparent;
            this.guna2TileButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TileButton1.ForeColor = System.Drawing.Color.Transparent;
            this.guna2TileButton1.Location = new System.Drawing.Point(287, 141);
            this.guna2TileButton1.Name = "guna2TileButton1";
            this.guna2TileButton1.Size = new System.Drawing.Size(27, 27);
            this.guna2TileButton1.TabIndex = 1;
            this.guna2TileButton1.Text = "guna2TileButton1";
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(200, 297);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(180, 45);
            this.guna2Button1.TabIndex = 2;
            this.guna2Button1.Text = "guna2Button1";
            // 
            // ucClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.ptbClock);
            this.Controls.Add(this.guna2TileButton1);
            this.Name = "ucClock";
            this.Size = new System.Drawing.Size(346, 342);
            this.Load += new System.EventHandler(this.ucClock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbClock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox ptbClock;
        private Guna.UI2.WinForms.Guna2TileButton guna2TileButton1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}
