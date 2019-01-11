using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MathLib
{
    public enum GraphTypes
    {
        LINE=3,POINT=0
    }
    public static class Graph
    {

        public class Data
        {
            public double[] data, sign;
            public GraphTypes type;
            public string name;
            public Data(double[] data, double[] sign,string name, GraphTypes type = GraphTypes.POINT)
            {
                this.data = data;
                this.sign = sign;
                this.name = name;
                this.type = type;
            }
            public Data(double[] data, string name, GraphTypes type = GraphTypes.POINT)
            {
                this.data = data;
                sign = Enumerable.Range(0,data.Length).Select(x => (double)x).ToArray();
                this.name = name;
                this.type = type;
            }
            public Data(Func<double,double> func,double start,double step,double end, string name, GraphTypes type = GraphTypes.LINE)
            {
                List<double> data = new List<double>(), sign=new List<double>();
                for(double i=start;i <= end;i += step)
                {
                    data.Add(func(i));
                    sign.Add(i);
                }
                this.data = data.ToArray();
                this.sign = sign.ToArray();
                this.name = name;
                this.type = type;
            }

            


        }

        public static void Create(Data[] dates,string Title="",string TitleX="",string TitleY="")
        {
            Application.EnableVisualStyles();

            Application.Run(new Form1(dates,Title,TitleX,TitleY));
        }
        
    }
}
