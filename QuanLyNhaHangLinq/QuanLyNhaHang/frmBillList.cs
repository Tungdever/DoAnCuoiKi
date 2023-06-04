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
    public partial class frmBillList : Form
    {

        BLTblMain dbTblMain = new BLTblMain();
        DataTable dtBillList = null;
        DataTable dtBillPrint = null;
        string err;
        public int MainID = 0;
        public bool bonus;
        public string OrderType = "";
        public frmBillList()
        {
            InitializeComponent();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadData()
        {
            try
            {
                // dgvBillList.Columns.Clear();
                dtBillList = new DataTable();
                dtBillList.Clear();
                //   DataSet ds = dbTblMain.GetBills(); dtBillList = ds.Tables[0];
                dtBillList = dbTblMain.GetBills();
                
                dgvBillList.DataSource = dtBillList;
                dgvBillList.AutoResizeColumns();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table THANHPHO. Lỗi rồi!!!");
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void frmBillList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvBillList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
