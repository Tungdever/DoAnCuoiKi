﻿using QuanLyNhaHang.BS_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class frmLogin : Form
    {
        DataTable dtTaiKhoan = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        string err;
        BLTaiKhoan dbTK = new BLTaiKhoan();
        public frmLogin()
        {
            InitializeComponent();
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (dbTK.DangNhap(txtUser.Text,txtPass.Text)) 
            {
                this.Hide();
                frmMain frm = new frmMain();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác!!!");
            }
        }
    }
}
