using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLib;
using MathLib.AI;
namespace Starter
{
    class Program
    {
        static double[][] number = new double[][]{
           new double[]{ 1, 1, 1, 1, -1, 1, 1, -1, 1, 1, 1, 1 },//-1
           new double[]{ -1, -1, 1, -1, -1, 1, -1, -1, 1, -1, -1, 1 },//1
           new double[]{ 1, 1, 1, -1, 1, -1, 1, -1, -1, 1, 1, 1 },//2
           new double[]{ 1, 1, 1, -1, -1, 1, 1, 1, 1, 1, 1, 1 },//3
           new double[]{ 1, -1, 1, 1, 1, 1, -1, -1, 1, -1, -1, 1 },//4
           new double[]{ 1, 1, 1, -1, 1, -1, -1, -1, 1, 1, 1, 1 },//5
           new double[]{ 1, 1, 1, 1, -1, -1, 1, 1, 1, 1, 1, 1 },//6
           new double[]{ 1, 1, 1, -1, -1, 1, -1, -1, 1, -1, -1, 1 },//7
           new double[]{ 1, 1, 1, 1, -1, 1, 1, 1, 1, 1, 1, 1 },//8
           new double[]{ 1, 1, 1, 1, 1, 1, -1, -1, 1, 1, 1, 1 },//9
           #region numbers
           //0=-1



            ////0///
            //1 1 1
            //1 0 1
            //1 0 1
            //1 1 1
            ////1///
            //0 0 1
            //0 0 1
            //0 0 1
            //0 0 1
            ////2///
            //1 1 1
            //0 1 0
            //1 0 0
            //1 1 1
            ////3///
            //1 1 1
            //0 0 1
            //1 1 1
            //1 1 1
            ////4///
            //1 0 1
            //1 1 1
            //0 0 1
            //0 0 1
            ////5///
            //1 1 1
            //0 1 0
            //0 0 1
            //1 1 1
            ////6///
            //1 1 1
            //1 0 0
            //1 1 1
            //1 1 1
            ////7///
            //1 1 1
            //0 0 1
            //0 0 1
            //0 0 1
            ////8///
            //1 1 1
            //1 0 1
            //1 1 1
            //1 1 1
            ////9///
            //1 1 1
            //1 1 1
            //0 0 1
            //1 1 1
#endregion
        };
        static void Main(string[] args)
        {
            //Graph.Data[] dates = new Graph.Data[]
            //{
            //    new Graph.Data(new double[]{2,3,4,5,1,2},new double[]{0.1,2,4,5,10,11},"dwie tablice"),
            //    new Graph.Data(new double[]{1,3,4,6,8},"jedna tablica",GraphTypes.LINE),
            //    new Graph.Data(x =>2*x+1,-10,2,5 ,"funkcja liniowa"),
            //};
            


            int[] NeuronsInLayers = new int[] { number[0].Length, 10 };
            HebbNetwork network = new HebbNetwork(NeuronsInLayers, 0.3);

            for (int i = 0; i < number.Length; i++)
            {
                double[] target = Enumerable.Range(1, 10).Select(x => -1d).ToArray();
                target[i] = 1;
                network.Train(number[i], target);
            }

            bool[] iscurrent = new bool[number.Length];
            string wyniki = "";
            for (int i = 0; i < number.Length; i++)
            {
                double[] res = network.Query(number[i]);
                var max = res.Max();
                var f = res.ToList().IndexOf(max);
                iscurrent[i] = (f == i);
                Console.WriteLine(f + "==" + i);
                wyniki += "\n" + i + ":" + f;
                //throw new Exception("Not Learned network. Errored in " + i);
            }
            if (((double)iscurrent.Count(x => x) / (double)iscurrent.Length) < 0.7) throw new Exception("Ta siec jes tdo dupy wyniki:" + wyniki);


        }
        

        
    }
}
