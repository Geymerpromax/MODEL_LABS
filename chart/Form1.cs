using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace chart
{
    public partial class Form1 : Form
    {
       
        public Form1(List<int> a)
        {
            InitializeComponent();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            //chart.Series.Clear();
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 1;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.Interval = 1;

            chart1.Series[0].Points.AddXY(0, 0);
            chart1.Series[0].Points.AddXY(1, 0);
            chart1.Series[0].Points.AddXY(1, 1);
            chart1.Series[0].Points.AddXY(2, 1);
            chart1.Series[0].Points.AddXY(3, 1);
            chart1.Series[0].Points.AddXY(4, 1);
            chart1.Series[0].Points.AddXY(20, 1);

            chart2.Series[0].Points.AddXY(0, 0);
            chart2.Series[0].Points.AddXY(1, 0);
            chart2.Series[0].Points.AddXY(1, 1);
            chart2.Series[0].Points.AddXY(2, 1);
            chart2.Series[0].Points.AddXY(3, 1);
            chart2.Series[0].Points.AddXY(4, 1);
            chart2.Series[0].Points.AddXY(20, 1);

            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisY.Maximum = 1;
            chart2.ChartAreas[0].AxisX.Interval = 1;
            chart2.ChartAreas[0].AxisY.Interval = 1;
        }

       

        
    }
}
