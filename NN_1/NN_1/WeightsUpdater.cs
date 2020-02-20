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
            Perceptron[,] percs = network.Perceptrons;
            Perceptron[] outputs = network.Outputs;
            Random random = new Random();

            foreach (Perceptron p in percs)
            {
                for (int y = 0; y < p.Weights.Length; y++)
                {
                    p.Weights[y] =  Tools.Rand.RandomFloat(min, max, random);
                }                
            }

            foreach (Perceptron p in outputs)
            {
                for (int y = 0; y < network.Height; y++)
                {
                    p.Weights[y] = Tools.Rand.RandomFloat(min, max, random);
                }
            }
        }

        
    }
}
