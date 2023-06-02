using QuanLyNhaHang.BS_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;
namespace QuanLyNhaHang
{
    public partial class frmAccountAdd : Form
    {
        string err;
        BLTaiKhoan dbTK = new BLTaiKhoan();
        public frmAccountAdd()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTenTK.ReadOnly == true)
            {
                dbTK.CapNhatTaiKhoan(txtTenTK.Text, txtMK.Text, cbbTenNV.SelectedValue.ToString(), int.Parse(txtCapDo.Text), ref err);
                MessageBox.Show("Đã sửa xong!");
            }
            else
            {
                try
                {
                    dbTK.ThemTaiKhoan(txtTenTK.Text, txtMK.Text, cbbTenNV.SelectedValue.ToString(), int.Parse(txtCapDo.Text), ref err);
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
