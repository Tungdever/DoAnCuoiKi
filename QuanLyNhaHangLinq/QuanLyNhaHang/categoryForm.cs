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
        BLSanPham dbSP = new BLSanPham();
        public categoryForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCategoryAdd frm = new frmCategoryAdd();
            frm.lblAdd.Text = "Category Add";
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
            catch (SqlException ex)
            {
                MessageBox.Show("Không thể lấy nội dung trong table DANHMUC. Lỗi: " + ex);
            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategory.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                frmCategoryAdd frm = new frmCategoryAdd();
                frm.txtID.Text = dgvCategory.CurrentRow.Cells["dgvID"].Value.ToString();
                frm.txtName.Text = dgvCategory.CurrentRow.Cells["dgvName"].Value.ToString();
                frm.lblAdd.Text = "Category Edit";
                frm.ShowDialog();
                if (txtSearchCategories.Text != "")
                {
                    dgvCategory.DataSource = dbDM.TimKiemDanhMuc(txtSearchCategories.Text);
                }
                else
                {
                    LoadData();
                }
            }
            else if (dgvCategory.CurrentCell.OwningColumn.Name == "dgvDel")
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xoá dòng này không?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (dbSP.XoaSanPhamTheoDM(dgvCategory.CurrentRow.Cells["dgvID"].Value.ToString(), ref err) && dbDM.XoaDanhMuc(dgvCategory.CurrentRow.Cells["dgvID"].Value.ToString(), ref err))
                    {
                        txtSearchCategories.Text = "";
                        LoadData();
                        MessageBox.Show("Xoá thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Xoá không thành công. Lỗi: '" + err + "'");
                    }
                }
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
            catch (SqlException ex)
            {
                MessageBox.Show("Không thể lấy nội dung trong table DANHMUC. Lỗi: " + ex);
            }
        }
    }
}
