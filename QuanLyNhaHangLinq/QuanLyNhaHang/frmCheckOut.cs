using QuanLyNhaHang.BS_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class frmCheckOut : Form
    {
        BLTblMain dbTblMain = new BLTblMain();
        public frmCheckOut()
        {
            InitializeComponent();
        }
        public double amt = 0;
        public double received = 0;
        public double change = 0;
        public int billID = 0;
        public string err;
        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtReceived_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(txtBillAmount.Text, out amt);
            double.TryParse(txtReceived.Text, out received);
            change = Math.Abs(amt - received);
            txtChange.Text = change.ToString();
        }

        private void frmCheckOut_Load(object sender, EventArgs e)
        {
            txtBillAmount.Text = amt.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dbTblMain.UpdateCheckOut(billID, amt, received, change, "Paid", ref err))
            {
                //   guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Show("Saved Successfully");
                this.Close();
            }
            else
                MessageBox.Show(err);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
