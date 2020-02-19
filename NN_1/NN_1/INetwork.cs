using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN_1
{
    public interface INetwork
    {
        int Width { get; }
        int Height { get; }
        Perceptron[,] Perceptrons { get; }
        float[] Inputs { get; set; }
        Perceptron[] Outputs { get; }
        float TresholdFunction(float value);     
        float[] GetColumnValues(int x);
    }
}
