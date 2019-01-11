using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MathLib.AI;
using System.Linq;
namespace AITest
{
    public class CustomeTests
    {
        double[][] XORData = new double[][]
         {
            new double[]{1,1,-1 },
            new double[]{1,-1,1 },
            new double[]{-1,1,1 },
            new double[]{-1,-1,-1 },
         };


        [Fact]
        public void XOR()
        {
            int[] NeuronsInLayers = new int[] { 2, 5, 1 };
            CustomeNetwork network = new CustomeNetwork(NeuronsInLayers, 0.3);
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < XORData.Length; i++)
                {
                    double[] data = new double[] { XORData[i][0], XORData[i][1] };
                    double[] target = new double[] { XORData[i][2] };
                    network.Train(data, target);
                }
            }
            bool[] iscurrent = new bool[XORData.Length];
            string wyniki = "";
            for (int i = 0; i < XORData.Length; i++)
            {
                double[] data = new double[] { XORData[i][0], XORData[i][1] };
                
                double[] res = network.Query(data); 
               
                iscurrent[i] = (XORData[i][2] >= 0 == res[0] >= 0);

                wyniki += "\n" + XORData[i][2] + ":" + res[0];
                //throw new Exception("Not Learned network. Errored in " + i);
            }
            if (((double)iscurrent.Count(x => x) / (double)iscurrent.Length) < 0.7) throw new Exception("Ta siec jes tdo dupy wyniki:" + wyniki);
        }

    }
}
