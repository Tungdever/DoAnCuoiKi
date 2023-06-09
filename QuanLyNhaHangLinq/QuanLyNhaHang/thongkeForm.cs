using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using QuanLyNhaHang.BS_layer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyNhaHang
{
    public partial class thongkeForm : Form
    {
        BLTblMain dbMain = new BLTblMain();
        public thongkeForm()
        {
            InitializeComponent();

        }

        void loadPie()
        {

            bdt.Series.Clear();
            bdt.Series.Add("s1");
            bdt.Series["s1"].ChartType = SeriesChartType.Pie;
            string dt1 = dbMain.doanhthu("Din in", cbbMonth.Text, cbbYear.Text);
            string dt2 = dbMain.doanhthu("Take away", cbbMonth.Text, cbbYear.Text);
            string dt3 = dbMain.doanhthu("Delivery", cbbMonth.Text, cbbYear.Text);
            lbldt1.Text = dt1;
            lbldt2.Text = dt2;
            lbldt3.Text = dt3;
            bdt.Series["s1"].IsValueShownAsLabel = true;
            if (dt1 != "0") bdt.Series["s1"].Points.AddY(dt1);
            if (dt2 != "0") bdt.Series["s1"].Points.AddY(dt2);
            if (dt3 != "0") bdt.Series["s1"].Points.AddY(dt3);

            double total = bdt.Series["s1"].Points.Sum(point => point.YValues[0]);
            foreach (DataPoint point in bdt.Series["s1"].Points)
            {

                double value = point.YValues[0];
                double percentage = (value / total) * 100;
                point.Label = $"{percentage.ToString("0.##")}%";

            }
            int idx = 0;
            if (dt1 != "0") bdt.Series["s1"].Points[idx++].LegendText = "Doanh thu Din in";
            if (dt2 != "0") bdt.Series["s1"].Points[idx++].LegendText = "Doanh thu take away";
            if (dt3 != "0") bdt.Series["s1"].Points[idx++].LegendText = "Doanh thu delivery";
        }
        void loadSPLine()
        {
            bdd.AxisX.Clear();
            bdd.AxisY.Clear();
            bdd.Series.Clear();
            List<string> dtDinin = new List<string>();
            List<string> dtTW = new List<string>();
            List<string> dtDelivery = new List<string>();
            for (int i = 1; i <= 12; i++)
            {
                dtDinin.Add(dbMain.doanhthu("Din in", i.ToString(), cbbYear.Text));
                dtTW.Add(dbMain.doanhthu("Take away", i.ToString(), cbbYear.Text));
                dtDelivery.Add(dbMain.doanhthu("Delivery", i.ToString(), cbbYear.Text));
            }
            bdd.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Tháng",
                Labels = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" }
            });
            bdd.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Doanh thu",

            });
            bdd.AxisX[0].MinValue = 1;
            bdd.AxisX[0].MaxValue = 12;
            bdd.AxisY[0].MinValue = 0;
            bdd.LegendLocation = LiveCharts.LegendLocation.Right;
            LiveCharts.SeriesCollection s = new LiveCharts.SeriesCollection();
            LiveCharts.ChartValues<LiveCharts.Defaults.ObservablePoint> values1 = new LiveCharts.ChartValues<LiveCharts.Defaults.ObservablePoint>();
            for (int i = 0; i < dtDinin.Count; i++)
            {
                double doanhThu = double.Parse(dtDinin[i]);
                values1.Add(new LiveCharts.Defaults.ObservablePoint(i + 1, doanhThu));
            }
            s.Add(new LiveCharts.Wpf.LineSeries
            {
                Title = "Doanh thu Din in",
                Values = values1,
                PointGeometrySize = 15
            });
            LiveCharts.ChartValues<LiveCharts.Defaults.ObservablePoint> values2 = new LiveCharts.ChartValues<LiveCharts.Defaults.ObservablePoint>();
            for (int i = 0; i < dtDinin.Count; i++)
            {
                double doanhThu = double.Parse(dtTW[i]);
                values2.Add(new LiveCharts.Defaults.ObservablePoint(i + 1, doanhThu));
            }
            s.Add(new LiveCharts.Wpf.LineSeries
            {
                Title = "Doanh thu Take away",
                Values = values2,
                PointGeometrySize = 15
            });
            LiveCharts.ChartValues<LiveCharts.Defaults.ObservablePoint> values3 = new LiveCharts.ChartValues<LiveCharts.Defaults.ObservablePoint>();
            for (int i = 0; i < dtDinin.Count; i++)
            {
                double doanhThu = double.Parse(dtDelivery[i]);
                values3.Add(new LiveCharts.Defaults.ObservablePoint(i + 1, doanhThu));
            }
            s.Add(new LiveCharts.Wpf.LineSeries
            {
                Title = "Doanh thu Delivery",
                Values = values3,
                PointGeometrySize = 15
            });
            bdd.Series = s;

        }
        private void thongkeForm_Load(object sender, EventArgs e)
        {
            loadPie();
            loadSPLine();
        }

        private void cbbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadPie();
        }

        private void cbbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadPie();
            loadSPLine();
        }


    }
}
