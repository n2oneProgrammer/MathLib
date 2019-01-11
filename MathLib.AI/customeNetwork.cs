using System;
using System.Collections.Generic;
using System.Text;

namespace MathLib.AI
{
    public class CustomeNetwork
    {
        private double[][][] weights;//weights[k][i][j]
        private int[] N;//count neurons in layer
        private readonly double LEARNINGRATE;
        double B = 0.1;
        public CustomeNetwork(int[] layers, double learningRate)
        {
            this.LEARNINGRATE = learningRate;
            this.N = layers;
            weights = new double[N.Length - 1][][]; //new Matrix[layer.Length - 1];
            Random rand = new Random();

            for (int i = 0; i < N.Length - 1; i++)
            {
                weights[i] = CreateTabRandom(N[i + 1], N[i]);

            }
        }

        public void Train(double[] inputs, double[] d)
        {


            int L = weights.Length;//count layer
            double[][] s = new double[L + 1][];
            double[][] y = new double[L + 1][];
            s[0] = inputs;
            y[0] = s[0];

            //Calculating Layers' outputs
            for (int k = 0; k < L; k++)//k-number layer;    
            {
                s[k + 1] = new double[N[k + 1]];
                y[k + 1] = new double[N[k + 1]];
                for (int i = 0; i < N[k + 1]; i++)
                {
                    s[k + 1][i] = 0;
                    for (int j = 0; j < weights[k][i].Length; j++)
                    {
                        s[k + 1][i] += weights[k][i][j] * y[k][j];
                    }

                    y[k + 1][i] = sig(s[k + 1][i], B);
                }
            }
            //Calculating Layers' errors
            double[][] Q = new double[L][];
            Q[L - 1] = new double[N[L]];
            for (int i = 0; i < N[L]; i++)
            {
                Q[L - 1][i] = (d[i] - y[L][i]) * y[L][i] * (1 - y[L][i]);
            }
            for (int k = L - 1; k > 0; k--)
            {
                Q[k - 1] = new double[N[k]];
                for (int i = 0; i < N[k]; i++)
                {
                    Q[k - 1][i] = 0;
                    for (int m = 0; m < N[k + 1]; m++)
                    {
                        Q[k - 1][i] += Q[k][m] * weights[k][m][i] * (1 - y[k][i] * y[k][i]);
                    }
                }
            }

            for (int k = 0; k < L; k++)//k-number layer;    
            {

                for (int i = 0; i < N[k + 1]; i++)
                {

                    for (int j = 0; j < weights[k][i].Length; j++)
                    {
                       
                        weights[k][i][j] += 2*LEARNINGRATE * Q[k][i]  * y[k][j];

                    }
                }
            }

        }
        public double[] Query(double[] inputs)
        {

            int L = weights.Length;//count layer
            double[] s;
            double[] y, tempy;
            s = inputs;
            y = s;

            for (int k = 1; k <= L; k++)//k-number layer;    
            {
                s = new double[N[k]];
                tempy = new double[N[k]];
                for (int i = 0; i < N[k]; i++)
                {
                    s[i] = 0;
                    for (int j = 0; j < weights[k - 1][i].Length; j++)
                    {
                        s[i] += weights[k - 1][i][j] * y[j];
                    }

                    tempy[i] = sig(s[i], B);
                }
                y = tempy;
            }
            return y;
        }
        double[][] CreateTabRandom(int x, int y)
        {
            double[][] result = new double[x][];


            for (int i = 0; i < x; i++)
            {
                Random rand = new Random();
                double[] r = new double[y];
                for (int j = 0; j < y; j++)
                {
                    r[j] = (rand.NextDouble() * i - 0.5) % 1;
                }
                result[i] = r;
            }
            return result;

        }
        double sig(double v, double b)
        {

            return (1 - Math.Pow(Math.E, -b * v)) / (1 + Math.Pow(Math.E, -b * v));

        }
    }
}
