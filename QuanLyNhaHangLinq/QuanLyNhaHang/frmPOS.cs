﻿using QuanLyNhaHang.BS_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class frmPOS : Form
    {

        DataTable dtPOS = null;
        Table<DANHMUC> dtDM = null;
        DataTable dtSP = null;
        DataTable dtTblMain = null;
        DataTable dtTblJoin = null;
        List<string> TenDanhMuc = null;
        string err;
        BLDanhMuc dbDM = new BLDanhMuc();
      //  BLPOS dbPOS = new BLPOS();
        BLSanPham dbSP = new BLSanPham();
         BLTblMain dbTblMain = new BLTblMain();
         BLTblDetail dbTblDetail = new BLTblDetail();
        BLTable dbTable = new BLTable();
        double total;
        public bool Them = true; // CHo khởi tạo ban đầu bằng true 
        public frmPOS()
        {
            InitializeComponent();
        }
        public int MainID = 0;
        public string OrderType = "";
        public string TableName = "";
        public string TableID = "";
        public DateTime Date;
        public DateTime Time;
        string DriverID;
        public int BillID = 0;
        public int DetailID;
        public string CustomerName = "";
        public string CustomerPhone = "";

        private void btnNew_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            //MainID = 0;
            Them = true;
            lblTotal.Text = "0.00";
            dgvPOS.Rows.Clear();
        }
        private void GetCategory()
        {
            try
            {
                //  dtDM = new DataTable();

                TenDanhMuc = dbDM.LayTenDanhMuc();
              
                /* DataSet ds = dbDM.LayDanhMuc();
                 dtDM = ds.Tables[0];*/
                
                pnlCategory.Controls.Clear();
                if (TenDanhMuc.Count > 0)
                {

                    Guna.UI2.WinForms.Guna2Button allButton = new Guna.UI2.WinForms.Guna2Button();
                    allButton.FillColor = Color.FromArgb(50, 55, 89);
                    allButton.Size = new Size(130, 45);
                    allButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                    allButton.Text = "Tất cả";
                    allButton.TextAlign = HorizontalAlignment.Left;
                    allButton.Click += new EventHandler(_Click); // Gắn sự kiện click cho nút "Tất cả"
                    pnlCategory.Controls.Add(allButton);
                    foreach ( string tendanhmuc in TenDanhMuc)
                    {
                        
                        Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                        b.FillColor = Color.FromArgb(50, 55, 89);
                        b.Size = new Size(130, 45);
                        b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                      //  b.Text = row.ToString();
                      b.Text = tendanhmuc;
                        b.TextAlign = HorizontalAlignment.Left;

                        //event for click
                        b.Click += new EventHandler(_Click);
                        pnlCategory.Controls.Add(b);
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được các danh mục trong TABLE DANHMUC. Lỗi rồi!!!");
            }
        }

        private void _Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button b = (Guna.UI2.WinForms.Guna2Button)sender;
            if (b.Text == "Tất cả")
            {
                foreach (var item in pnlProduct.Controls)
                {
                    var pro = (ucProduct)item;
                    pro.Visible = true; // Hiển thị tất cả các sản phẩm
                }
            }
            else // Lọc lấy các sản phẩm theo tên danh mục vd đồ ăn nhanh , món chính , rượu , bia
            {
                foreach (var item in pnlProduct.Controls)
                {
                    var pro = (ucProduct)item;
                    pro.Visible = pro.PCategory.ToLower().Contains(b.Text.Trim().ToLower());
                }
            }
        }

        private void AddItems(string id, string name, string cat, float price, Image pimage)
        {
            var w = new ucProduct()
            {
                PName = name, //Tên sản phẩm
                PPrice = price, //Gía
                PCategory = cat, // Tên loại sp ( Tên Danh mục)
                PImage = pimage,
                PId = id // Mã sp
            };
            pnlProduct.Controls.Add(w);

            //Nhấn vào ucProdcut bất kỳ sẽ đưa sản phẩm đó lên dgvPOS
            w.onSelect += (ss, ee) =>
            {
                var wdg = (ucProduct)ss;
                int d = dgvPOS.Rows.Count;
                foreach (DataGridViewRow item in dgvPOS.Rows)
                {
                    //Check if product already there then add one to quantity ad update price
                    object obj = item.Cells["dgvMaSP"].Value.ToString();
                    //     Console.WriteLine("*"+obj);
                    //    Console.WriteLine(obj.Equals(wdg.PId));
                    //  Console.WriteLine(obj + "><" + wdg.PId);
                    if (obj.Equals(wdg.PId))
                    {

                        item.Cells["dgvQty"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) + 1;
                        item.Cells["dgvAmount"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) * double.Parse(item.Cells["dgvPrice"].Value.ToString());
                        GetTotal();
                        //  total += double.Parse(item.Cells["dgvPrice"].Value.ToString());

                        return;// Thoát khỏi onSelct
                    }
                    //Nếu sản phẩm chưa có trong danh sách, thêm một dòng mới cho sản phẩm đó trong guna2DataGridView1.
                    //Add new Product

                }
                Console.WriteLine("0");
                //Đưa dữ liệu ( sản phẩm) vừa bấm lên dgvPOS
                //   dgvPOS.Rows.Add(new object[] { wdg.PId, wdg.PName, wdg.PCategory, 1, wdg.PPrice, wdg.PPrice });
                //Tác dụng của PCategory trong form này chỉ có duy nhất để visible các sản phẩm theo tên danh mục ứng với button ấn vào
                //       s = false;
                dgvPOS.Rows.Add(new object[] { 0, wdg.PId, wdg.PName, 1, wdg.PPrice, wdg.PPrice });
                //Số 0 đầu tiên là DetailID , ta mặc định khi ấn chọn sản phẩm , DetailID đưa lên dgvPOS là 0 nhưng 0 qtrong lắm , vì khi chỉnh sửa là lúc database trong tblDetails đổ xuốngdgvPOS 
                //Gía trị trong cột dgvDetailID của dgvPOS sẽ trở nên khác ( vì trong tblDetails , cột DetailID là Indetity nên tự động sinh giá trị mỗi khi thêm record

                GetTotal();
                //   MessageBox.Show(lblTable.Text);
            };

        }

        private void frmPOS_Load(object sender, EventArgs e)
        {

            this.dgvPOS.BorderStyle = BorderStyle.FixedSingle;
            pnlCategory.Controls.Clear();
            pnlProduct.Controls.Clear();
            GetCategory();
            LoadData();
            Date = DateTime.Now;
            Time = DateTime.Now;
            DTPTime.Value = Time;
            DPTDate.Value = Date;
        }

        private void LoadProducts()
        {
            try
            {
                dtPOS = new DataTable();
                dtPOS.Clear();

                // DataSet ds = dbSP.GetProducts();
                //  dtPOS = ds.Tables[0]; // 
                List<SANPHAM> Pros = dbSP.GetProducts();

                foreach (SANPHAM Pro in Pros)
                {
                    Byte[] imagearray = (byte[])Pro.AnhSP.ToArray();
                    byte[] imagebytearray = imagearray;
                    AddItems(Pro.MaSP, Pro.TenSP, Pro.TenLoaiSP, (float)Pro.GiaSP.GetValueOrDefault(), Image.FromStream(new MemoryStream(imagearray)));
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được các SẢN PHẨM trong Table SANPHAM. Lỗi rồi!!!");
            }

        }
        private void LoadData()
        {

            LoadProducts();
        }
        private void GetTotal()
        {
            total = 0;
            //  lblTable.Text = "";
            foreach (DataGridViewRow item in dgvPOS.Rows)
            {
                total += double.Parse(item.Cells["dgvAmount"].Value.ToString());
            }
            lblTotal.Text = total.ToString("N2");
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in pnlProduct.Controls)
            {
                var pro = (ucProduct)item;
                pro.Visible = pro.PName.ToLower().Contains(txtSearchProduct.Text.Trim().ToLower());
            }
        }

        private void btnHold_Click(object sender, EventArgs e)
        {
            int detailID = 0;
            if (OrderType == "")
            {
                guna2MessageDialog1.Show("Please select order");
                return;
            }
            if (Them)
            {
                //Cột MaBill tu dong sinh gia tri

                //Cap nhat gia tri dong hien tai nho SELECT_SCOPE_INDENTITY
                BillID = dbTblMain.AddTblMain(Convert.ToDateTime(Date), Time.ToShortTimeString(),
                     lblTable.Text, lblWaiter.Text, "Hold", OrderType, Convert.ToDouble(lblTotal.Text), Convert.ToDouble(0), Convert.ToDouble(0), DriverID, CustomerName, CustomerPhone, ref err);
                // Thay vì như mặc định Hàm AddTblMain trả về true , false, ở đây nó trả về giá trị Bill Id của đơn hiện tại vừa thêm vào
                if (BillID > 0)
                    MessageBox.Show("Đã thêm xong!");
                else
                    MessageBox.Show("Không thêm được.Lỗi rồi!" + err);

            }
            else
            {
                dbTblMain.UpdateTblMain(BillID, Convert.ToDateTime(Date), Time.ToShortTimeString(),
                        lblTable.Text, lblWaiter.Text, "Hold", OrderType, Convert.ToDouble(lblTotal.Text), Convert.ToDouble(0), Convert.ToDouble(0), ref err);
                MessageBox.Show("Đã sửa xong!");
            }
            foreach (DataGridViewRow row in dgvPOS.Rows)
            {
                detailID = Convert.ToInt32(row.Cells["dgvDetailID"].Value); //
               
                if (detailID == 0)
                {
                    try
                    {
                        dbTblDetail.AddTblDetail(BillID, row.Cells["dgvMaSP"].Value.ToString(), row.Cells["dgvTenSP"].Value.ToString(), int.Parse(row.Cells["dgvQty"].Value.ToString()), float.Parse(row.Cells["dgvPrice"].Value.ToString()), float.Parse(row.Cells["dgvAmount"].Value.ToString()), ref err);

                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Không thêm được. Lỗi rồi!");
                    }
                }
                else // Gía trị trong cột dgvDetailID của dgvPOS đã ko còn là 0 mà là giá trị từ tblDetail đổ xuống ( vì khi này là chỉnh sửa , tức giá trị detailID đó đã có trong database
                {
                    //Lấy dữ liệu trong dgvPOS update lên dbTblDetail
                    dbTblDetail.UpdateTblDetail(Convert.ToInt32(row.Cells["dgvDetailID"].Value), BillID, row.Cells["dgvMaSP"].Value.ToString(), row.Cells["dgvTenSP"].Value.ToString(), int.Parse(row.Cells["dgvQty"].Value.ToString()), float.Parse(row.Cells["dgvPrice"].Value.ToString()), float.Parse(row.Cells["dgvAmount"].Value.ToString()), ref err);
                    MessageBox.Show("Đã sửa xong!");
                }
            }
            guna2MessageDialog1.Show("Saved Successfully");
            //    MainID = 0;
            detailID = 0;
            dgvPOS.Rows.Clear();
            lblTable.Text = "";
            lblDriverName.Text = "";
            lblWaiter.Text = "";
            //     lblDriverName.Visible = false;
            lblWaiter.Visible = false;
            lblTotal.Text = "00";

            //    this.Close();
            Them = true;
        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            frmBillList frm = new frmBillList();
            frm.ShowDialog();


            //Sau khi frm đóng
            if (frm.MainID > 0)
            {
                // Ra khỏi form Bill List 
                Them = frm.bonus; //  Them  = false lúc này sẽ hiển thị Bill cần sửa lên dgvPOS
                BillID = frm.MainID;
                OrderType = frm.OrderType; //Lấy ordertype để xác định có phải din in ko , nếu là din in thì inner join với BAN để lấy idTable
                LoadEntries();
                //  LoadData();

            }
        }
        private void LoadEntries()
        {
            try
            {
                dtTblJoin = new DataTable();
                dtTblJoin.Clear();
               // DataSet ds = new DataSet();
                if (OrderType.Equals("Din in"))
                {
               //     ds = dbTblMain.GetJoinTABLE(BillID);
                    dtTblJoin = dbTblMain.GetJoinTABLE(BillID);
                    TableName = dtTblJoin.Rows[0]["Tname"].ToString();
                    TableID = dtTblJoin.Rows[0]["Tid"].ToString();
                    btnDinIn.Checked = true;
                    lblWaiter.Visible = true;
                    lblTable.Visible = true;
                }
                else
                {
                   // ds = dbTblMain.GetJoin(BillID);
                    dtTblJoin = dbTblMain.GetJoin(BillID);
                }


                //Lay Du lieu cua BillID
                if (dtTblJoin.Rows[0]["orderType"].ToString() == "Delivery")
                {
                    btnDelivery.Checked = true;
                    lblWaiter.Visible = false;
                    lblTable.Visible = false;
                }
                else if (dtTblJoin.Rows[0]["orderType"].ToString() == "Take away")
                {
                    btnTakeAway.Checked = true; lblWaiter.Visible = false;
                    lblTable.Visible = false;
                }

                dgvPOS.Rows.Clear();
                foreach (DataRow item in dtTblJoin.Rows)
                {
                    lblTable.Text = item["TableName"].ToString();
                    lblWaiter.Text = item["WaiterName"].ToString();
                    string detailIDD = item["DetailID"].ToString();
                    string proName = item["proName"].ToString();
                    string proID = item["proID"].ToString();
                    string qty = item["qty"].ToString();
                    string price = item["price"].ToString();
                    string amount = item["amount"].ToString();
                    object[] obj = { detailIDD, proID, proName, qty, price, amount };
                    dgvPOS.Rows.Add(obj);
                }

                GetTotal();

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được các SẢN PHẨM trong Table SANPHAM. Lỗi rồi!!!");
            }


        }
    }
}