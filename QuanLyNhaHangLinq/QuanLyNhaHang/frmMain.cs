﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using QuanLyNhaHang.BS_layer;

namespace QuanLyNhaHang
{
    public partial class frmMain : Form
    {
        BLTaiKhoan dbTK = new BLTaiKhoan();
        public frmMain()
        {
            InitializeComponent();
        }
        public string user = "";
        public void AddControls(Form frm)
        {
            CenterPanel.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            frm.TopLevel = false;
            CenterPanel.Controls.Add(frm);
            frm.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            frmHome frm = new frmHome();
            frm.lblHello.Text += dbTK.TimKiemTen(user);
            frm.lblQuyen.Text += dbTK.LayQuyen(user);
            AddControls(frm);
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            AddControls(new categoryForm());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            AddControls(new productForm());
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            AddControls(new tableForm());
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            AddControls(new staffForm());
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            AddControls(new accountForm());
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmHome frm = new frmHome();
            frm.lblHello.Text += dbTK.TimKiemTen(user);
            frm.lblQuyen.Text += dbTK.LayQuyen(user);
            AddControls(frm);
        }
    }
}
