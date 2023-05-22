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
    public partial class categoryForm : Form
    {       
        string err;
        BLDanhMuc dbDM = new BLDanhMuc();
        public categoryForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCategoryAdd frm = new frmCategoryAdd();
            frm.txtID.ReadOnly = false;
            frm.ShowDialog();
            LoadData();
        }
        void LoadData()
        {
            try
            {              
                dgvCategory.DataSource = dbDM.LayDanhMuc();
                dgvCategory.AutoResizeColumns();

            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi rồi!!!");
            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (dgvCategory.CurrentCell.OwningColumn.Name == "dgvEdit")
                {
                    frmCategoryAdd frm = new frmCategoryAdd();
                    frm.txtID.Text = dgvCategory.CurrentRow.Cells["dgvID"].Value.ToString();
                    frm.txtName.Text = dgvCategory.CurrentRow.Cells["dgvName"].Value.ToString();
                    frm.ShowDialog();
                    LoadData();
                }
                else if (dgvCategory.CurrentCell.OwningColumn.Name == "dgvDel")
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xoá dòng này không?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        dbDM.XoaDanhMuc(dgvCategory.CurrentRow.Cells["dgvID"].Value.ToString(), ref err);
                        LoadData();
                        MessageBox.Show("Xoá thành công!");
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!");
            }

        }

        private void categoryForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtSearchCategories_TextChanged(object sender, EventArgs e)
        {
            try
            {                
                dgvCategory.DataSource = dbDM.TimKiemDanhMuc(txtSearchCategories.Text);
                // Thay đổi độ rộng cột
                dgvCategory.AutoResizeColumns();

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table DanhMuc. Lỗi rồi!!!");
            }
        }
    }
}
