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
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }
        DataTable dtProduct = null;
        DataTable dtStaff = null;
        BLNhanVien dbNV = new BLNhanVien();
        BLSanPham dbSP = new BLSanPham();

        private void btnMenu_Click(object sender, EventArgs e)
        {
            try
            {
                dtProduct = new DataTable();
                dtProduct.Clear();
                dtProduct = dbSP.LoadMenu().Tables[0];
            }
            catch (SqlException error)
            {
                MessageBox.Show("Không Lấy được thực đơn. Lỗi rồi!" + error);
            }
            frmPrint frm = new frmPrint();
            rptMenu cr = new rptMenu();    
          //  cr.SetDatabaseLogon
          cr.SetDataSource(dtProduct);
            frm.crystalReportViewer1.ReportSource = cr;
            frm.crystalReportViewer1.Refresh();
            frm.Show();
        }

        private void btnStaffList_Click(object sender, EventArgs e)
        {
            try
            {
                dtStaff = new DataTable();
                dtStaff.Clear();
                dtStaff = dbNV.LayNhanVien().Tables[0];

            }
            catch (SqlException error)
            {
                MessageBox.Show("Không Lấy được danh sách nhân viên. Lỗi rồi!" + error);
            }
            frmPrint frm = new frmPrint();
            rptStaffList cr = new rptStaffList();
            //  cr.SetDatabaseLogon
            cr.SetDataSource(dtStaff);
            frm.crystalReportViewer1.ReportSource = cr;
            frm.crystalReportViewer1.Refresh();
            frm.Show();
        }

        private void btnSaleByCategory_Click(object sender, EventArgs e)
        {
            frmSaleCatReport frm = new frmSaleCatReport();
            frm.Show();
        }
    }
}
