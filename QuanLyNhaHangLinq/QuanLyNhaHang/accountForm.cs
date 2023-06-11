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
    public partial class accountForm : Form
    {
        string err;
        BLTaiKhoan dbTK = new BLTaiKhoan();
        BLNhanVien dbNV = new BLNhanVien();
        public accountForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAccountAdd frm = new frmAccountAdd();
            frm.txtTenTK.ReadOnly = false;
            frm.cbbTenNV.DataSource = dbNV.LayDSNV();
            frm.cbbTenNV.ValueMember = "ID";
            frm.cbbTenNV.DisplayMember = "Display";
            frm.ShowDialog();
            LoadData();
        }
        void LoadData()
        {
            try
            {
                dgvAcc.DataSource = dbTK.LayTaiKhoan();
                dgvAcc.AutoResizeColumns();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không thể lấy nội dung trong table TAIKHOAN. Lỗi: " + ex);
            }
        }

        private void dgvAcc_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvAcc.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                frmAccountAdd frm = new frmAccountAdd();
                frm.txtTenTK.ReadOnly = true;
                frm.cbbTenNV.DataSource = dbNV.LayDSNV();
                frm.cbbTenNV.ValueMember = "ID";
                frm.cbbTenNV.DisplayMember = "Display";
                frm.txtTenTK.Text = dgvAcc.CurrentRow.Cells["dgvTenTK"].Value.ToString();
                frm.txtMK.Text = dgvAcc.CurrentRow.Cells["dgvMatKhau"].Value.ToString();
                frm.cbbTenNV.SelectedValue = dgvAcc.CurrentRow.Cells["dgvMaNV"].Value.ToString().Split('-')[0].Trim();
                frm.txtCapDo.Text = dgvAcc.CurrentRow.Cells["dgvCapDo"].Value.ToString();
                frm.ShowDialog();
                if (txtSearchAcc.Text != "")
                {
                    dgvAcc.DataSource = dbTK.TimKiemTaiKhoan(txtSearchAcc.Text);
                }
                else
                {
                    LoadData();
                }
            }
            else if (dgvAcc.CurrentCell.OwningColumn.Name == "dgvDel")
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xoá dòng này không?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (dbTK.XoaTaiKhoan(dgvAcc.CurrentRow.Cells["dgvTenTK"].Value.ToString(), ref err))
                    {
                        txtSearchAcc.Text = "";
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

        private void txtSearchAcc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvAcc.DataSource = dbTK.TimKiemTaiKhoan(txtSearchAcc.Text);
                // Thay đổi độ rộng cột
                dgvAcc.AutoResizeColumns();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không thể lấy nội dung trong table TAIKHOAN. Lỗi: " + ex);
            }
        }
    }
}
