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
    public partial class ucClock : UserControl
    {

        public ucClock()
        {
            InitializeComponent();
        }
        public int ClockRadius
        {
            get { return ptbClock.Size.Width; }
            set { }
        }

        private void ucClock_Load(object sender, EventArgs e)
        {

        }
    }
}
