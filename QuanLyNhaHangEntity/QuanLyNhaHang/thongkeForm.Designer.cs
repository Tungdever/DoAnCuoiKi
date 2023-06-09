using System.Drawing;

namespace QuanLyNhaHang
{
    partial class thongkeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbldt3 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbldt2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbldt1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.bdt = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cbbMonth = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbbYear = new Guna.UI2.WinForms.Guna2ComboBox();
            this.bdd = new LiveCharts.WinForms.CartesianChart();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdt)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1718, 373);
            this.panel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(52, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 38);
            this.label6.TabIndex = 5;
            this.label6.Text = "Revenue";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(929, 354);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Chọn năm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 354);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Chọn tháng";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.HotPink;
            this.panel4.Controls.Add(this.lbldt3);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(1123, 54);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(501, 222);
            this.panel4.TabIndex = 2;
            // 
            // lbldt3
            // 
            this.lbldt3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbldt3.AutoSize = true;
            this.lbldt3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldt3.ForeColor = System.Drawing.Color.White;
            this.lbldt3.Location = new System.Drawing.Point(22, 129);
            this.lbldt3.Name = "lbldt3";
            this.lbldt3.Size = new System.Drawing.Size(121, 31);
            this.lbldt3.TabIndex = 3;
            this.lbldt3.Text = "Doanh thu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(22, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(295, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "Doanh thu delivery / month";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel3.Controls.Add(this.lbldt2);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(593, 54);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(501, 222);
            this.panel3.TabIndex = 1;
            // 
            // lbldt2
            // 
            this.lbldt2.AutoSize = true;
            this.lbldt2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldt2.ForeColor = System.Drawing.Color.White;
            this.lbldt2.Location = new System.Drawing.Point(34, 129);
            this.lbldt2.Name = "lbldt2";
            this.lbldt2.Size = new System.Drawing.Size(121, 31);
            this.lbldt2.TabIndex = 2;
            this.lbldt2.Text = "Doanh thu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(34, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(316, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Doanh thu take away / month";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Coral;
            this.panel2.Controls.Add(this.lbldt1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(59, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(501, 222);
            this.panel2.TabIndex = 0;
            // 
            // lbldt1
            // 
            this.lbldt1.AutoSize = true;
            this.lbldt1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldt1.ForeColor = System.Drawing.Color.White;
            this.lbldt1.Location = new System.Drawing.Point(26, 129);
            this.lbldt1.Name = "lbldt1";
            this.lbldt1.Size = new System.Drawing.Size(121, 31);
            this.lbldt1.TabIndex = 1;
            this.lbldt1.Text = "Doanh thu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Doanh thu din in / month";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.bdt);
            this.panel5.Controls.Add(this.cbbMonth);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 373);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(922, 519);
            this.panel5.TabIndex = 1;
            // 
            // bdt
            // 
            chartArea1.Name = "ChartArea1";
            this.bdt.ChartAreas.Add(chartArea1);
            this.bdt.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.bdt.Legends.Add(legend1);
            this.bdt.Location = new System.Drawing.Point(0, 36);
            this.bdt.Name = "bdt";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "s1";
            this.bdt.Series.Add(series1);
            this.bdt.Size = new System.Drawing.Size(922, 483);
            this.bdt.TabIndex = 2;
            this.bdt.Text = "chart1";
            // 
            // cbbMonth
            // 
            this.cbbMonth.BackColor = System.Drawing.Color.Transparent;
            this.cbbMonth.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbbMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMonth.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbMonth.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbMonth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbMonth.HoverState.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbMonth.ItemHeight = 30;
            this.cbbMonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbbMonth.Location = new System.Drawing.Point(0, 0);
            this.cbbMonth.Name = "cbbMonth";
            this.cbbMonth.Size = new System.Drawing.Size(922, 36);
            this.cbbMonth.StartIndex = 5;
            this.cbbMonth.TabIndex = 1;
            this.cbbMonth.SelectedIndexChanged += new System.EventHandler(this.cbbMonth_SelectedIndexChanged);
            // 
            // cbbYear
            // 
            this.cbbYear.BackColor = System.Drawing.Color.Transparent;
            this.cbbYear.DisabledState.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbYear.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbbYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbYear.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbYear.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbYear.FocusedState.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbYear.HoverState.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbYear.ItemHeight = 30;
            this.cbbYear.Items.AddRange(new object[] {
            "2019",
            "2020",
            "2021",
            "2022",
            "2023"});
            this.cbbYear.ItemsAppearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbYear.ItemsAppearance.SelectedFont = new System.Drawing.Font("Segoe UI", 18F);
            this.cbbYear.Location = new System.Drawing.Point(922, 373);
            this.cbbYear.Name = "cbbYear";
            this.cbbYear.Size = new System.Drawing.Size(796, 36);
            this.cbbYear.StartIndex = 4;
            this.cbbYear.TabIndex = 3;
            this.cbbYear.SelectedIndexChanged += new System.EventHandler(this.cbbYear_SelectedIndexChanged);
            // 
            // bdd
            // 
            this.bdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bdd.Location = new System.Drawing.Point(922, 409);
            this.bdd.Name = "bdd";
            this.bdd.Size = new System.Drawing.Size(796, 483);
            this.bdd.TabIndex = 4;
            this.bdd.Text = "cartesianChart1";
            // 
            // thongkeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1718, 892);
            this.Controls.Add(this.bdd);
            this.Controls.Add(this.cbbYear);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Name = "thongkeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "thongkeForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.thongkeForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbldt3;
        private System.Windows.Forms.Label lbldt2;
        private System.Windows.Forms.Label lbldt1;
        private System.Windows.Forms.Panel panel5;
        private Guna.UI2.WinForms.Guna2ComboBox cbbMonth;
        private System.Windows.Forms.DataVisualization.Charting.Chart bdt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox cbbYear;
        private System.Windows.Forms.Label label6;
        private LiveCharts.WinForms.CartesianChart bdd;
    }
}