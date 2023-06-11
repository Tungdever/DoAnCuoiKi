using QuanLyNhaHang.BS_layer;
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
    public partial class frmCustomerAdd : Form
    {
        public frmCustomerAdd()
        {
            InitializeComponent();
        }
        DataTable dtDriver = null;
        BLNhanVien dbDriver = new BLNhanVien();
        public string orderType = "";
        public int billID = 0;

        public string cusName = "";
        public string cusPhone = "";
        //  public int driverID = 0;
        public string driverID;

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Saved");
            this.Close();
        }

        private void frmCustomerAdd_Load(object sender, EventArgs e)
        {
            if (orderType == "Take Away")
            {
                cbbDriver.Visible = false;
                lblDriver.Visible = false;

            }
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                dtDriver = new DataTable();
                dtDriver.Clear();
           //     DataSet ds = dbDriver.LayGiaoHang();
              //  dtDriver = ds.Tables[0];
              List<NHANVIEN> ds = dbDriver.LayGiaoHang();
                List<string> danhSachNVGiaoHang = new List<string>();
                foreach ( NHANVIEN nv in ds)
                {
                  
                    danhSachNVGiaoHang.Add(nv.Ten);
                }
                cbbDriver.DataSource = danhSachNVGiaoHang;


                // cbbDriver.DataSource = dbDriver.LayGiaoHang();

                if (billID > 0)
                {
                    cbbDriver.SelectedValue = driverID;
                    //driverID = cbbDriver.SelectedValue.ToString(); 
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("Không lấy được nội dung. Lỗi: " + e);
            }
        }

        private void cbbDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            driverID = cbbDriver.SelectedValue.ToString();
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            cusName = txtCustomerName.Text;
        }

        private void txtCustomerPhone_TextChanged(object sender, EventArgs e)
        {
            cusPhone = txtCustomerPhone.Text;
        }
    }
}
