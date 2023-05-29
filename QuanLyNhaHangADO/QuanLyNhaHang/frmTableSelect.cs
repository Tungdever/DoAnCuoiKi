using QuanLyNhaHang.BS_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class frmTableSelect : Form

    {
        BLTable dbTable = new BLTable();
        DataTable dtTable = null;
        public frmTableSelect()
        {
            InitializeComponent();
        }
        public string TableName;

        private void frmTableSelect_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        //lẤY TÊN các bàn đưa vào các button
        private void LoadData()
        {
            dtTable = new DataTable();
            dtTable.Clear();
            DataSet ds = dbTable.LayTable();
            dtTable = ds.Tables[0];
            foreach (DataRow row in dtTable.Rows)
            {
                Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                b.Text = row["Tname"].ToString();
                b.Width = 150;
                b.Height = 50;
                b.FillColor = Color.FromArgb(241, 85, 126);
                b.HoverState.FillColor = Color.FromArgb(50, 55, 89);

                b.Click += new EventHandler(b_Click);
                flowLayoutPanel1.Controls.Add(b);
            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            TableName = (sender as Guna.UI2.WinForms.Guna2Button).Text.ToString();
            this.Close();// Đóng form
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
