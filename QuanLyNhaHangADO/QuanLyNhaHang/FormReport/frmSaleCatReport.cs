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
        BLReport dbReportCat = new BLReport();
        DataTable dtReportCat = null;
        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                dtReportCat = new DataTable();
                dtReportCat = dbReportCat.GetSaleByCatBetweenDate(Convert.ToDateTime(guna2DateTimePicker1.Value).Date, Convert.ToDateTime(guna2DateTimePicker2.Value).Date).Tables[0];
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
    }
}
