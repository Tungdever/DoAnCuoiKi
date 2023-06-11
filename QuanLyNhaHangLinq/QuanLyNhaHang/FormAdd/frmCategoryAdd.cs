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
    public partial class frmCategoryAdd : Form
    {
        string err;
        BLDanhMuc dbDM = new BLDanhMuc();
        public frmCategoryAdd()
        {
            InitializeComponent();
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtID.ReadOnly == true)
            {

                if (dbDM.CapNhatDanhMuc(txtID.Text, txtName.Text, ref err))
                {
                    // Load lại dữ liệu trên DataGridView
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
    }
}
