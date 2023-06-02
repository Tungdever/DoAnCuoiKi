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
            catch (SqlException)
            {
                MessageBox.Show("Lỗi rồi!!!");
            }
        }

        private void dgvAcc_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (dgvAcc.CurrentCell.OwningColumn.Name == "dgvEdit")
                {
                    frmAccountAdd frm = new frmAccountAdd();
                    frm.txtTenTK.ReadOnly = true;
                    frm.cbbTenNV.DataSource = dbNV.LayDSNV();
                    frm.cbbTenNV.ValueMember = "ID";
                    frm.cbbTenNV.DisplayMember = "Display";
                    frm.txtTenTK.Text = dgvAcc.CurrentRow.Cells["dgvTenTK"].Value.ToString();
                    if (frm.txtTenTK.Text == "admin")
                    {
                        frm.cbbTenNV.Enabled = false;
                        frm.txtCapDo.ReadOnly = true;
                    }
                    else
                    {
                        frm.cbbTenNV.Enabled = true;
                        frm.txtCapDo.ReadOnly = false;
                    }
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
                    
                    if (dgvAcc.CurrentRow.Cells["dgvTenTK"].Value.ToString() == "admin")
                    {
                        MessageBox.Show("Không thể xoá tài khoản ADMIN");
                        return;
                    }
                    DialogResult result = MessageBox.Show("Bạn có muốn xoá dòng này không?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        dbTK.XoaTaiKhoan(dgvAcc.CurrentRow.Cells["dgvTenTK"].Value.ToString(), ref err);
                        txtSearchAcc.Text = "";
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

        private void accountForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtSearchAcc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvAcc.DataSource = dbTK.TimKiemTaiKhoan(txtSearchAcc.Text);
                dgvAcc.AutoResizeColumns();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table DanhMuc. Lỗi rồi!!!");
            }
        }
    }
}
