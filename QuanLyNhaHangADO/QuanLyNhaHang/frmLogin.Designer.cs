﻿namespace QuanLyNhaHang
{
    partial class frmLogin
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.ptbPass = new System.Windows.Forms.PictureBox();
            this.ptbLogin = new System.Windows.Forms.PictureBox();
            this.btnHide = new Guna.UI2.WinForms.Guna2CircleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogin)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DodgerBlue;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(226, 531);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 60);
            this.button2.TabIndex = 18;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(49, 531);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 60);
            this.button1.TabIndex = 17;
            this.button1.Text = "Đăng nhập";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.IndianRed;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 218);
            this.panel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(143, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đăng nhập";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyNhaHang.Properties.Resources.user__1_;
            this.pictureBox1.Location = new System.Drawing.Point(98, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtPass
            // 
            this.txtPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPass.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.txtPass.Location = new System.Drawing.Point(82, 406);
            this.txtPass.Multiline = true;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(319, 58);
            this.txtPass.TabIndex = 16;
            // 
            // txtUser
            // 
            this.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUser.Font = new System.Drawing.Font("Century Gothic", 14F);
            this.txtUser.Location = new System.Drawing.Point(82, 333);
            this.txtUser.Multiline = true;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(319, 46);
            this.txtUser.TabIndex = 14;
            // 
            // ptbPass
            // 
            this.ptbPass.BackgroundImage = global::QuanLyNhaHang.Properties.Resources.padlock;
            this.ptbPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbPass.Location = new System.Drawing.Point(12, 406);
            this.ptbPass.Name = "ptbPass";
            this.ptbPass.Size = new System.Drawing.Size(59, 46);
            this.ptbPass.TabIndex = 15;
            this.ptbPass.TabStop = false;
            // 
            // ptbLogin
            // 
            this.ptbLogin.BackgroundImage = global::QuanLyNhaHang.Properties.Resources.user;
            this.ptbLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbLogin.Location = new System.Drawing.Point(12, 333);
            this.ptbLogin.Name = "ptbLogin";
            this.ptbLogin.Size = new System.Drawing.Size(59, 46);
            this.ptbLogin.TabIndex = 13;
            this.ptbLogin.TabStop = false;
            // 
            // btnHide
            // 
            this.btnHide.BackColor = System.Drawing.Color.Transparent;
            this.btnHide.BorderColor = System.Drawing.Color.Transparent;
            this.btnHide.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHide.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHide.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHide.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHide.FillColor = System.Drawing.Color.Silver;
            this.btnHide.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHide.ForeColor = System.Drawing.Color.White;
            this.btnHide.Image = global::QuanLyNhaHang.Properties.Resources.icons8_hide_100;
            this.btnHide.ImageSize = new System.Drawing.Size(35, 35);
            this.btnHide.Location = new System.Drawing.Point(344, 407);
            this.btnHide.Name = "btnHide";
            this.btnHide.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnHide.Size = new System.Drawing.Size(55, 55);
            this.btnHide.TabIndex = 20;
            this.btnHide.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHide.UseTransparentBackground = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // frmLogin
            // 
            this.ClientSize = new System.Drawing.Size(473, 727);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.ptbPass);
            this.Controls.Add(this.ptbLogin);
            this.Controls.Add(this.txtUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.PictureBox ptbPass;
        private System.Windows.Forms.PictureBox ptbLogin;
        private System.Windows.Forms.TextBox txtUser;
        private Guna.UI2.WinForms.Guna2CircleButton btnHide;
    }
}

