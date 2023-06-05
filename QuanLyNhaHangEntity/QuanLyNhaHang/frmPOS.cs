using QuanLyNhaHang.BS_layer;
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
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class frmPOS : Form
    {
        DataTable dtPOS = null;
        
        DataTable dtDM = null;
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

                dtDM = dbDM.LayDanhMuc();

                /* DataSet ds = dbDM.LayDanhMuc();
                 dtDM = ds.Tables[0];*/
                
                pnlCategory.Controls.Clear();
                if (dtDM.Rows.Count > 0)
                {

                    Guna.UI2.WinForms.Guna2Button allButton = new Guna.UI2.WinForms.Guna2Button();
                    allButton.FillColor = Color.FromArgb(50, 55, 89);
                    allButton.Size = new Size(130, 45);
                    allButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                    allButton.Text = "Tất cả";
                    allButton.TextAlign = HorizontalAlignment.Left;
                    allButton.Click += new EventHandler(_Click); // Gắn sự kiện click cho nút "Tất cả"
                    pnlCategory.Controls.Add(allButton);
                    foreach (DataRow row in dtDM.Rows)
                    {

                        Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                        b.FillColor = Color.FromArgb(50, 55, 89);
                        b.Size = new Size(130, 45);
                        b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                         b.Text = row["TenDM"].ToString();
                  //      b.Text = tendanhmuc;
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

                    if (obj.Equals(wdg.PId))
                    {

                        item.Cells["dgvQty"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) + 1;
                        item.Cells["dgvAmount"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) * double.Parse(item.Cells["dgvPrice"].Value.ToString());

                        GetTotal();
                        // dgvPOS.CurrentCell = item.Cells[0];
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
        private void LoadData()
        {

            LoadProducts();
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
            catch (SqlException error)
            {
                MessageBox.Show("Không lấy được các SẢN PHẨM trong Table SANPHAM. Lỗi rồi!!!" + error.Message);
            }

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

    }
}
