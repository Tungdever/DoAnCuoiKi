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
    public partial class frmKitchen : Form
    {
        BLTblMain dbTblMain = new BLTblMain();
        List<tblMain> OrderList = null;
        DataTable dtTblJoin = null;
        string err;
        public frmKitchen()
        {
            InitializeComponent();
        }
        private void GetOrders()
        {
            flowLayoutPanel1.Controls.Clear();

          /*  DataSet ds = dbTblMain.GetOrders();
            dtTblMain = ds.Tables[0];*/
            OrderList = dbTblMain.GetOrders();
            FlowLayoutPanel p1;
            //if (dtTblMain.Rows.Count > 0)
            if(OrderList.Count > 0)
            {
               // for (int i = 0; i < dtTblMain.Rows.Count; i++)
                for(int i= 0; i < OrderList.Count; i++) 
                {
                    //Thêm các tiêu đề bằng label
                    p1 = new FlowLayoutPanel();
                    p1.AutoSize = true;
                    p1.Width = 300;
                    p1.Height = 600;
                    p1.FlowDirection = FlowDirection.TopDown;
                    p1.BorderStyle = BorderStyle.FixedSingle;
                    p1.Margin = new Padding(10, 10, 10, 10);

                    FlowLayoutPanel p2 = new FlowLayoutPanel();
                    p2 = new FlowLayoutPanel();
                    p2.BackColor = Color.FromArgb(50, 55, 89);
                    p2.AutoSize = true;
                    p2.Width = 300;
                    p2.Height = 130;
                    p2.FlowDirection = FlowDirection.TopDown;
                    p2.BorderStyle = BorderStyle.FixedSingle;
                    p2.Margin = new Padding(0, 0, 0, 0);
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



                    /*        lb1.Text = "Table: " + dtTblMain.Rows[i]["TableName"].ToString();
                            lb2.Text = "Waiter Name: " + dtTblMain.Rows[i]["WaiterName"].ToString();
                            lb3.Text = "Order Time: " + dtTblMain.Rows[i]["aTime"].ToString();
                            lb4.Text = "Order Type: " + dtTblMain.Rows[i]["orderType"].ToString();*/
                    lb1.Text = "Table: " + OrderList[i].TableName.ToString();
                    lb2.Text = "Waiter Name: " + OrderList[i].WaiterName.ToString();
                    lb3.Text = "Order Time: " + OrderList[i].aTime.ToString();
                    lb4.Text = "Order Type: " + OrderList[i].orderType.ToString();
                    p2.Controls.Add(lb1);
                    p2.Controls.Add(lb2);
                    p2.Controls.Add(lb3);
                    p2.Controls.Add(lb4);

                    p1.Controls.Add(p2);


                    //Add Product
                    //Vi MaBill trong database bat dau tu 0 , nen dung UINT de dung duoc nhieu gia tri hon
                    int MaBill = 0;
                  //  MaBill = Convert.ToInt32(dtTblMain.Rows[i]["MaBill"].ToString());
                    MaBill = Convert.ToInt32(OrderList[i].MaBill.ToString());
                  // DataSet ds2 = new DataSet();
                    try
                    {
                        //  ds2 = dbTblMain.GetJoin(MaBill);
                        dtTblJoin =  dbTblMain.GetJoin(MaBill);
                    }
                    catch (SqlException error)
                    {
                        MessageBox.Show(error.Message);
                    }

                    //dtTblJoin = ds2.Tables[0];
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
                    //   bComplete.Tag = dtTblMain.Rows[i]["MaBill"].ToString(); //store the id
                    bComplete.Tag = MaBill.ToString();
                    bComplete.Click += new EventHandler(b_click);
                    p1.Controls.Add(bComplete);

                    Guna.UI2.WinForms.Guna2Button bPrint = new Guna.UI2.WinForms.Guna2Button();
                    bPrint.AutoRoundedCorners = true;
                    bPrint.Size = new Size(100, 35);
                    bPrint.FillColor = Color.FromArgb(83, 164, 226);
                    bPrint.Margin = new Padding(40, 5, 3, 10);
                    bPrint.Text = "Print";
                    //  bPrint.Tag = dtTblMain.Rows[i]["MaBill"].ToString(); //store the id
                    bPrint.Tag = MaBill.ToString();
                    bPrint.Click += new EventHandler(bPrint_Click);
                    p1.Controls.Add(bPrint);

                    flowLayoutPanel1.Controls.Add(p1);
                }
            }

        }

        private void b_click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32((sender as Guna.UI2.WinForms.Guna2Button).Tag.ToString());
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

        private void bPrint_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32((sender as Guna.UI2.WinForms.Guna2Button).Tag.ToString());
            dtTblJoin = new DataTable();
            dtTblJoin.Clear();
            dtTblJoin = dbTblMain.GetJoinRP(ID);
            frmPrint frm = new frmPrint();
            rptKitChen cr = new rptKitChen();
            cr.SetDataSource(dtTblJoin);
            frm.crystalReportViewer1.ReportSource = cr;
            frm.crystalReportViewer1.Refresh();
            frm.Show();
        }

        private void frmKitchen_Load(object sender, EventArgs e)
        {
            GetOrders();
        }
    }
}
