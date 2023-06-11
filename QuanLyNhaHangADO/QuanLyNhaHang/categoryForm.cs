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
    public partial class categoryForm : Form
    {
        DataTable dtDM = null;
        string err;
        BLDanhMuc dbDM = new BLDanhMuc();
        public categoryForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCategoryAdd frm = new frmCategoryAdd();
            frm.txtID.ReadOnly = false; //  Vì là thêm nên ReadOnly = false;
            frm.ShowDialog();
            LoadData();
        }
        void LoadData()
        {
            try
            {
                dtDM = new DataTable();
                dtDM.Clear();
                DataSet ds = dbDM.LayDanhMuc();
                dtDM = ds.Tables[0];
                // Đưa dữ liệu lên DataGridView
                dgvCategory.DataSource = dtDM;
                // Thay đổi độ rộng cột
                dgvCategory.AutoResizeColumns();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không lấy được nội dung trong table DANHMUC. Lỗi: " + ex.Message);
            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (dgvCategory.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                frmCategoryAdd frm = new frmCategoryAdd();
                frm.txtID.Text = dgvCategory.CurrentRow.Cells["dgvID"].Value.ToString();
                frm.txtName.Text = dgvCategory.CurrentRow.Cells["dgvName"].Value.ToString();
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
                    if (dbDM.XoaDanhMuc(dgvCategory.CurrentRow.Cells["dgvID"].Value.ToString(), ref err))
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
                dtDM = new DataTable();
                dtDM.Clear();
                DataSet ds = dbDM.TimKiemDanhMuc(txtSearchCategories.Text);
                dtDM = ds.Tables[0];
                // Đưa dữ liệu lên DataGridView
                dgvCategory.DataSource = dtDM;
                // Thay đổi độ rộng cột
                dgvCategory.AutoResizeColumns();
               
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không lấy được nội dung trong table DanhMuc. Lỗi: " + ex.Message);
            }
        }
    }
}
