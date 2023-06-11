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
    public partial class staffForm : Form
    {
        DataTable dtNV = null;
        string err;
        BLNhanVien dbNV = new BLNhanVien();
        public staffForm()
        {
            InitializeComponent();
        }

        private void staffForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           frmStaffAdd frm = new frmStaffAdd();
           frm.txtStaffID.ReadOnly = false;
           frm.ShowDialog();
           LoadData();
       
        }
        void LoadData()
        {
            try
            {
                dtNV = new DataTable();
                dtNV.Clear();
                DataSet ds = dbNV.LayNhanVien();
                dtNV = ds.Tables[0];
                // Đưa dữ liệu lên DataGridView
                dgvStaff.DataSource = dtNV;
                // Thay đổi độ rộng cột
                dgvStaff.AutoResizeColumns();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table NHANVIEN. Lỗi: " + e);
            }
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvStaff.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                frmStaffAdd frm = new frmStaffAdd();
                frm.txtStaffID.ReadOnly = true;
                frm.txtStaffID.Text = dgvStaff.CurrentRow.Cells["dgvManv"].Value.ToString();
                frm.txtStaffName.Text = dgvStaff.CurrentRow.Cells["dgvTen"].Value.ToString();
                frm.txtStaffPhone.Text = dgvStaff.CurrentRow.Cells["dgvSDT"].Value.ToString();
                frm.txtStaffRole.Text = dgvStaff.CurrentRow.Cells["dgvChucVu"].Value.ToString();
                frm.txtSalary.Text = dgvStaff.CurrentRow.Cells["dgvLuong"].Value.ToString();
                frm.ShowDialog();
                if (txtSearchStaff.Text != "")
                {
                    dgvStaff.DataSource = dbNV.TimKiemNhanVien(txtSearchStaff.Text);
                }
                else
                {
                    LoadData();
                }
            }
            else if (dgvStaff.CurrentCell.OwningColumn.Name == "dgvDel")
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xoá dòng này không?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (dbNV.XoaNhanVien(dgvStaff.CurrentRow.Cells["dgvManv"].Value.ToString(), ref err))
                    {
                        txtSearchStaff.Text = "";
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

        private void txtSearchStaff_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dtNV = new DataTable();
                dtNV.Clear();
                DataSet ds  = dbNV.TimKiemNhanVien(txtSearchStaff.Text);
                dtNV = ds.Tables[0];
                // Đưa dữ liệu lên DataGridView
                dgvStaff.DataSource = dtNV;
                // Thay đổi độ rộng cột
                dgvStaff.AutoResizeColumns();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không lấy được nội dung trong table NHANVIEN. Lỗi: " + ex);
            }
        }
    }
}
