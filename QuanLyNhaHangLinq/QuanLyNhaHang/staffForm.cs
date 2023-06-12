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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class staffForm : Form
    {
        string err;
        BLNhanVien dbNV = new BLNhanVien();
        BLTaiKhoan dbTK = new BLTaiKhoan();
        public staffForm()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                dgvStaff.DataSource = dbNV.LayNhanVien();
                dgvStaff.AutoResizeColumns();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không thể lấy nội dung trong table NHANVIEN. Lỗi: " + ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmStaffAdd frm = new frmStaffAdd();
            frm.lblAdd.Text = "Staff Add";
            frm.txtStaffID.ReadOnly = false;
            frm.ShowDialog();
            LoadData();
        }

        private void staffForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtSearchStaff_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvStaff.DataSource = dbNV.TimKiemNhanVien(txtSearchStaff.Text);
                // Thay đổi độ rộng cột
                dgvStaff.AutoResizeColumns();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không lấy được nội dung trong table NHANVIEN. Lỗi: " + ex);
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
                frm.lblAdd.Text = "Staff Edit";
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
                if (dgvStaff.CurrentRow.Cells["dgvManv"].Value.ToString() == "NV0")
                {
                    MessageBox.Show("Không thể xoá chủ nhà hàng");
                    return;
                }
                DialogResult result = MessageBox.Show("Bạn có muốn xoá dòng này không?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (dbTK.XoaTaiKhoanTheoNV(dgvStaff.CurrentRow.Cells["dgvManv"].Value.ToString(), ref err) && dbNV.XoaNHanVien(dgvStaff.CurrentRow.Cells["dgvManv"].Value.ToString(), ref err))
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
    }
}
