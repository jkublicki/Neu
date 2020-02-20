using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN_1
{
    public static class Calculator
    {
        public static void SetAllPerceptronOutputs(INetwork network)
        {
            Perceptron[,] percs = network.Perceptrons;            

            for (int y = 0; y < network.Height; y++) //dla rzędu x = 0, który czerpie z inputów
            {
                float output = GetPerceptronOutput(network.Inputs, percs[0, y].Weights, network);
                percs[0, y].Output = output;
            }

            if (network.Width > 1) //o ile istnieje więcej rzędów
            {
                for (int x = 1; x < network.Width; x++)
                {
                    for (int y = 0; y < network.Height; y++)
                    {
                        float output = GetPerceptronOutput(network.GetColumnOutputs(x - 1), percs[x, y].Weights, network);
                        percs[x, y].Output = output;
                    }
                }
            }
            
            for (int y = 0; y < network.Outputs.Length; y++) //outputy sieci
            {
                float output = GetPerceptronOutput(network.GetColumnOutputs(network.Width - 1), network.Outputs[y].Weights, network);
                network.Outputs[y].Output = output;
            }
        }

        private static float GetPerceptronOutput(float[] sourceOutputs, float[] weights, INetwork network)
        {
            float output = 0.0f;
            for (int y = 0; y < sourceOutputs.Length; y++)
            {
                output += sourceOutputs[y] * weights[y];
            }
            return network.TresholdFunction(output);
        }
    }
}
