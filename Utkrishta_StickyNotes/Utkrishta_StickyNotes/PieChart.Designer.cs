namespace Utkrishta_StickyNotes
{
    partial class PieChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.day = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.thisweek = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.thisyear = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.thisMonths = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.day)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thisweek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thisyear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thisMonths)).BeginInit();
            this.SuspendLayout();
            // 
            // day
            // 
            chartArea1.Name = "ChartArea1";
            this.day.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.day.Legends.Add(legend1);
            this.day.Location = new System.Drawing.Point(12, 0);
            this.day.Name = "day";
            this.day.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Status";
            this.day.Series.Add(series1);
            this.day.Size = new System.Drawing.Size(548, 362);
            this.day.TabIndex = 0;
            this.day.Text = "chart1";
            this.day.Click += new System.EventHandler(this.chartdisplay_Click);
            // 
            // thisweek
            // 
            chartArea2.Name = "ChartArea1";
            this.thisweek.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.thisweek.Legends.Add(legend2);
            this.thisweek.Location = new System.Drawing.Point(556, 0);
            this.thisweek.Name = "thisweek";
            this.thisweek.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Status";
            this.thisweek.Series.Add(series2);
            this.thisweek.Size = new System.Drawing.Size(538, 362);
            this.thisweek.TabIndex = 3;
            this.thisweek.Text = "chart1";
            // 
            // thisyear
            // 
            chartArea3.Name = "ChartArea1";
            this.thisyear.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.thisyear.Legends.Add(legend3);
            this.thisyear.Location = new System.Drawing.Point(541, 355);
            this.thisyear.Name = "thisyear";
            this.thisyear.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Legend = "Legend1";
            series3.Name = "Status";
            this.thisyear.Series.Add(series3);
            this.thisyear.Size = new System.Drawing.Size(553, 362);
            this.thisyear.TabIndex = 4;
            this.thisyear.Text = "chart2";
            // 
            // thisMonths
            // 
            chartArea4.Name = "ChartArea1";
            this.thisMonths.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.thisMonths.Legends.Add(legend4);
            this.thisMonths.Location = new System.Drawing.Point(12, 355);
            this.thisMonths.Name = "thisMonths";
            this.thisMonths.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series4.Legend = "Legend1";
            series4.Name = "Status";
            this.thisMonths.Series.Add(series4);
            this.thisMonths.Size = new System.Drawing.Size(533, 362);
            this.thisMonths.TabIndex = 5;
            this.thisMonths.Text = "chart3";
            // 
            // PieChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 729);
            this.Controls.Add(this.thisMonths);
            this.Controls.Add(this.thisyear);
            this.Controls.Add(this.thisweek);
            this.Controls.Add(this.day);
            this.Name = "PieChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PieChart";
            this.Load += new System.EventHandler(this.PieChart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.day)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thisweek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thisyear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thisMonths)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart thisweek;
        private System.Windows.Forms.DataVisualization.Charting.Chart thisyear;
        private System.Windows.Forms.DataVisualization.Charting.Chart thisMonths;
        private System.Windows.Forms.DataVisualization.Charting.Chart day;
    }
}