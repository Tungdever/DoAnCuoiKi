using QuanLyNhaHang.BS_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;
namespace QuanLyNhaHang
{
    public partial class frmLogin : Form
    {
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
            if (dbTK.DangNhap(txtUser.Text, txtPass.Text))
            {
                this.Hide();
                frmMain frm = new frmMain();
                if (dbTK.KT(txtUser.Text))
                {
                    frm.btnAccount.Visible = true;
                }
                else
                {
                    frm.btnAccount.Visible = false;
                }
                frm.user = txtUser.Text;
                frm.Show();
            }                      
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác!!!");
            }
        }
        bool hide = true;
        private void txtPass_IconRightClick(object sender, EventArgs e)
        {
            if (hide)
            {
                txtPass.PasswordChar = default;
                hide = false;
                txtPass.IconRight = global::QuanLyNhaHang.Properties.Resources.view;
            }
            else
            {
                txtPass.PasswordChar = '*';
                hide = true;
                txtPass.IconRight = global::QuanLyNhaHang.Properties.Resources.hidden;
            }

        }
    }
}
