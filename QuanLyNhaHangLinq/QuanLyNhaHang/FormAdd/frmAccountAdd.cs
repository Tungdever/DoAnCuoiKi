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
            if (txtTenTK.Text.Trim() == "" || txtMK.Text.Trim() == "" || txtCapDo.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!!!");
                return;
            }
            if (txtTenTK.ReadOnly == true)
            {
                if (dbTK.CapNhatTaiKhoan(txtTenTK.Text, txtMK.Text, cbbTenNV.SelectedValue.ToString(), int.Parse(txtCapDo.Text), ref err))
                {
                    MessageBox.Show("Đã sửa xong!");
                }
                else
                {
                    MessageBox.Show("Sửa không thành công. Lỗi: '" + err + "'");
                }

            }
            else
            {
                if (dbTK.ThemTaiKhoan(txtTenTK.Text, txtMK.Text, cbbTenNV.SelectedValue.ToString(), int.Parse(txtCapDo.Text), ref err))
                {
                    MessageBox.Show("Đã thêm xong!");
                }
                else
                {
                    MessageBox.Show("Thêm không thành công. Lỗi: '" + err + "'");
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
