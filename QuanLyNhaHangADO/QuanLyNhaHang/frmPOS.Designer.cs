﻿namespace QuanLyNhaHang
{
    partial class frmPOS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvPOS = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dgvMaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvpCatID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvDel = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlProduct = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlCategory = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblWaiter = new System.Windows.Forms.Label();
            this.lblTable = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.PtbExit = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnDinIn = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnTakeAway = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnDelivery = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnKOT = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnBillList = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnHold = new Guna.UI2.WinForms.Guna2TileButton();
            this.btnNew = new Guna.UI2.WinForms.Guna2TileButton();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtSearchProduct = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOS)).BeginInit();
            this.pnlCategory.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PtbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(1689, 29);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(68, 38);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "0.00";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1576, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "TOTAL";
            // 
            // dgvPOS
            // 
            this.dgvPOS.AllowUserToAddRows = false;
            this.dgvPOS.AllowUserToDeleteRows = false;
            this.dgvPOS.AllowUserToResizeColumns = false;
            this.dgvPOS.AllowUserToResizeRows = false;
            dataGridViewCellStyle31.BackColor = System.Drawing.Color.White;
            this.dgvPOS.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle31;
            this.dgvPOS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle32;
            this.dgvPOS.ColumnHeadersHeight = 40;
            this.dgvPOS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvPOS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvMaSP,
            this.dgvTenSP,
            this.dgvpCatID,
            this.dgvQty,
            this.dgvPrice,
            this.dgvAmount,
            this.dgvEdit,
            this.dgvDel});
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle33.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(241)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPOS.DefaultCellStyle = dataGridViewCellStyle33;
            this.dgvPOS.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPOS.Location = new System.Drawing.Point(1111, 117);
            this.dgvPOS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvPOS.Name = "dgvPOS";
            this.dgvPOS.ReadOnly = true;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle34.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOS.RowHeadersDefaultCellStyle = dataGridViewCellStyle34;
            this.dgvPOS.RowHeadersVisible = false;
            this.dgvPOS.RowHeadersWidth = 51;
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.Color.IndianRed;
            this.dgvPOS.RowsDefaultCellStyle = dataGridViewCellStyle35;
            this.dgvPOS.RowTemplate.Height = 35;
            this.dgvPOS.Size = new System.Drawing.Size(674, 748);
            this.dgvPOS.TabIndex = 17;
            this.dgvPOS.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPOS.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvPOS.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvPOS.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvPOS.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvPOS.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvPOS.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPOS.ThemeStyle.HeaderStyle.BackColor = System.Drawing.SystemColors.Control;
            this.dgvPOS.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPOS.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPOS.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPOS.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvPOS.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvPOS.ThemeStyle.ReadOnly = true;
            this.dgvPOS.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPOS.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPOS.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPOS.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvPOS.ThemeStyle.RowsStyle.Height = 35;
            this.dgvPOS.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvPOS.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // dgvMaSP
            // 
            this.dgvMaSP.DataPropertyName = "MaSP";
            this.dgvMaSP.HeaderText = "Product ID";
            this.dgvMaSP.MinimumWidth = 6;
            this.dgvMaSP.Name = "dgvMaSP";
            this.dgvMaSP.ReadOnly = true;
            this.dgvMaSP.Visible = false;
            // 
            // dgvTenSP
            // 
            this.dgvTenSP.DataPropertyName = "TenSP";
            this.dgvTenSP.HeaderText = "Product Name";
            this.dgvTenSP.MinimumWidth = 6;
            this.dgvTenSP.Name = "dgvTenSP";
            this.dgvTenSP.ReadOnly = true;
            // 
            // dgvpCatID
            // 
            this.dgvpCatID.DataPropertyName = "MaLoaiSP";
            this.dgvpCatID.HeaderText = "Category ID";
            this.dgvpCatID.MinimumWidth = 6;
            this.dgvpCatID.Name = "dgvpCatID";
            this.dgvpCatID.ReadOnly = true;
            this.dgvpCatID.Visible = false;
            // 
            // dgvQty
            // 
            this.dgvQty.HeaderText = "Qty";
            this.dgvQty.MinimumWidth = 8;
            this.dgvQty.Name = "dgvQty";
            this.dgvQty.ReadOnly = true;
            // 
            // dgvPrice
            // 
            this.dgvPrice.DataPropertyName = "GiaSP";
            this.dgvPrice.HeaderText = "Price";
            this.dgvPrice.MinimumWidth = 6;
            this.dgvPrice.Name = "dgvPrice";
            this.dgvPrice.ReadOnly = true;
            // 
            // dgvAmount
            // 
            this.dgvAmount.HeaderText = "Amount";
            this.dgvAmount.MinimumWidth = 8;
            this.dgvAmount.Name = "dgvAmount";
            this.dgvAmount.ReadOnly = true;
            // 
            // dgvEdit
            // 
            this.dgvEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvEdit.FillWeight = 50F;
            this.dgvEdit.HeaderText = "";
            this.dgvEdit.Image = global::QuanLyNhaHang.Properties.Resources.edit__1_;
            this.dgvEdit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvEdit.MinimumWidth = 50;
            this.dgvEdit.Name = "dgvEdit";
            this.dgvEdit.ReadOnly = true;
            this.dgvEdit.Width = 50;
            // 
            // dgvDel
            // 
            this.dgvDel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvDel.FillWeight = 50F;
            this.dgvDel.HeaderText = "";
            this.dgvDel.Image = global::QuanLyNhaHang.Properties.Resources.delete__1_;
            this.dgvDel.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvDel.MinimumWidth = 50;
            this.dgvDel.Name = "dgvDel";
            this.dgvDel.ReadOnly = true;
            this.dgvDel.Width = 50;
            // 
            // pnlProduct
            // 
            this.pnlProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProduct.AutoScroll = true;
            this.pnlProduct.Location = new System.Drawing.Point(182, 183);
            this.pnlProduct.Name = "pnlProduct";
            this.pnlProduct.Size = new System.Drawing.Size(923, 682);
            this.pnlProduct.TabIndex = 15;
            // 
            // pnlCategory
            // 
            this.pnlCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlCategory.Controls.Add(this.guna2Button1);
            this.pnlCategory.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlCategory.Location = new System.Drawing.Point(3, 186);
            this.pnlCategory.Name = "pnlCategory";
            this.pnlCategory.Size = new System.Drawing.Size(180, 679);
            this.pnlCategory.TabIndex = 16;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(3, 3);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(180, 45);
            this.guna2Button1.TabIndex = 0;
            this.guna2Button1.Text = "guna2Button1";
            this.guna2Button1.UseTransparentBackground = true;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.lblTotal);
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2Panel2.Location = new System.Drawing.Point(0, 861);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1785, 83);
            this.guna2Panel2.TabIndex = 14;
            // 
            // lblWaiter
            // 
            this.lblWaiter.AutoSize = true;
            this.lblWaiter.BackColor = System.Drawing.Color.Transparent;
            this.lblWaiter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaiter.ForeColor = System.Drawing.Color.White;
            this.lblWaiter.Location = new System.Drawing.Point(1111, 86);
            this.lblWaiter.Name = "lblWaiter";
            this.lblWaiter.Size = new System.Drawing.Size(82, 32);
            this.lblWaiter.TabIndex = 4;
            this.lblWaiter.Text = "Waiter";
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.BackColor = System.Drawing.Color.Transparent;
            this.lblTable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTable.ForeColor = System.Drawing.Color.White;
            this.lblTable.Location = new System.Drawing.Point(1111, 9);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(69, 32);
            this.lblTable.TabIndex = 3;
            this.lblTable.Text = "Table";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(96, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "POS";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.PtbExit);
            this.guna2Panel1.Controls.Add(this.lblWaiter);
            this.guna2Panel1.Controls.Add(this.lblTable);
            this.guna2Panel1.Controls.Add(this.btnDinIn);
            this.guna2Panel1.Controls.Add(this.btnTakeAway);
            this.guna2Panel1.Controls.Add(this.btnDelivery);
            this.guna2Panel1.Controls.Add(this.btnKOT);
            this.guna2Panel1.Controls.Add(this.btnBillList);
            this.guna2Panel1.Controls.Add(this.btnHold);
            this.guna2Panel1.Controls.Add(this.btnNew);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1785, 121);
            this.guna2Panel1.TabIndex = 13;
            // 
            // PtbExit
            // 
            this.PtbExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PtbExit.BackColor = System.Drawing.Color.Transparent;
            this.PtbExit.BorderRadius = 10;
            this.PtbExit.FillColor = System.Drawing.Color.Transparent;
            this.PtbExit.Image = global::QuanLyNhaHang.Properties.Resources.icons8_shutdown_96;
            this.PtbExit.ImageRotate = 0F;
            this.PtbExit.Location = new System.Drawing.Point(1647, 0);
            this.PtbExit.Name = "PtbExit";
            this.PtbExit.Size = new System.Drawing.Size(96, 96);
            this.PtbExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PtbExit.TabIndex = 5;
            this.PtbExit.TabStop = false;
            this.PtbExit.UseTransparentBackground = true;
            this.PtbExit.Click += new System.EventHandler(this.PtbExit_Click);
            // 
            // btnDinIn
            // 
            this.btnDinIn.BackColor = System.Drawing.Color.Transparent;
            this.btnDinIn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(85)))), ((int)(((byte)(126)))));
            this.btnDinIn.BorderRadius = 16;
            this.btnDinIn.BorderThickness = 4;
            this.btnDinIn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnDinIn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDinIn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDinIn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDinIn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDinIn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(85)))), ((int)(((byte)(126)))));
            this.btnDinIn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDinIn.ForeColor = System.Drawing.Color.White;
            this.btnDinIn.Image = global::QuanLyNhaHang.Properties.Resources.icons8_restaurant_din_in;
            this.btnDinIn.ImageSize = new System.Drawing.Size(60, 60);
            this.btnDinIn.Location = new System.Drawing.Point(989, 9);
            this.btnDinIn.Name = "btnDinIn";
            this.btnDinIn.Size = new System.Drawing.Size(116, 112);
            this.btnDinIn.TabIndex = 2;
            this.btnDinIn.Text = "Din in";
            this.btnDinIn.UseTransparentBackground = true;
            this.btnDinIn.Click += new System.EventHandler(this.btnDinIn_Click);
            // 
            // btnTakeAway
            // 
            this.btnTakeAway.BackColor = System.Drawing.Color.Transparent;
            this.btnTakeAway.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(85)))), ((int)(((byte)(126)))));
            this.btnTakeAway.BorderRadius = 16;
            this.btnTakeAway.BorderThickness = 4;
            this.btnTakeAway.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnTakeAway.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTakeAway.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTakeAway.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTakeAway.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTakeAway.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(85)))), ((int)(((byte)(126)))));
            this.btnTakeAway.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTakeAway.ForeColor = System.Drawing.Color.White;
            this.btnTakeAway.Image = global::QuanLyNhaHang.Properties.Resources.icons8_take_away_food_100;
            this.btnTakeAway.ImageSize = new System.Drawing.Size(60, 60);
            this.btnTakeAway.Location = new System.Drawing.Point(856, 6);
            this.btnTakeAway.Name = "btnTakeAway";
            this.btnTakeAway.Size = new System.Drawing.Size(116, 115);
            this.btnTakeAway.TabIndex = 2;
            this.btnTakeAway.Text = "Take away";
            this.btnTakeAway.UseTransparentBackground = true;
            this.btnTakeAway.Click += new System.EventHandler(this.btnTakeAway_Click);
            // 
            // btnDelivery
            // 
            this.btnDelivery.BackColor = System.Drawing.Color.Transparent;
            this.btnDelivery.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(85)))), ((int)(((byte)(126)))));
            this.btnDelivery.BorderRadius = 16;
            this.btnDelivery.BorderThickness = 4;
            this.btnDelivery.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnDelivery.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDelivery.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDelivery.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDelivery.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDelivery.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(85)))), ((int)(((byte)(126)))));
            this.btnDelivery.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelivery.ForeColor = System.Drawing.Color.White;
            this.btnDelivery.Image = global::QuanLyNhaHang.Properties.Resources.icons8_motorcycle_delivery_100;
            this.btnDelivery.ImageSize = new System.Drawing.Size(60, 60);
            this.btnDelivery.Location = new System.Drawing.Point(723, 6);
            this.btnDelivery.Name = "btnDelivery";
            this.btnDelivery.Size = new System.Drawing.Size(116, 115);
            this.btnDelivery.TabIndex = 2;
            this.btnDelivery.Text = "Delivery";
            this.btnDelivery.UseTransparentBackground = true;
            this.btnDelivery.Click += new System.EventHandler(this.btnDelivery_Click);
            // 
            // btnKOT
            // 
            this.btnKOT.BackColor = System.Drawing.Color.Transparent;
            this.btnKOT.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(85)))), ((int)(((byte)(126)))));
            this.btnKOT.BorderRadius = 16;
            this.btnKOT.BorderThickness = 4;
            this.btnKOT.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnKOT.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKOT.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKOT.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKOT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKOT.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(85)))), ((int)(((byte)(126)))));
            this.btnKOT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnKOT.ForeColor = System.Drawing.Color.White;
            this.btnKOT.Image = global::QuanLyNhaHang.Properties.Resources.icons8_KOT_64;
            this.btnKOT.ImageSize = new System.Drawing.Size(60, 60);
            this.btnKOT.Location = new System.Drawing.Point(592, 5);
            this.btnKOT.Name = "btnKOT";
            this.btnKOT.Size = new System.Drawing.Size(116, 115);
            this.btnKOT.TabIndex = 2;
            this.btnKOT.Text = "KOT";
            this.btnKOT.UseTransparentBackground = true;
            this.btnKOT.Click += new System.EventHandler(this.btnKOT_Click);
            // 
            // btnBillList
            // 
            this.btnBillList.BackColor = System.Drawing.Color.Transparent;
            this.btnBillList.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(85)))), ((int)(((byte)(126)))));
            this.btnBillList.BorderRadius = 16;
            this.btnBillList.BorderThickness = 4;
            this.btnBillList.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnBillList.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBillList.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBillList.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBillList.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBillList.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(85)))), ((int)(((byte)(126)))));
            this.btnBillList.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBillList.ForeColor = System.Drawing.Color.White;
            this.btnBillList.Image = global::QuanLyNhaHang.Properties.Resources.point_of_sale__1_;
            this.btnBillList.ImageSize = new System.Drawing.Size(60, 60);
            this.btnBillList.Location = new System.Drawing.Point(449, 6);
            this.btnBillList.Name = "btnBillList";
            this.btnBillList.Size = new System.Drawing.Size(116, 115);
            this.btnBillList.TabIndex = 2;
            this.btnBillList.Text = "Bill List";
            this.btnBillList.UseTransparentBackground = true;
            this.btnBillList.Click += new System.EventHandler(this.btnBillList_Click);
            // 
            // btnHold
            // 
            this.btnHold.BackColor = System.Drawing.Color.Transparent;
            this.btnHold.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(85)))), ((int)(((byte)(126)))));
            this.btnHold.BorderRadius = 16;
            this.btnHold.BorderThickness = 4;
            this.btnHold.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnHold.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHold.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHold.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHold.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHold.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(85)))), ((int)(((byte)(126)))));
            this.btnHold.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHold.ForeColor = System.Drawing.Color.White;
            this.btnHold.Image = global::QuanLyNhaHang.Properties.Resources.icons8_hand_100;
            this.btnHold.ImageSize = new System.Drawing.Size(60, 60);
            this.btnHold.Location = new System.Drawing.Point(316, 6);
            this.btnHold.Name = "btnHold";
            this.btnHold.Size = new System.Drawing.Size(116, 115);
            this.btnHold.TabIndex = 2;
            this.btnHold.Text = "Hold";
            this.btnHold.UseTransparentBackground = true;
            this.btnHold.Click += new System.EventHandler(this.btnHold_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Transparent;
            this.btnNew.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(85)))), ((int)(((byte)(126)))));
            this.btnNew.BorderRadius = 16;
            this.btnNew.BorderThickness = 4;
            this.btnNew.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnNew.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNew.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNew.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNew.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNew.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(85)))), ((int)(((byte)(126)))));
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Image = global::QuanLyNhaHang.Properties.Resources.icons8_new_ticket_80;
            this.btnNew.ImageSize = new System.Drawing.Size(60, 60);
            this.btnNew.Location = new System.Drawing.Point(182, 9);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(116, 112);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "New";
            this.btnNew.UseTransparentBackground = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.BorderRadius = 10;
            this.guna2PictureBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::QuanLyNhaHang.Properties.Resources.icons8_restaurant;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(3, 3);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(102, 103);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.FillWeight = 50F;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::QuanLyNhaHang.Properties.Resources.edit__1_;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.MinimumWidth = 50;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn2.FillWeight = 50F;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::QuanLyNhaHang.Properties.Resources.delete__1_;
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.MinimumWidth = 50;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Width = 50;
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchProduct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchProduct.DefaultText = "";
            this.txtSearchProduct.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchProduct.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchProduct.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchProduct.IconLeft = global::QuanLyNhaHang.Properties.Resources.magnifying_glass;
            this.txtSearchProduct.IconLeftSize = new System.Drawing.Size(35, 35);
            this.txtSearchProduct.Location = new System.Drawing.Point(182, 128);
            this.txtSearchProduct.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.PasswordChar = '\0';
            this.txtSearchProduct.PlaceholderText = "";
            this.txtSearchProduct.SelectedText = "";
            this.txtSearchProduct.Size = new System.Drawing.Size(727, 47);
            this.txtSearchProduct.TabIndex = 12;
            this.txtSearchProduct.TextChanged += new System.EventHandler(this.txtSearchProduct_TextChanged);
            // 
            // frmPOS
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1785, 944);
            this.Controls.Add(this.txtSearchProduct);
            this.Controls.Add(this.dgvPOS);
            this.Controls.Add(this.pnlProduct);
            this.Controls.Add(this.pnlCategory);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPOS";
            this.Text = "frmPOS";
            this.Load += new System.EventHandler(this.frmPOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOS)).EndInit();
            this.pnlCategory.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PtbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtSearchProduct;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvMaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvpCatID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAmount;
        private System.Windows.Forms.DataGridViewImageColumn dgvEdit;
        private System.Windows.Forms.DataGridViewImageColumn dgvDel;
        private Guna.UI2.WinForms.Guna2TileButton btnDinIn;
        private Guna.UI2.WinForms.Guna2TileButton btnTakeAway;
        private Guna.UI2.WinForms.Guna2TileButton btnDelivery;
        private Guna.UI2.WinForms.Guna2TileButton btnKOT;
        private Guna.UI2.WinForms.Guna2TileButton btnBillList;
        private Guna.UI2.WinForms.Guna2TileButton btnHold;
        private Guna.UI2.WinForms.Guna2TileButton btnNew;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.FlowLayoutPanel pnlProduct;
        private Guna.UI2.WinForms.Guna2PictureBox PtbExit;
        private System.Windows.Forms.FlowLayoutPanel pnlCategory;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label lblWaiter;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}