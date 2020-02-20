using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN_1
{
    //dlaczego interfejs? 
    //- chciałbym mieć uniwersalną klasę bazową network, nad nią specyficzną network-typ-x ze specyficzną funkcją
    //- a wyżej znowu uniwersalny kalkulator, manager ds. jednego testu, manager wielu testów, zarządzanie wagami itp.
    public interface INetwork
    {
        int Width { get; }
        int Height { get; }
        Perceptron[,] Perceptrons { get; }
        float[] Inputs { get; set; }
        Perceptron[] Outputs { get; }
        float TresholdFunction(float value);     
        float[] GetColumnOutputs(int x);
    }
}
