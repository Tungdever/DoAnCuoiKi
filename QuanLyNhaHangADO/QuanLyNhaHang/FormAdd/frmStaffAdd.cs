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

namespace QuanLyNhaHang
{
    public partial class frmStaffAdd : Form
    {
        string err;
        BLNhanVien dbNV = new BLNhanVien();
        public frmStaffAdd()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtStaffID.Text.Trim() == "" || txtStaffName.Text.Trim() == "" || txtStaffPhone.Text.Trim() == "" ||  txtStaffRole.Text.Trim() == "" || txtSalary.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!!!");
                return;
            }
            if (txtStaffID.ReadOnly == true)
            {
                dbNV.CapNhatNhanVien(txtStaffID.Text, txtStaffName.Text, txtStaffPhone.Text, txtStaffRole.Text, int.Parse(txtSalary.Text), ref err );
                MessageBox.Show("Đã sửa xong!");
            }
            else
            {
                try
                {
                    dbNV.ThemNhanVien(txtStaffID.Text, txtStaffName.Text, txtStaffPhone.Text, txtStaffRole.Text, int.Parse(txtSalary.Text), ref err);
                    MessageBox.Show("Đã thêm xong!");
                }
                catch 
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            this.Close();
        }

      
    }
}
