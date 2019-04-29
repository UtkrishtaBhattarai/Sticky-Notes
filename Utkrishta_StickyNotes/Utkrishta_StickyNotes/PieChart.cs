using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utkrishta_StickyNotes
{
    public partial class PieChart : Form
    {
        public PieChart(int USerID)
        {
            pieBLL.UserID = USerID;
            InitializeComponent();
        }
        PiechartBLL pieBLL = new PiechartBLL();
        DataTable[] dt = new DataTable[8];
        int[] Completed = new int[4];
        int[] Incomplete = new int[4];
        private void PieChart_Load(object sender, EventArgs e)
        {
            Completed[0] = 1;
            Incomplete[0] = 1;
            DateTime Today = DateTime.Now;
            DateTime Week = DateTime.Now.AddDays(-7);
            DateTime Months = DateTime.Now.AddDays(-30);
            DateTime Year = DateTime.Now.AddYears(-1);
            pieBLL.Today = Today.ToString();
            pieBLL.Week = Week.ToString();
            pieBLL.Months = Months.ToString();
            pieBLL.Year = Year.ToString();

            //For Todayyyyyyyy
            try
            {
                dt[0] = pieBLL.CompletedToday();
                dt[1] = pieBLL.InCompleteToday();

                Completed[0] = int.Parse(dt[0].Rows[0][0].ToString()) * 100 / (int.Parse(dt[1].Rows[0][0].ToString()) + int.Parse(dt[0].Rows[0][0].ToString()));
                Incomplete[0] = int.Parse(dt[1].Rows[0][0].ToString()) * 100 / (int.Parse(dt[1].Rows[0][0].ToString()) + int.Parse(dt[0].Rows[0][0].ToString()));
                day.Titles.Add("Today");
                day.Series["Status"].Points.AddXY("Complete" + ":" + Completed[0] + "%", Completed[0]);
                day.Series["Status"].Points.AddXY("Incomplete" + ":" + Incomplete[0] + "%", Incomplete[0]);
            }
            catch(DivideByZeroException)
            {
                day.Titles.Add("Create notes for today now");
            }
          //For This Week
            try
            {
                dt[2] = pieBLL.CompleteWeek();
                dt[3] = pieBLL.InCompleteWeek();
                Completed[1] = int.Parse(dt[2].Rows[0][0].ToString()) * 100 / (int.Parse(dt[3].Rows[0][0].ToString()) + int.Parse(dt[2].Rows[0][0].ToString()));
                Incomplete[1] = int.Parse(dt[3].Rows[0][0].ToString()) * 100 / (int.Parse(dt[3].Rows[0][0].ToString()) + int.Parse(dt[2].Rows[0][0].ToString()));
                thisweek.Titles.Add("Weekly");
                thisweek.Series["Status"].Points.AddXY("Complete" + ":" + Completed[1] + "%", Completed[1]);
                thisweek.Series["Status"].Points.AddXY("Incomplete" + ":" + Incomplete[1] + "%", Incomplete[1]);
            }
            catch (DivideByZeroException)
            {
                thisweek.Titles.Add("Create Notes First");
            }


            //For This Month
            try
            {
                dt[4] = pieBLL.CompleteMonth();
                dt[5] = pieBLL.InCompleteMonth();
                Completed[2] = int.Parse(dt[4].Rows[0][0].ToString()) * 100 / (int.Parse(dt[4].Rows[0][0].ToString()) + int.Parse(dt[5].Rows[0][0].ToString()));
                Incomplete[2] = int.Parse(dt[5].Rows[0][0].ToString()) * 100 / (int.Parse(dt[4].Rows[0][0].ToString()) + int.Parse(dt[5].Rows[0][0].ToString()));
                thisMonths.Titles.Add("Months");
                thisMonths.Series["Status"].Points.AddXY("Complete" + ":" + Completed[2] + "%", Completed[2]);
                thisMonths.Series["Status"].Points.AddXY("Incomplete" + ":" + Incomplete[2] + "%", Incomplete[2]);
            }
            catch (DivideByZeroException)
            {
                thisMonths.Titles.Add("Create Notes First");
            }
            //For This year
            try
            {
                dt[6] = pieBLL.CompleteYear();
                dt[7] = pieBLL.InCompleteYear();
                Completed[3] = int.Parse(dt[6].Rows[0][0].ToString()) * 100 / (int.Parse(dt[6].Rows[0][0].ToString()) + int.Parse(dt[7].Rows[0][0].ToString()));
                Incomplete[3] = int.Parse(dt[7].Rows[0][0].ToString()) * 100 / (int.Parse(dt[6].Rows[0][0].ToString()) + int.Parse(dt[7].Rows[0][0].ToString()));
                thisyear.Titles.Add("Year");
                thisyear.Series["Status"].Points.AddXY("Complete" + ":" + Completed[3] + "%", Completed[3]);
                thisyear.Series["Status"].Points.AddXY("Incomplete" + ":" + Incomplete[3] + "%", Incomplete[3]);
            }
            catch(DivideByZeroException)
            {
                thisyear.Titles.Add("Create Notes First");
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
             
        }

        private void chartdisplay_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
