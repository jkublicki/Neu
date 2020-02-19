using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN_1
{
    public interface INetwork
    {
        float TresholdFunction(float value);        
        Perceptron[,] GetPerceptrons();
        void SetInput(int y, float value);
        float GetInput(int y);
        float[] GetInputs();
        void SetOutput(int y, float value);
        Perceptron GetOutput(int y);
        Perceptron[] GetOutputs();
        float GetOutputValue(int y);
        int GetWidth();
        int GetHeight();
        int GetOutputsHeight();
        float[] GetColumnValues(int x);
    }
}
