using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN_1
{
    public static class Calculator
    {
        public static void SetNetworkValues(INetwork network)
        {
            Perceptron[,] percs = network.Perceptrons;            

            for (int y = 0; y < network.Height; y++) //dla rzędu x = 0, który czerpie z inputów
            {
                float value = GetPerceptronOutput(network.Inputs, percs[0, y].Weights, network);
                percs[0, y].Output = value;
            }

            if (network.Width > 1) //o ile istnieje więcej rzędów
            {
                for (int x = 1; x < network.Width; x++)
                {
                    for (int y = 0; y < network.Height; y++)
                    {
                        float value = GetPerceptronOutput(network.GetColumnValues(x - 1), percs[x, y].Weights, network);
                        percs[x, y].Output = value;
                    }
                }
            }

            for (int y = 0; y < network.Outputs.Length; y++)
            {
                float value = GetPerceptronOutput(network.GetColumnValues(network.Width - 1), network.Outputs[y].Weights, network);
                network.Outputs[y].Output = value;
            }
        }

        private static float GetPerceptronOutput(float[] sourceValues, float[] weights, INetwork network)
        {
            float value = 0.0f;
            for (int y = 0; y < sourceValues.Length; y++)
            {
                value += sourceValues[y] * weights[y];
            }
            return network.TresholdFunction(value);
        }
    }
}
