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

namespace QuanLyNhaHang
{
    public partial class frmCategoryAdd : Form
    {
        string err;
        BLDanhMuc dbDM = new BLDanhMuc();
        public frmCategoryAdd()
        {
            InitializeComponent();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == "" || txtName.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!!!");
                return;
            }
            if (txtID.ReadOnly == true)
            {

                if (dbDM.CapNhatDanhMuc(txtID.Text, txtName.Text, ref err))
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
                if (dbDM.ThemDanhMuc(txtID.Text, txtName.Text, ref err))
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
