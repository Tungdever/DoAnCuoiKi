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
            if (txtProductID.Text.Trim() == "" || txtProductName.Text.Trim() == "" || txtPrice.Text.Trim() == "" || txtImage.Image == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!!!");
                return;
            }
            if (txtProductID.ReadOnly == true)
            {
                if (cbbCateID.SelectedItem != null)
                {
                    string displayValue = cbbCateID.Text;
                    string[] splitValues = displayValue.Split('-');
                    string madm = splitValues[0];
                    string tendm = splitValues[1];
                    dbSP.CapNhatSanPham(txtProductID.Text, txtProductName.Text, madm, tendm, float.Parse(txtPrice.Text), txtImage.Image, ref err);
                }
                MessageBox.Show("Đã sửa xong!");
            }
            else
            {
                try
                {
                    string displayValue = cbbCateID.Text;
                    string[] splitValues = displayValue.Split('-');
                    string madm = splitValues[0];
                    string tendm = splitValues[1];
                    dbSP.ThemSanPham(txtProductID.Text, txtProductName.Text, madm, tendm, float.Parse(txtPrice.Text), txtImage.Image, ref err);
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }
            this.Close();
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
    }
}
