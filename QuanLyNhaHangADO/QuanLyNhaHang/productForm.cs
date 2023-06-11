using QuanLyNhaHang.BS_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyNhaHang
{
    public partial class productForm : Form
    {
        DataTable dtSP = null;
        DataTable dtDM = null;
        string err;
        BLSanPham dbSP = new BLSanPham();
        BLDanhMuc dbDM = new BLDanhMuc();
        public productForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductAdd frm = new frmProductAdd();
            frm.cbbCateID.DataSource = dbDM.LayDanhSachDanhMuc();
            frm.cbbCateID.ValueMember = "ID";
            frm.cbbCateID.DisplayMember = "Display";
            frm.txtProductID.ReadOnly = false;
            frm.ShowDialog();
            LoadData();
        }
        void LoadData()
        {
            try
            {
                dtSP = new DataTable();
                dtSP.Clear();
                DataSet ds = dbSP.LaySanPham();
                dtSP = ds.Tables[0];
                // Đưa dữ liệu lên DataGridView
                dgvProduct.DataSource = dtSP;
                // Thay đổi độ rộng cột
                dgvProduct.AutoResizeColumns();
            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung trong table SANPHAM. Lỗi: " + e);
            }
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProduct.CurrentCell.OwningColumn.Name == "dgvEdit")
            {

                frmProductAdd frm = new frmProductAdd();
                List<byte[]> dsIMG = dbSP.LayHinh(dgvProduct.CurrentRow.Cells["dgvMaSP"].Value.ToString());
                if (dsIMG.Count > 0)
                {
                    if (!DBNull.Value.Equals(dsIMG[0]))
                    {
                        byte[] imageBytes = dsIMG[0];
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            frm.txtImage.Image = System.Drawing.Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        frm.txtImage.Image = null;
                    }
                }
                else
                {
                    frm.txtImage.Image = null;
                }
                frm.cbbCateID.DataSource = dbDM.LayDanhSachDanhMuc();
                frm.cbbCateID.ValueMember = "ID";
                frm.cbbCateID.DisplayMember = "Display";
                frm.txtProductID.ReadOnly = true;
                frm.txtProductID.Text = dgvProduct.CurrentRow.Cells["dgvMaSP"].Value.ToString();
                frm.txtProductName.Text = dgvProduct.CurrentRow.Cells["dgvTenSP"].Value.ToString();
                string selectedDisplay = dgvProduct.CurrentRow.Cells["dgvpCatID"].Value.ToString() + "-" + dgvProduct.CurrentRow.Cells["dgvpCatName"].Value.ToString();
                frm.cbbCateID.Text = selectedDisplay;
                frm.txtPrice.Text = dgvProduct.CurrentRow.Cells["dgvPrice"].Value.ToString();
                frm.ShowDialog();

                if (txtSearchProduct.Text != "")
                {
                    dgvProduct.DataSource = dbSP.TimKiemSanPham(txtSearchProduct.Text);
                }
                else
                {
                    LoadData();
                }
            }
            else if (dgvProduct.CurrentCell.OwningColumn.Name == "dgvDel")
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xoá dòng này không?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (dbSP.XoaSanPham(dgvProduct.CurrentRow.Cells["dgvMaSP"].Value.ToString(), ref err))
                    {
                        txtSearchProduct.Text = "";
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
        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dtSP = new DataTable();
                dtSP.Clear();
                DataSet ds = dbSP.TimKiemSanPham(txtSearchProduct.Text);
                dtSP = ds.Tables[0];
                // Đưa dữ liệu lên DataGridView
                dgvProduct.DataSource = dtSP;
                // Thay đổi độ rộng cột
                dgvProduct.AutoResizeColumns();
            }
            catch (SqlException error)
            {
                MessageBox.Show("Không lấy được nội dung trong table SANPHAM. Lỗi: " + error);
            }
        }

        private void productForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
