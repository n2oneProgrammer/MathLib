using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathLib
{
    public partial class Form1 : Form
    {
       
        public Form1(Graph.Data[] dates, string title = "", string titleX = "", string titleY = "")
        {
            InitializeComponent();
            SetChart(title, titleX, titleY);

            foreach(Graph.Data data in dates)
            {
                System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
                series1.ChartArea = "ChartArea1";
                series1.Legend = "Legend1";
                series1.Name = data.name;
                this.chart1.Series.Add(series1);

                chart1.Series[data.name].ChartType = (System.Windows.Forms.DataVisualization.Charting.SeriesChartType)data.type;

                for (int i = 0; i < data.data.Length; i++)
                {
                    chart1.Series[data.name].Points.AddXY(data.sign[i], data.data[i]);
                }
            }

        }
        

        void SetChart(string title = "", string titleX = "", string titleY = "")
        {
            chart1.ChartAreas[0].AxisX.Title = titleX;
            chart1.ChartAreas[0].AxisY.Title = titleY;
            chart1.Titles[0].Text = title;

        }

    }
    

}
