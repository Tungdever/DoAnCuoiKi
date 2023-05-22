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
        DataTable dtDM = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool Them;
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
            if (txtID.ReadOnly == true )
            {               
                
                dbDM.CapNhatDanhMuc(txtID.Text,txtName.Text, ref err);
                // Load lại dữ liệu trên DataGridView
                MessageBox.Show("Đã sửa xong!");
            }
            else
            {
                try
                {
                    dbDM.ThemDanhMuc(txtID.Text, txtName.Text, ref err);
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            this.Close();
        }
    }
}
