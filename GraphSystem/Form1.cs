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
        Func<double, double> _func;
        DomainFunc domain;
        public Form1(double[] numbers, Graph.GraphInfo info)
        {
            InitializeComponent();
            SetChart(info.Title, info.TitleAxisX, info.TitleAxisY, 0, numbers.Length - 1, info.TypeGraph);

            for (int i = 0; i < numbers.Length; i++)
            {
                chart1.Series[0].Points.AddXY(i, numbers[i]);
            }

        }
        public Form1(double[] domain, double[] numbers, Graph.GraphInfo info)
        {
            InitializeComponent();
            SetChart(info.Title, info.TitleAxisX, info.TitleAxisY, domain[0], domain.Last(), info.TypeGraph);

            for (int i = 0; i < domain.Length; i++)
            {
                chart1.Series[0].Points.AddXY(domain[i], numbers[i]);
            }

        }

        void SetChart(string title = "", string titleX = "", string titleY = "", double minDomain = 0, double maxDomain = 0,
            GraphTypes type = GraphTypes.LINE)
        {

            chart1.Series[0].Points.Clear();
            chart1.ChartAreas[0].AxisX.Minimum = minDomain;
            chart1.ChartAreas[0].AxisX.Maximum = maxDomain;
            chart1.ChartAreas[0].AxisX.Title = titleX;
            chart1.ChartAreas[0].AxisY.Title = titleY;
            chart1.Series[0].ChartType = (System.Windows.Forms.DataVisualization.Charting.SeriesChartType)type;
            chart1.Titles[0].Text = title;

        }

    }
    public class DomainFunc
    {
        TypeDomain type;
        double minValue, maxValue;
        double[] _domain;
        public DomainFunc(TypeDomain type, double minValue, double maxValue)
        {
            this.type = type;
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
        public DomainFunc(double[] domain)
        {
            this.type = TypeDomain.OTHER;
            this._domain = domain;
        }

        public TypeDomain Type
        {
            get
            {
                return type;
            }
        }
        public double MinValue { get { return minValue; } }
        public double MaxValue { get { return maxValue; } }
        public double[] Domain { get { return _domain; } }
    }
    public enum TypeDomain
    {
        INTEGERS, REAL, OTHER
    }

}
