using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN_1
{
    public static class WeightsUpdater
    {
        public static void SetRandomWeights(float min, float max, INetwork network)
        {
            Perceptron[,] percs = network.GetPerceptrons();
            Perceptron[] outputs = network.GetOutputs();
            Random random = new Random();

            foreach (Perceptron p in percs)
            {
                for (int y = 0; y < network.GetHeight(); y++)
                {
                    p.SetWeight(y, RandomFloat(min, max, random));
                }                
            }

            foreach (Perceptron p in outputs)
            {
                for (int y = 0; y < network.GetHeight(); y++)
                {
                    p.SetWeight(y, RandomFloat(min, max, random));
                }
            }
        }

        private static float RandomFloat(float min, float max, Random random)
        {
            float x = (float)random.NextDouble();
            float d = max - min;
            float r = min + d * x;
            return r;
        }
    }
}
