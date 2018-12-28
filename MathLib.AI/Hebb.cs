using System;
namespace MathLib.AI
{
        public class HebbNetwork
        {
            private Matrix[] weights;
            private double learningRate;
            double b = 0.1;
            public HebbNetwork(int[] layer, double learningRate)
            {
                this.learningRate = learningRate;
                weights = new Matrix[layer.Length - 1];
                Random rand = new Random();

                for (int i = 0; i < layer.Length - 1; i++)
                {
                    weights[i] = new Matrix(layer[i + 1], layer[i]);
                    weights[i].Initialize(() => rand.NextDouble() - 0.5);

                }
            }

            public void Train(double[] inputs, double[] targets)
            {
                Matrix inputsSignal = new Matrix(inputs);
                Matrix targetsSignal = new Matrix(targets);
                Matrix[] y = new Matrix[weights.Length + 1];
                y[0] = inputsSignal;
                for (int i = 0; i < weights.Length; i++)
                {


                    y[i + 1] = sig(weights[i] * y[i], b);
                }

                Matrix delta = targetsSignal - y[weights.Length];
                for (int i = weights.Length - 1; i >= 0; i--)
                {
                    Matrix d = delta + y[i + 1];

                    weights[i] += (learningRate * y[i] * d.transpose()).transpose();

                    delta = weights[i].transpose() * delta;
                }
            }
            public double[] Query(double[] inputs)
            {
                Matrix y = new Matrix(inputs);
                for (int i = 0; i < weights.Length; i++)
                {
                    y = sig(weights[i] * y, b);
                }
                return y.transpose().Value[0];
            }
            Matrix sig(Matrix matrix, double b)
            {
                for (int i = 0; i < matrix.Value.Length; i++)
                {
                    for (int j = 0; j < matrix.Value[0].Length; j++)
                    {
                        //TODO(JA) ADD OPTION func bipolarna
                        matrix.Value[i][j] = 1 / (1 + Math.Pow(Math.E, -b * matrix.Value[i][j]));
                    }
                }
                return matrix;
            }
        }   
}
