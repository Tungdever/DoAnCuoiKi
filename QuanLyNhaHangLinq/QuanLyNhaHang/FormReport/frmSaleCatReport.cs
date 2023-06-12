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

namespace QuanLyNhaHang.FormReport
{
    public partial class frmSaleCatReport : Form
    {
        public frmSaleCatReport()
        {
            InitializeComponent();
        }
        public DateTime sDate = DateTime.Now;
        public DateTime eDate = DateTime.Now;
        //  BLReport dbReportCat = new BLReport();
        DataTable dtReportCat = null;
        BLTblMain dbTbMain = new BLTblMain();
        private void frmSaleCatReport_Load(object sender, EventArgs e)
        {
            guna2DateTimePicker1.Value = sDate;
            guna2DateTimePicker2.Value = eDate;
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            sDate = guna2DateTimePicker1.Value;
        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            eDate = guna2DateTimePicker2.Value;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                dtReportCat = new DataTable();
                dtReportCat = dbTbMain.GetSaleByCatBetweenDate(sDate, eDate);
            }
            catch (SqlException error)
            {
                MessageBox.Show("Không Lấy được danh sách nhân viên. Lỗi rồi!" + error.Message);
            }
            frmPrint frm = new frmPrint();
            rptSaleByCategory cr = new rptSaleByCategory();
            cr.SetDataSource(dtReportCat);
            frm.crystalReportViewer1.ReportSource = cr;
            frm.crystalReportViewer1.Refresh();
            frm.Show();
        }
    }
}
