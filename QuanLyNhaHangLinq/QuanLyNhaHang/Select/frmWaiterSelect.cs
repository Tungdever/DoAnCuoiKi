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

namespace QuanLyNhaHang.Select
{
    public partial class frmWaiterSelect : Form
    {
       // DataTable dtNV = null;
       List<NHANVIEN> nHANVIENs = new List<NHANVIEN>();
        BLNhanVien dbNV = new BLNhanVien();
        public string WaiterName;
        public frmWaiterSelect()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmWaiterSelect_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                /*dtNV = new DataTable();
                dtNV.Clear();
                DataSet ds = dbNV.LayPhucVu();
                dtNV = ds.Tables[0];*/
                nHANVIENs = dbNV.LayPhucVu();
                foreach (NHANVIEN nHANVIEN in nHANVIENs) 
                {
                    Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                    b.Text = nHANVIEN.Ten.ToString();
                    b.Tag = nHANVIEN.Manv.ToString();
                    b.Width = 150;
                    b.Height = 50;
                    b.FillColor = Color.FromArgb(241, 85, 126);
                    b.HoverState.FillColor = Color.FromArgb(50, 55, 89);

                    b.Click += new EventHandler(b_Click);
                    flowLayoutPanel1.Controls.Add(b);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Không lấy được Waiter trong Staff. Lỗi rồi!!!"+ex.Message);
            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            WaiterName = (sender as Guna.UI2.WinForms.Guna2Button).Text.ToString();
            this.Close();
        }
    }
}
