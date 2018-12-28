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
        LINE=3
    }
    public static class Graph
    {

        public struct GraphInfo
        {
            string title;
            string titleAxisX;
            string titleAxisY;
            GraphTypes type;
            public GraphInfo(string title,string titleAxisX,string titleAxisY,GraphTypes type)
            {
                
                this.title = title;
                this.titleAxisX = titleAxisX;
                this.titleAxisY = titleAxisY;
                this.type = type;
            }
            public string Title {get{ return title; } }
            public string TitleAxisX {get{ return titleAxisX; } }
            public string TitleAxisY {get{ return titleAxisY; } }
            public GraphTypes TypeGraph {get{ return type; } }
        }

        public static void Create(double[] nums,GraphInfo info)
        {
            Application.EnableVisualStyles();

            Application.Run(new Form1(nums,info));
        }
        public static void Create(DomainFunc domain,Func<double,double> func, GraphInfo info)
        {
            double[] nums;
            double[] d;
            if (domain.Type == TypeDomain.OTHER)
            {
                d = domain.Domain;
                nums = new double[d.Length];

                for(int i=0;i< d.Length;i++)
                {
                    nums[i] = func(d[i]);
                }
                
            }
            else
            {
                
                int count = (int)(domain.MaxValue - domain.MinValue)+1;
                nums = new double[count];
                d = new double[count];

                for(double i=domain.MinValue,j=0;i<=domain.MaxValue;i++,j++)
                {
                    d[(int)j] = i;
                    nums[(int)j] = func(i);
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(d,nums,info));

        }
    }
}
