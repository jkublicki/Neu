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
            Perceptron[,] percs = network.GetPerceptrons();            

            for (int y = 0; y < network.GetHeight(); y++) //dla rzędu x = 0, który czerpie z inputów
            {
                float value = GetPerceptronValue(network.GetInputs(), percs[0, y].GetWeights(), network);
                percs[0, y].SetValue(value);
            }

            if (network.GetWidth() > 1) //o ile istnieje więcej rzędów
            {
                for (int x = 1; x < network.GetWidth(); x++)
                {
                    for (int y = 0; y < network.GetHeight(); y++)
                    {
                        float value = GetPerceptronValue(network.GetColumnValues(x - 1), percs[x, y].GetWeights(), network);
                        percs[x, y].SetValue(value);
                    }
                }
            }

            for (int y = 0; y < network.GetOutputsHeight(); y++)
            {
                float value = GetPerceptronValue(network.GetColumnValues(network.GetWidth() - 1), network.GetOutput(y).GetWeights(), network);
                network.SetOutput(y, value);
            }
        }

        private static float GetPerceptronValue(float[] sourceValues, float[] weights, INetwork network)
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
