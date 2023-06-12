using QuanLyNhaHang.BS_layer;
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
    public partial class frmSaleCatReport : Form
    {
        public frmSaleCatReport()
        {
            InitializeComponent();
        }
        public DateTime sDate = DateTime.Now;
        public DateTime eDate = DateTime.Now;
        BLReport dbReportCat = new BLReport();
        BLTblMain dbTbMain = new BLTblMain();
        BLTblDetail dbTbDetail = new BLTblDetail();
       // BLSanPham dbsan
        DataTable dtReportCat = null;
        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                dtReportCat = new DataTable();
               dtReportCat = dbReportCat.GetSaleByCatBetweenDate(sDate, eDate).Tables[0];
                /*dtReportCat.Columns.Add("TenDM", typeof(string));
                dtReportCat.Columns.Add("TenSP", typeof(string));
                dtReportCat.Columns.Add("aDate", typeof(DateTime));
                dtReportCat.Columns.Add("qty", typeof(int));
                dtReportCat.Columns.Add("price", typeof(decimal));
                dtReportCat.Columns.Add("amount", typeof(decimal));
                foreach (DataRow row in dbReportCat.GetSaleByCatBetweenDate(sDate, eDate).Tables[0].Rows)
                {
                    DataRow newRow = dtReportCat.NewRow();
                    newRow["TenDM"] = row["TenDM"];
                    newRow["TenSP"] = row["TenSP"];
                    newRow["aDate"] = row["aDate"];
                    newRow["qty"] = row["qty"];
                    newRow["price"] = row["price"];
                    newRow["amount"] = row["amount"];
                    dtReportCat.Rows.Add(newRow);
                }
                */
            }

            catch (SqlException error)
            {
                MessageBox.Show("Không Lấy được danh sách nhân viên. Lỗi rồi!" + error);
            }
            frmPrint frm = new frmPrint();
            rptSaleByCategory cr = new rptSaleByCategory();
            cr.SetDataSource(dtReportCat);
            frm.crystalReportViewer1.ReportSource = cr;
            frm.crystalReportViewer1.Refresh();
            frm.Show();
        
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            sDate = guna2DateTimePicker1.Value;
        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            eDate= guna2DateTimePicker2.Value;
        }

        private void frmSaleCatReport_Load(object sender, EventArgs e)
        {
            guna2DateTimePicker1.Value = sDate;
            guna2DateTimePicker2.Value = eDate; 
        }
    }
}
