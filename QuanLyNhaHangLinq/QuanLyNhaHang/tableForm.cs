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
    public partial class tableForm : Form
    {
        string err;
        BLTable dbT = new BLTable();
        public tableForm()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                dgvTable.DataSource = dbT.LayTable();
                dgvTable.AutoResizeColumns();

            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi rồi!!!");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmTableAdd frm = new frmTableAdd();
            frm.lblAdd.Text = "Table Add";
            frm.txtTableID.ReadOnly = false;
            frm.txtTableName.ReadOnly = false;
            frm.ShowDialog();
            LoadData();
        }

        private void tableForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtSearchTable_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvTable.DataSource = dbT.TimKiemTable(txtSearchTable.Text);
                // Thay đổi độ rộng cột
                dgvTable.AutoResizeColumns();
            }
            catch(SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table BAN. Lỗi rồi!!!");
            }
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvTable.CurrentCell.OwningColumn.Name == "dgvEdit")
                {
                    frmTableAdd frm = new frmTableAdd();
                    List<string> listTstate = new List<string>();
                    listTstate.Add("Ban trong");
                    listTstate.Add("Da dat");
                    frm.cbbTstate.DataSource = listTstate;
                    frm.txtTableID.Text = dgvTable.CurrentRow.Cells["dgvTid"].Value.ToString();
                    frm.txtTableName.Text = dgvTable.CurrentRow.Cells["dgvTname"].Value.ToString();
                    frm.cbbTstate.Text = dgvTable.CurrentRow.Cells["dgvTstate"].Value.ToString();
                    frm.lblAdd.Text = "Table Edit";
                    frm.ShowDialog();
                    LoadData();
                }
                else if (dgvTable.CurrentCell.OwningColumn.Name == "dgvDel")
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xoá dòng này không?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        dbT.XoaTable(dgvTable.CurrentRow.Cells["dgvTid"].Value.ToString(), ref err);
                        LoadData();
                        MessageBox.Show("Xoá thành công!");
                    }
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!");
            }
        }
    }
}
