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
            
            frm.cbbCateID.DataSource = dbDM.LayDanhSachMaDanhMuc();
            frm.cbbCateID.DisplayMember = "MaDM";
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
            catch (SqlException)
            {
                MessageBox.Show("Lỗi rồi!!!");
            }
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (dgvProduct.CurrentCell.OwningColumn.Name == "dgvEdit")
                {

                    frmProductAdd frm = new frmProductAdd();                    
                    DataSet dsIMG = dbSP.LayHinh(dgvProduct.CurrentRow.Cells["dgvMaSP"].Value.ToString(), ref err);
                    DataTable dtIMG = dsIMG.Tables[0];
                    if (dtIMG.Rows.Count > 0)
                    {
                        if (!DBNull.Value.Equals(dtIMG.Rows[0]["AnhSP"]))
                        {
                            byte[] imageBytes = (byte[])dtIMG.Rows[0]["AnhSP"];
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                frm.txtImage.Image = System.Drawing.Image.FromStream(ms);
                            }
                        }
                    }
                    frm.cbbCateID.DataSource = dbDM.LayDanhSachMaDanhMuc();
                    frm.cbbCateID.DisplayMember = "MaDM";
                    frm.txtProductID.ReadOnly = true;

                    frm.txtProductID.Text = dgvProduct.CurrentRow.Cells["dgvMaSP"].Value.ToString();
                    frm.txtProductName.Text = dgvProduct.CurrentRow.Cells["dgvTenSP"].Value.ToString();
                    frm.txtCateName.Text = dgvProduct.CurrentRow.Cells["dgvpCatName"].Value.ToString();
                    frm.txtPrice.Text = dgvProduct.CurrentRow.Cells["dgvPrice"].Value.ToString();
                    frm.cbbCateID.SelectedText = dgvProduct.CurrentRow.Cells["dgvpCatID"].Value.ToString();                 
                    frm.ShowDialog();
                    LoadData();
                }
                else if (dgvProduct.CurrentCell.OwningColumn.Name == "dgvDel")
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xoá dòng này không?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        dbSP.XoaSanPham(dgvProduct.CurrentRow.Cells["dgvMaSP"].Value.ToString(), ref err);
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
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table DanhMuc. Lỗi rồi!!!");
            }
        }

        private void productForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
