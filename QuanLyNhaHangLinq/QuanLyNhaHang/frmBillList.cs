using QuanLyNhaHang.BS_layer;
using QuanLyNhaHang.FormReport;
using QuanLyNhaHang.Reports;
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
        public bool edit = false;
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
            catch (SqlException error)
            {
                MessageBox.Show("Không lấy được nội dung trong table tblMain. Lỗi rồi!!!" + error.Message);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Saved");
            this.Close();
        }

        private void frmBillList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvBillList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Khi ấn vào Edit có thể là sửa lại đơn hàng hoặc thanh toán
                if (dgvBillList.CurrentCell.OwningColumn.Name == "dgvEdit")
                {
                    edit = true;    
                    //Cap nhat gia tri cho bool Them ben formPos
                    bonus = false;
                    MainID = Convert.ToInt32(dgvBillList.CurrentRow.Cells["dgvMaBill"].Value);
                    OrderType = dgvBillList.CurrentRow.Cells["dgvOrderType"].Value.ToString();
                    this.Close();
                    // Cập nhật MainID và thót khỏi form BillList, trở lại formPos và hiển thị đơn lên lại dgvPOS để edit
                }
                if (dgvBillList.CurrentCell.OwningColumn.Name == "dgvPrint")
                {
                    edit = false;
                    MainID = Convert.ToInt32(dgvBillList.CurrentRow.Cells["dgvMaBill"].Value);
                    try
                    {
                        dtBillPrint = new DataTable();
                        dtBillPrint.Clear();
                        //  dtBillPrint = dbTblMain.GetJoin(MainID).Tables[0];
                        dtBillPrint = dbTblMain.GetJoinRP(MainID);
                    }
                    catch (SqlException err)
                    {
                        MessageBox.Show("Không in được bill này. Lỗi: " + err);
                    }

                    frmPrint frm = new frmPrint();
                    rptBill cr = new rptBill();
                    cr.SetDataSource(dtBillPrint);
                    frm.crystalReportViewer1.ReportSource = cr;
                    frm.crystalReportViewer1.Refresh();
                    frm.Show();
                   
                }
            }

            catch (SqlException error)
            {
                MessageBox.Show("Không xóa được. Lỗi: " + error.Message);
            }
        }
    }
}
