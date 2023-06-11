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
using System.Xml.Linq;

namespace QuanLyNhaHang
{
    public partial class frmTableAdd : Form
    {
        string err;
        BLTable dbT = new BLTable();
        public frmTableAdd()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTableID.Text.Trim() == "" || txtTableName.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!!!");
                return;
            }
            if (txtTableID.ReadOnly == true)
            {
                if (dbT.CapNhatTable(txtTableID.Text, txtTableName.Text, cbbTstate.Text, ref err))
                {

                    MessageBox.Show("Đã sửa xong!");
                }
                else
                {
                    MessageBox.Show("Sửa không thành công. Lỗi: '" + err + "'");
                }
            }
            else
            {

                if (dbT.ThemTable(txtTableID.Text, txtTableName.Text, cbbTstate.Text, ref err))
                {

                    MessageBox.Show("Đã thêm xong!");
                }
                else
                {
                    MessageBox.Show("Thêm không thành công. Lỗi: '" + err + "'");
                }

            } 
            this.Close();
        }
    }
}
