using QuanLyNhaHang.BS_layer;
using QuanLyNhaHang.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang.FormReport
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
               //    dtProduct = dbSP.LoadMenu();
                dtProduct = dbSP.LoadMenu().Copy();// Điều này sẽ tạo một bản sao độc lập của DataTable để đảm bảo rằng dữ liệu không bị thay đổi sau khi gán nó cho Crystal Report.
              //  sp = dbSP.LoadMenu();


            }
            catch (SqlException error)
            {
                MessageBox.Show("Không Lấy được thực đơn. Lỗi: " + error.Message);
            }
            frmPrint frm = new frmPrint();
            rptMenu cr = new rptMenu();
            //  cr.SetDatabaseLogon
           // cr.SetDataSource(sp);
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
                dtStaff = dbNV.Staff();

            }
            catch (SqlException error)
            {
                MessageBox.Show("Không Lấy được danh sách nhân viên. Lỗi: " + error.Message);
            }
            frmPrint frm = new frmPrint();
            rptStaffList cr = new rptStaffList();
            //  cr.SetDatabaseLogon
            cr.SetDataSource(dtStaff);
           // cr.SetDataSource(nv);
            frm.crystalReportViewer1.ReportSource = cr;
            frm.crystalReportViewer1.Refresh();
            frm.Show();
        }

        private void btnSaleByCategory_Click(object sender, EventArgs e)
        {

            frmSaleCatReport frm = new frmSaleCatReport();
            frm.Show();
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            thongkeForm frm = new thongkeForm();
            frm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
