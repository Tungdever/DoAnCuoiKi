using Guna.UI2.WinForms;
using QuanLyNhaHang.BS_layer;
using QuanLyNhaHang.Reports;
using System;
using System.Collections;
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
    public partial class frmKitchen : Form
    {
        BLTblMain dbTblMain = new BLTblMain();
        BLTblDetail dbTblDetail = new BLTblDetail();
        DataTable dtTblDetails = null;
        DataTable dtTblMain = null;
        DataTable dtTblJoin = null;
        string err;
        public frmKitchen()
        {
            InitializeComponent();
        }

        private void frmKitchen_Load(object sender, EventArgs e)
        {
            GetOrders();
        }
        private void GetOrders()
        {
            flowLayoutPanel1.Controls.Clear();

            DataSet ds = dbTblMain.GetOrders();
            dtTblMain = ds.Tables[0];
            FlowLayoutPanel p1;
            if (dtTblMain.Rows.Count > 0)
            {
                for (int i = 0; i < dtTblMain.Rows.Count; i++)
                {
                    //Thêm các tiêu đề bằng label
                    p1 = new FlowLayoutPanel();
                    p1.AutoSize = true;
                    p1.Width = 300;
                    p1.Height = 600;
                    p1.FlowDirection = FlowDirection.TopDown;
                    p1.BorderStyle = BorderStyle.FixedSingle;
                    p1.Margin = new Padding(10, 10, 10,10);

                    FlowLayoutPanel p2 = new FlowLayoutPanel();
                    p2 = new FlowLayoutPanel();
                    p2.BackColor = Color.FromArgb(50, 55, 89);
                    p2.AutoSize = true;
                    p2.Width = 300;
                    p2.Height = 130;
                    p2.FlowDirection = FlowDirection.TopDown;
                    p2.BorderStyle = BorderStyle.FixedSingle;
                    p2.Margin = new Padding(0,0,0,0);
                    p2.Dock = DockStyle.Top;
                    //     Console.WriteLine(p1.Size.Width);
                    ///     Console.WriteLine(p2.Size.Width);
                    
                    Label lb1 = new Label();
                    lb1.ForeColor = Color.White;
                    lb1.Margin = new Padding(10, 10, 3, 0);
                    lb1.AutoSize = true;

                    Label lb2 = new Label();
                    lb2.ForeColor = Color.White;
                    lb2.Margin = new Padding(10, 5, 3, 0);
                    lb2.AutoSize = true;

                    Label lb3 = new Label();
                    lb3.ForeColor = Color.White;
                    lb3.Margin = new Padding(10, 5, 3, 0);
                    lb3.AutoSize = true;

                    Label lb4 = new Label();
                    lb4.ForeColor = Color.White;
                    lb4.Margin = new Padding(10, 5, 3, 10);
                    lb4.AutoSize = true;

                    lb1.Text = "Table: " + dtTblMain.Rows[i]["TableName"].ToString();
                    lb2.Text = "Waiter Name: " + dtTblMain.Rows[i]["WaiterName"].ToString();
                    lb3.Text = "Order Time: " + dtTblMain.Rows[i]["aTime"].ToString();
                    lb4.Text = "Order Type: " + dtTblMain.Rows[i]["orderType"].ToString();

                    p2.Controls.Add(lb1);
                    p2.Controls.Add(lb2);
                    p2.Controls.Add(lb3);
                    p2.Controls.Add(lb4);

                    p1.Controls.Add(p2);


                    //Add Product
                    //Vi MaBill trong database bat dau tu 0 , nen dung UINT de dung duoc nhieu gia tri hon
                    int MaBill = 0;
                    MaBill = Convert.ToInt32(dtTblMain.Rows[i]["MaBill"].ToString());
                    DataSet ds2= new DataSet();
                    try
                    {
                       ds2 = dbTblMain.GetJoin(MaBill);
                    }
                    catch (SqlException error)
                    {
                        MessageBox.Show(error.Message) ;
                    }
                    
                    dtTblJoin = ds2.Tables[0];
                    for (int j = 0; j < dtTblJoin.Rows.Count; j++)
                    {
                        Label lb5 = new Label();
                        lb5.ForeColor = Color.Black;
                        lb5.Margin = new Padding(10, 5, 3, 0);
                        lb5.AutoSize = true;
                        int no = j + 1;
                        lb5.Text = "" + no + " " + dtTblJoin.Rows[j]["proName"].ToString() + " " + dtTblJoin.Rows[j]["qty"].ToString();

                   //     Console.WriteLine(lb5.Text);
                        p1.Controls.Add(lb5);
                    }


                    //Add button to change the status
                    Guna.UI2.WinForms.Guna2Button bComplete = new Guna.UI2.WinForms.Guna2Button();
                    bComplete.AutoRoundedCorners = true;
                    bComplete.Size = new Size(100, 35);
                    bComplete.FillColor = Color.FromArgb(241, 85, 126);
                    bComplete.Margin = new Padding(40, 5, 3, 10);
                    bComplete.Text = "Complete";
                    bComplete.Tag = dtTblMain.Rows[i]["MaBill"].ToString(); //store the id
                    bComplete.Click += new EventHandler(b_click);
                    p1.Controls.Add(bComplete);

                    Guna.UI2.WinForms.Guna2Button bPrint = new Guna.UI2.WinForms.Guna2Button();
                    bPrint.AutoRoundedCorners = true;
                    bPrint.Size = new Size(100, 35);
                    bPrint.FillColor = Color.FromArgb(83, 164, 226);
                    bPrint.Margin = new Padding(40, 5, 3, 10);
                    bPrint.Text = "Print";
                    bPrint.Tag = dtTblMain.Rows[i]["MaBill"].ToString(); //store the id
                    bPrint.Click += new EventHandler(bPrint_Click);
                    p1.Controls.Add(bPrint);

                    flowLayoutPanel1.Controls.Add(p1);

                }
            }

        }
        


        private void bPrint_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32((sender as Guna.UI2.WinForms.Guna2Button).Tag.ToString()); // Lất mã Bill
            DataSet dataSet = new DataSet();

            // Lấy dữ liệu từ phương thức GetMain
            DataTable mainTable = dbTblMain.GetMain(ID).Tables[0].Copy() ;
            mainTable.Columns.Add("FormattedDate", typeof(string));
            foreach (DataRow row in mainTable.Rows)
            {
                DateTime aDate = Convert.ToDateTime(row["aDate"]);
                string formattedDate = aDate.ToString("yyyy-MM-dd");
                row["FormattedDate"] = formattedDate;
            }
            mainTable.Columns.Remove("aDate");
            mainTable.Columns["FormattedDate"].ColumnName = "aDate";
            mainTable.TableName = "tblMain";
            dataSet.Tables.Add(mainTable);

            // Lấy dữ liệu từ phương thức GetDetails
            DataTable detailsTable = dbTblDetail.GetDetails(ID).Tables[0].Copy();
            detailsTable.TableName = "tblDetails";
            dataSet.Tables.Add(detailsTable);
            frmPrint frm = new frmPrint();
            rptKitchen cr = new rptKitchen();
            cr.SetDataSource(dataSet);
            frm.crystalReportViewer1.ReportSource = cr;
            frm.crystalReportViewer1.Refresh();
            frm.Show(); 
            /*dtTblJoin.Clear();
            dtTblJoin = dbTblMain.GetJoinKIT(ID).Tables[0].Copy();
            dtTblJoin.Columns.Add("FormattedDate", typeof(string));

            foreach (DataRow row in dtTblJoin.Rows)
            {
                DateTime aDate = Convert.ToDateTime(row["aDate"]);
                string formattedDate = aDate.ToString("yyyy-MM-dd");
                row["FormattedDate"] = formattedDate;
            }

            // Loại bỏ cột cũ nếu cần
            dtTblJoin.Columns.Remove("aDate");

            // Đổi tên cột mới thành tên cột gốc nếu cần
        //    dtTblJoin.Columns["FormattedDate"].ColumnName = "aDate";


            // Tạo bảng tạm thời để lưu trữ các dòng dữ liệu duy nhất
            DataTable distinctTable = dtTblJoin.DefaultView.ToTable(true, dtTblJoin.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray());

            // Đổi tên cột mới thành tên cột gốc nếu cần
            distinctTable.Columns["FormattedDate"].ColumnName = "aDate";
            //    DataTable dtDistinct = dtTblJoin.DefaultView.ToTable(true, "qty", "proName");
            // Tạo bảng dữ liệu mới chỉ chứa các cột cần thiết cho section 3
            *//*            DataTable dtDetails = new DataTable();
                        dtDetails.Columns.Add("proName", typeof(string));
                        dtDetails.Columns.Add("qty", typeof(int));

                        foreach (DataRow row in dtTblJoin.Rows)
                        {
                            string proName = row["proName"].ToString();
                            int qty = Convert.ToInt32(row["qty"]);
                            dtDetails.Rows.Add(proName, qty);
                        }*//*
            frmPrint frm = new frmPrint();
            rptKitchen cr = new rptKitchen();
           // cr.SetDataSource(dtTblJoin);
            cr.SetDataSource(distinctTable);
            //  cr.Database.Tables["tblDetails"].SetDataSource(dtDetails);
            frm.crystalReportViewer1.ReportSource = cr;
            frm.crystalReportViewer1.Refresh();
            frm.Show();*/


            /*
                        //   dtTblJoin.Columns["aDate"].Expression = "aDate.ToShortDateString()";
                        // Create a DataView to remove duplicates
                        DataView view = new DataView(dtTblJoin);
                        dtTblJoin = view.ToTable(true, dtTblJoin.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray());
                        DataTable distinctTable = dtTblJoin.Clone(); // Tạo một bảng mới có cấu trúc giống dtTblJoin

                        // List để lưu các giá trị proID đã thêm vào distinctTable
                        List<string> addedProductIDs = new List<string>();

                        foreach (DataRow row in dtTblJoin.Rows)
                        {
                            string proID = row["proID"].ToString();

                            // Kiểm tra nếu proID chưa tồn tại trong danh sách
                            if (!addedProductIDs.Contains(proID))
                            {
                                // Thêm dòng vào distinctTable
                                DataRow newRow = distinctTable.NewRow();
                                newRow.ItemArray = row.ItemArray; // Sao chép dữ liệu từ dòng gốc sang dòng mới
                                distinctTable.Rows.Add(newRow);

                                // Thêm proID vào danh sách
                                addedProductIDs.Add(proID);
                            }
                        }*/

            /*        var groupedRows = dtTblJoin.AsEnumerable()
            .GroupBy(row => new { proName = row.Field<string>("proName"), qty = row.Field<int>("qty") })
            .Select(group => group.First()); // Select the first row from each group

                    // Create a new DataTable for unique rows
                    DataTable uniqueRowsTable = dtTblJoin.Clone();

                    // Add the unique rows to the new DataTable
                    foreach (var row in groupedRows)
                    {
                        uniqueRowsTable.ImportRow(row);
                    }
                    frmPrint frm = new frmPrint();
                    rptKitchen cr = new rptKitchen();
                    cr.SetDataSource(uniqueRowsTable);
                    //     cr.SetDataSource(dtDistinct);
                    frm.crystalReportViewer1.ReportSource = cr;
                    frm.crystalReportViewer1.Refresh();
                    frm.Show();*/

            // DataView dv = new DataView(dtTblJoin);

            // Áp dụng varGrouped cho DataView



            /* int ID = Convert.ToInt32((sender as Guna.UI2.WinForms.Guna2Button).Tag.ToString()); // Lấy mã Bill

             // Lấy thông tin từ bảng tblMain
             dtTblMain.Clear();
             dtTblMain = dbTblMain.GetMain(ID).Tables[0].Copy();
         dtTblDetails = new DataTable();
             // Lấy thông tin từ bảng tblDetails

             dtTblDetails = dbTblDetail.GetDetails(ID).Tables[0].Copy();

             // Tạo một bảng mới để kết hợp thông tin từ tblMain và tblDetails
             DataTable dtCombined = new DataTable();
             dtCombined.Columns.Add("aDate", typeof(DateTime));
             dtCombined.Columns.Add("status", typeof(string));
             dtCombined.Columns.Add("orderType", typeof(string));
        //     dtCombined.Columns.Add("Total", typeof(decimal));
             dtCombined.Columns.Add("qty", typeof(int));
             dtCombined.Columns.Add("proName", typeof(string));

             // Lấy thông tin từ tblMain và thêm vào bảng mới
             DateTime aDate = Convert.ToDateTime(dtTblMain.Rows[0]["aDate"]);
             string status = dtTblMain.Rows[0]["status"].ToString();
             string orderType = dtTblMain.Rows[0]["orderType"].ToString();
           //  decimal totalAmount = Convert.ToDecimal(dtTblMain.Rows[0]["TotalAmount"]);

             foreach (DataRow row in dtTblDetails.Rows)
             {
                 int qty = Convert.ToInt32(row["Qty"]);
                 string proName = row["proName"].ToString();

                 dtCombined.Rows.Add(aDate, status, orderType,  qty, proName);
             }

             // Tạo và hiển thị báo cáo
             frmPrint frm = new frmPrint();
             rptKitchen cr = new rptKitchen();
             cr.SetDataSource(dtCombined);
             frm.crystalReportViewer1.ReportSource = cr;
             frm.crystalReportViewer1.Refresh();
             frm.Show();
         */

        }

        private void b_click(object sender, EventArgs e)
        {

            int ID = Convert.ToInt32((sender as Guna.UI2.WinForms.Guna2Button).Tag.ToString()); //Laysas Mã bill
            guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
            guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
            if (guna2MessageDialog1.Show("Are you sure you want to delete?") == DialogResult.Yes)
            {
                //Update status của record từ Pending thành complete ,
                if (dbTblMain.UpdateStatus(ID, ref err))
                {
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK; guna2MessageDialog1.Show("Saved Successfully");
                }
                //Load lại Order ( đơn vừa complete sẽ bi xóa
                GetOrders();
            }


        }
    }
}
