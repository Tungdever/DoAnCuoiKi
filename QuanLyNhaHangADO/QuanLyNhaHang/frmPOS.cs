using QuanLyNhaHang.BS_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        string err;
        BLDanhMuc dbDM = new BLDanhMuc();
        BLPOS dbPOS = new BLPOS();
        BLSanPham dbSP = new BLSanPham();
        double total;
        public frmPOS()
        {
            InitializeComponent();
        }
        public int MainID = 0;
        public string OrderType;

        private void PtbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            this.dgvPOS.BorderStyle = BorderStyle.FixedSingle;
            pnlCategory.Controls.Clear();
            pnlProduct.Controls.Clear();
            GetCategory();

            LoadData();
        }
        private void GetCategory()
        {
            dtDM = new DataTable();
            dtDM.Clear();
            DataSet ds = dbDM.LayDanhMuc();
            dtDM = ds.Tables[0];
            pnlCategory.Controls.Clear();
            if (dtDM.Rows.Count > 0)
            {
                foreach (DataRow row in dtDM.Rows)
                {
                    Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                    b.FillColor = Color.FromArgb(50, 55, 89);
                    b.Size = new Size(180, 45);
                    b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                    b.Text = row["TenDM"].ToString();
                    b.TextAlign = HorizontalAlignment.Left;

                    //event for click
                    b.Click += new EventHandler(_Click);
                    pnlCategory.Controls.Add(b);
                }
            }
        }

        private void _Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button b = (Guna.UI2.WinForms.Guna2Button)sender;
            foreach (var item in pnlProduct.Controls)
            {
                var pro = (ucProduct)item;
                pro.Visible = pro.PCategory.ToLower().Contains(b.Text.Trim().ToLower());
            }
        }

        private void AddItems(string id, string name, string cat, float price, Image pimage)
        {
            var w = new ucProduct()
            {
                PName = name, //Tên sản phẩm
                PPrice = price, //Gía
                PCategory = cat, // Tên loại sp
                PImage = pimage,
                PId = id // Mã sp
            };
            pnlProduct.Controls.Add(w);
            //Nhấn vào ucProdcut bất kỳ
            w.onSelect += (ss, ee) =>
            {
                var wdg = (ucProduct)ss;
                foreach (DataGridViewRow item in dgvPOS.Rows)
                {
                    //Check if product already there then add one to quantity ad update price
                    object obj = item.Cells["dgvMaSP"].Value;
                    if (obj == wdg.PId)
                    {
                        item.Cells["dgvQty"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) + 1;
                        item.Cells["dgvAmount"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) * double.Parse(item.Cells["dgvPrice"].Value.ToString());
                        GetTotal();
                        //  total += double.Parse(item.Cells["dgvPrice"].Value.ToString());
                        return;// Thoát khỏi AddItem
                    }
                    //Nếu sản phẩm chưa có trong danh sách, thêm một dòng mới cho sản phẩm đó trong guna2DataGridView1.
                    //Add new Product

                }
                dgvPOS.Rows.Add(new object[] { wdg.PId, wdg.PName, wdg.PCategory, 1, wdg.PPrice, wdg.PPrice });
                GetTotal();
            };

        }
        private void LoadProducts()
        {
            dtPOS = new DataTable();
            dtPOS.Clear();
            DataSet ds = dbPOS.GetProducts();
            dtPOS = ds.Tables[0];
            foreach (DataRow item in dtPOS.Rows)
            {
                Byte[] imagearray = (byte[])item["AnhSP"];
                byte[] imagebytearray = imagearray;
                AddItems(item["MaSP"].ToString(), item["TenSP"].ToString(), item["TenLoaiSP"].ToString(), float.Parse(item["GiaSP"].ToString()), Image.FromStream(new MemoryStream(imagearray)));
            }




        }
        private void LoadData()
        {

            LoadProducts();
        }
        private void GetTotal()
        {
            total = 0;
            lblTable.Text = "";
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible   = false;
            MainID = 0;
            lblTotal.Text = "0.00";
            dgvPOS.Rows.Clear();    
        }

        private void btnHold_Click(object sender, EventArgs e)
        {

        }

        private void btnBillList_Click(object sender, EventArgs e)
        {

        }

        private void btnKOT_Click(object sender, EventArgs e)
        {

        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            OrderType = "Delivery";
        }

        private void btnTakeAway_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            OrderType = "Take Away";
        }

        private void btnDinIn_Click(object sender, EventArgs e)
        {
            //create form for Table select n waiter selec

        }
    }
}
