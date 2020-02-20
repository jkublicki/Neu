using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN_1
{
    //dane perceptronu
    public class Perceptron
    {
        private float output; //ignorować podpowiedź o property, wynika z tego, że get i set są (póki co!) trywialne
        public float Output
        { get { return output; } set { output = value; } }

        //klasa konsumująca musi zadbać o zgodność indeksu Weights ze swoim indeksem neuronów
        //przykład:
        //sieć ma X warstw po Y neuronów; obliczając wartość neuronu na pozycji (x1, y1) 
        //iterujemy po neuronach od (x1 - 1, 0) do (x1 - 1, Y - 1) aby uzyskać ich Output
        //i jednocześnie tą samą zmienną iteracyjną po Weights od 0 do Y - 1
        private float[] weights;
        public float[] Weights 
        { get { return weights; } set { Array.Copy(value, weights, weights.Length); } }

        public Perceptron(int weightsLength)
        {
            output = 1.0f;
            weights = new float[weightsLength];
            for (int y = 0; y < weightsLength; y++)
            {
                weights[y] = 1.0f;
            }
        }
    }

    
}
