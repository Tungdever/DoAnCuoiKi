using QuanLyNhaHang.BS_layer;
using QuanLyNhaHang.Reports;
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
        public frmBillList()
        {
            InitializeComponent();
        }

        private void frmBillList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
               // dgvBillList.Columns.Clear();
                dtBillList = new DataTable();
                dtBillList.Clear();
                DataSet ds = dbTblMain.GetBills();
                dtBillList = ds.Tables[0];
                dgvBillList.DataSource = dtBillList;
                dgvBillList.AutoResizeColumns();
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table THANHPHO. Lỗi rồi!!!");
            }

        }

        private void dgvBillList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                //Khi ấn vào Edit có thể là sửa lại đơn hàng hoặc thanh toán
                if (dgvBillList.CurrentCell.OwningColumn.Name == "dgvEdit")
                {
                    //Cap nhat gia tri cho bool Them ben formPos
                    bonus = false;
                    MainID = Convert.ToInt32(dgvBillList.CurrentRow.Cells["dgvMaBill"].Value);
                    this.Close();
                    // Cập nhật MainID và thót khỏi form BillList, trở lại formPos và hiển thị đơn lên lại dgvPOS để edit
                }
                if(dgvBillList.CurrentCell.OwningColumn.Name == "dgvPrint")
                {
                    MainID = Convert.ToInt32(dgvBillList.CurrentRow.Cells["dgvMaBill"].Value);
                    try
                    {
                        dtBillPrint = new DataTable();
                        dtBillPrint.Clear();
                        dtBillPrint = dbTblMain.GetJoin(MainID).Tables[0];
                    }
                    catch (SqlException err)
                    {
                        MessageBox.Show("Không in được bill này. Lỗi rồi!!!" + err);
                    }

                    frmPrint frm = new frmPrint();  
                    rptBill cr =  new rptBill();
                    cr.SetDataSource(dtBillPrint);
                    frm.crystalReportViewer1.ReportSource = cr;
                    frm.crystalReportViewer1.Refresh();
                    frm.Show();
                }    
            }

            catch (SqlException error)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!"+error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}
