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
    public partial class frmKitchen : Form
    {
        BLTblMain dbTblMain = new BLTblMain();
        DataTable dtTblMain = null;
        DataTable dtTblJoin = null;
        string err;
        public frmKitchen()
        {
            InitializeComponent();
        }
    }
}
