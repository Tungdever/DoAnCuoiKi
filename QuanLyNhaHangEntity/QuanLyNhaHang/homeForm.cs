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
    public partial class homeForm : Form
    {
        public homeForm()
        {
            InitializeComponent();
        }

        private void ptbHome_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            idx++;
            if (idx == images.Count)
            {
                idx = 0;
            }
            ptbHome.Image = images[idx];
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            idx--;
            if (idx < 0)
            {
                idx = images.Count - 1;
            }
            ptbHome.Image = images[idx];
        }
        List<Image> images = new List<Image>();
        int idx = 0;
        private void homeForm_Load(object sender, EventArgs e)
        {
            images.Add(global::QuanLyNhaHang.Properties.Resources._1);
            images.Add(global::QuanLyNhaHang.Properties.Resources._3);
            images.Add(global::QuanLyNhaHang.Properties.Resources._4);
            ptbHome.Image = images[0];
        }
    }
}
