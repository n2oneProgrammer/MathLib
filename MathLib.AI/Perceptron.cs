using System;
namespace MathLib.AI
{
        public class PerceptronNetwork
        {
            private Matrix[] weights;
            private double learningRate;
            
            public PerceptronNetwork(int[] layer, double learningRate)
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
                    y[i + 1] = HeavisideStepFunction(weights[i] * y[i]);
                }

            Matrix d = targetsSignal;
            for (int i = weights.Length - 1; i >= 0; i--)
            {

                weights[i] += y[i] * d;

                d = weights[i].transpose() * d + y[i + 1];
            }
        }
            public double[] Query(double[] inputs)
            {
                Matrix y = new Matrix(inputs);
                for (int i = 0; i < weights.Length; i++)
                {
                    y = HeavisideStepFunction(weights[i] * y);
                }
                return y.transpose().Value[0];
            }
        Matrix HeavisideStepFunction(Matrix matrix)
        {
            for (int i = 0; i < matrix.Value.Length; i++)
            {
                for (int j = 0; j < matrix.Value[0].Length; j++)
                {
                    //TODO(JA) ADD OPTION func unipolarna
                    double v = matrix.Value[i][j];
                    if (v > 0)
                        matrix.Value[i][j] = 1;
                    else
                        matrix.Value[i][j] = 0;
                }
            }
            return matrix;
        }


        }   
}
