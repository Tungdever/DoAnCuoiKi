using QuanLyNhaHang.BS_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class frmProductAdd : Form
    {
        DataTable dtDM = null;
        string err;
        BLDanhMuc dbDM = new BLDanhMuc();
        BLSanPham dbSP = new BLSanPham();
        public frmProductAdd()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductID.ReadOnly == true)
            {
                dbSP.CapNhatSanPham(txtProductID.Text, txtProductName.Text, cbbCateID.Text, txtCateName.Text, float.Parse(txtPrice.Text), txtImage.Image, ref err);
                MessageBox.Show("Đã sửa xong!");
            }
            else
            {
                try
                {
                    dbSP.ThemSanPham(txtProductID.Text, txtProductName.Text, cbbCateID.Text, txtCateName.Text, float.Parse(txtPrice.Text), txtImage.Image, ref err);
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            this.Close();
        }

        private void frmProductAdd_Load(object sender, EventArgs e)
        {

        }
        string filepath;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg, .png) | * .png; *.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filepath = ofd.FileName;
                txtImage.Image = new Bitmap(filepath);
            }
        }

        private void cbbCateID_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCateName.Text = dbDM.LayTenDanhMuc(cbbCateID.Text);
        }
    }
}
