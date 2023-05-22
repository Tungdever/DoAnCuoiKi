using QuanLyNhaHang.BS_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class frmWaiterSelect : Form
    {
        DataTable dtNV = null;
        BLNhanVien dbNV = new BLNhanVien();
        string err;
        public string WaiterName;
        public frmWaiterSelect()
        {
            InitializeComponent();
        }

        private void frmWaiterSelect_Load(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            dtNV = new DataTable();
            dtNV.Clear();
            DataSet ds = dbNV.LayNhanVien();
            dtNV = ds.Tables[0];
            foreach (DataRow row in dtNV.Rows)
            {
                Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                b.Text = row["Tname"].ToString();
                b.Width = 510;
                b.Height = 50;
                b.FillColor = Color.FromArgb(241, 85, 126);
                b.HoverState.FillColor = Color.FromArgb(50, 55, 89);

                b.Click += new EventHandler(b_Click);
            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            WaiterName = (sender as Guna.UI2.WinForms.Guna2Button).Text.ToString();
            this.Close();
        }
    }
}
