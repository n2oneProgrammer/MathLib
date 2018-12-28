using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MathLib.AI;
using System.Linq;
namespace AITest
{
    public class PerceptronTests
    {
        double[][] number = new double[][]{
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

        [Fact]
        public void LearningFunction()
        {
            int[] NeuronsInLayers = new int[] { number[0].Length, 10 };
            PerceptronNetwork network = new PerceptronNetwork(NeuronsInLayers,0.3);

            for (int i = 0; i < number.Length; i++)
            {
                double[] target = Enumerable.Range(1, 10).Select(x => -1d).ToArray();
                target[i] = 1;
                network.Train(number[i], target);
            }
            
            bool[] iscurrent=new bool[number.Length];
            string wyniki = "";
            for (int i = 0; i < number.Length; i++)
            {
                double[] res = network.Query(number[i]);
                var max = res.Max();
                var f = res.ToList().IndexOf(max);
                iscurrent[i] = (f == i);

                wyniki += "\n" + i + ":" + f;
                    //throw new Exception("Not Learned network. Errored in " + i);
            }
            if (((double)iscurrent.Count(x => x)/(double)iscurrent.Length) < 0.7 ) throw new Exception("Ta siec jes tdo dupy wyniki:"+wyniki);
        }
        
    }
}
