using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;

namespace chart
{
    public partial class Form1 : Form
    {
        List<double> arrayPointOne;
        List<double> arrayPointTwo;
        List<double> arrayPointThree;

        List<string> arrayGrafName;

        public Form1(List<double> arrayPointOne, List<string> arrayGrafName)
        {
            this.arrayPointOne = arrayPointOne;
            this.arrayGrafName = arrayGrafName;

            InitializeComponent();            
        }
        public Form1(List<double> arrayPointOne, List<double> arrayPointTwo, List<string> arrayGrafName)
        {
            this.arrayPointOne = arrayPointOne;
            this.arrayPointTwo = arrayPointTwo;
            this.arrayGrafName = arrayGrafName;

            InitializeComponent();
        }
        public Form1(List<double> arrayPointOne, List<double> arrayPointTwo, List<double> arrayPointThree, List<string> arrayGrafName)
        {
            this.arrayPointOne = arrayPointOne;
            this.arrayPointTwo = arrayPointTwo;
            this.arrayPointThree = arrayPointThree;
            this.arrayGrafName = arrayGrafName;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //chart.Series.Clear();
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            //chart1.ChartAreas[0].AxisY.Maximum = 1;
            chart1.ChartAreas[0].AxisX.Interval = 10;
            //chart1.ChartAreas[0].AxisY.Interval = 1;
            chart1.Name = arrayGrafName[0];

            for (int i = 0; i < arrayPointOne.Count; i += 2)
            {
                chart1.Series[0].Points.AddXY(arrayPointOne[i], arrayPointOne[i + 1]);
            }

            //chart1.Series[0].Points.AddXY(0, 0);
            //chart1.Series[0].Points.AddXY(1, 0);
            //chart1.Series[0].Points.AddXY(1, 1);
            //chart1.Series[0].Points.AddXY(2, 1);
            //chart1.Series[0].Points.AddXY(3, 1);
            //chart1.Series[0].Points.AddXY(4, 1);
            //chart1.Series[0].Points.AddXY(20, 1);

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
