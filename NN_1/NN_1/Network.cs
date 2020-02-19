using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN_1
{
    public class Network
    {
        private int width;
        private int height;        
        private Perceptron[,] perceptrons;
        private float[] inputs;
        private Perceptron[] outputs; 
        private int outputsHeight;
        /*
        private struct Output
        {
            private float value;
            private float[] weights;

            public Output(int n_height)
            {
                value = 0;
                weights = new float[n_height];
                for (int y = 0; y < weights.Length; y++)
                {
                    weights[y] = 1;
                }
            }

            public float GetValue()
            {
                return value;
            }

            public void SetValue(float n_value)
            {
                value = n_value;
            }

            public float[] GetWeights()
            {
                return weights;
            }

            public void SetWeights(float[] n_weights)
            {
                for (int y = 0; y < weights.Length; y++)
                {
                    weights[y] = n_weights[y];
                }
            }
        }
        */

        public Network(int n_width, int n_height, int n_outputsHeight)
        {
            width = n_width;
            height = n_height;
            outputsHeight = n_outputsHeight;
            perceptrons = new Perceptron[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    perceptrons[x, y] = new Perceptron(x, y, height);
                }
            }
            inputs = new float[height];
            for (int y = 0; y < height; y++)
            {
                inputs[y] = 0.0f;
            }
            outputs = new Perceptron[outputsHeight];
            for (int y = 0; y < outputsHeight; y++)
            {
                outputs[y] = new Perceptron(-1, y, height); //x nie dotyczy outputów
            }
        }

        public Perceptron[,] GetPerceptrons()
        {
            return perceptrons;
        }

        public void SetInput(int y, float value)
        {
            inputs[y] = value;
        }

        public float GetInput(int y)
        {
            return inputs[y];
        }

        public float[] GetInputs()
        {
            return inputs;
        }

        public void SetOutput(int y, float value)
        {
            outputs[y].SetValue(value);
        }

        public float GetOutputValue(int y)
        {
            return outputs[y].GetValue();
        }

        public Perceptron GetOutput(int y)
        {
            return outputs[y];
        }

        public Perceptron[] GetOutputs()
        {
            return outputs;
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }

        public int GetOutputsHeight()
        {
            return outputsHeight;
        }

        public float[] GetColumnValues(int x)
        {
            float[] r = new float[height];

            for (int y = 0; y < height; y++)
            {
                r[y] = perceptrons[x, y].GetValue();
            }

            return r;
        }

        public string PrintState()
        {
            string r = "\r\n## NETWORK INFO ##\r\n";

            r += "\r\nHeight = " + height.ToString()
                + "\r\nWidth = " + width.ToString()
                + "\r\nOutputsHeight = " + outputsHeight.ToString()
                + "\r\n\r\nINPUTS\r\n";
                
            for (int i = 0; i < height; i++)
            {
                r += "i_" + i.ToString() + " = " + inputs[i].ToString() + "\r\n";
            }

            r += "\r\nOUTPUTS\r\n";

            for (int i = 0; i < outputsHeight; i++)
            {
                r += "o_" + i.ToString() + " = " + outputs[i].GetValue().ToString() + ", Weights: ";
                for (int y1 = 0; y1 < height; y1++)
                {
                    r += outputs[i].GetWeight(y1).ToString() + "; ";
                }

                r += "\r\n";

            }

            r += "\r\nPERCEPTRONS\r\n";

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    r += "p_x" + x.ToString() + "_y" + y.ToString() + " Value = " + perceptrons[x, y].GetValue().ToString() + ", Weights: ";

                    for (int y1 = 0; y1 < height; y1++)
                    {
                        r += perceptrons[x, y].GetWeight(y1).ToString() + "; ";
                    }

                    r += "\r\n";
                }
            }


            return r;
        }
    }
}
