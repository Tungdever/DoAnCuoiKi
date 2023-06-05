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

namespace QuanLyNhaHang.Select
{
    public partial class frmTableSelect : Form
    {

        BLTable dbTable = new BLTable();
        DataTable dtTable = null;

        public frmTableSelect()
        {
            InitializeComponent();
        }
        public string TableName = "";
        public string TableID = "";
        public string err;
        private void frmTableSelect_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            /*  dtTable = new DataTable();
              dtTable.Clear();
              DataSet ds = dbTable.LayTable();
              dtTable = ds.Tables[0];*/
            List<BAN> bans = dbTable.LayTable1();
            //   foreach (DataRow row in dtTable.Rows)
            foreach (BAN ban in bans)
            {
                Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();

                /* TableInfo tableInfo = new TableInfo
                 {
                     TableName = row["Tname"].ToString(),
                     TableID = row["TableID"].ToString()
                 };*/

                //  b.Text = row["Tname"].ToString();
                b.Text = ban.Tname.ToString();
                b.Width = 150;
                b.Height = 50;
                b.FillColor = Color.FromArgb(241, 85, 126);
                b.HoverState.FillColor = Color.FromArgb(50, 55, 89);

                // b.Tag = tableInfo; // Lưu trữ đối tượng TableInfo vào Tag của nút
                //    b.Tag = row["Tid"].ToString();

                b.Tag = ban.Tid.ToString();
                b.Click += new EventHandler(b_Click);
                if (ban.Tstate.ToString().Equals("Đã Đặt"))
                    b.Enabled = false;
                else
                    b.Enabled = true;
                flowLayoutPanel1.Controls.Add(b);
            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            TableName = (sender as Guna.UI2.WinForms.Guna2Button).Text.ToString();
            TableID = (sender as Guna.UI2.WinForms.Guna2Button).Tag.ToString();
            if (dbTable.CapNhatTable(TableID, TableName, "Đã Đặt", ref err))
            {
                MessageBox.Show($"Đặt {TableName} thành công");
            }
            else
                MessageBox.Show(err);
            this.Close();// Đóng form
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
