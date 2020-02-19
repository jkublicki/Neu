using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN_1
{
    //dane sieci
    public class Network
    {
        private int width;
        public int Width { get { return width; } }
        private int height;        
        public int Height { get { return height; } }
        private Perceptron[,] perceptrons;
        public Perceptron[,] Perceptrons { get { return perceptrons; } }
        private float[] inputs;
        public float[] Inputs { get { return inputs; } set { Array.Copy(value, inputs, inputs.Length); } }
        private Perceptron[] outputs;
        public Perceptron[] Outputs { get { return outputs; } }

        public Network(int n_width, int n_height, int outputsHeight)
        {
            width = n_width;
            height = n_height;
            //outputsHeight = n_outputsHeight;
            perceptrons = new Perceptron[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    perceptrons[x, y] = new Perceptron(height);
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
                outputs[y] = new Perceptron(height); 
            }
        }

        public float[] GetColumnValues(int x)
        {
            float[] r = new float[height];

            for (int y = 0; y < height; y++)
            {
                r[y] = perceptrons[x, y].Output;
            }

            return r;
        }

        public string PrintState()
        {
            string r = "\r\n## NETWORK INFO ##\r\n";

            r += "\r\nHeight = " + height.ToString()
                + "\r\nWidth = " + width.ToString()
                + "\r\nOutputsHeight = " + outputs.Length.ToString()
                + "\r\n\r\nINPUTS\r\n";
                
            for (int i = 0; i < height; i++)
            {
                r += "i_" + i.ToString() + " = " + inputs[i].ToString() + "\r\n";
            }

            r += "\r\nOUTPUTS\r\n";

            for (int i = 0; i < outputs.Length; i++)
            {
                r += "o_" + i.ToString() + " = " + outputs[i].Output.ToString() + ", Weights: ";
                for (int y1 = 0; y1 < height; y1++)
                {
                    r += outputs[i].Weights[y1].ToString() + "; ";
                }

                r += "\r\n";

            }

            r += "\r\nPERCEPTRONS\r\n";

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    r += "p_x" + x.ToString() + "_y" + y.ToString() + " Value = " + perceptrons[x, y].Output.ToString() + ", Weights: ";

                    for (int y1 = 0; y1 < height; y1++)
                    {
                        r += perceptrons[x, y].Weights[y1].ToString() + "; ";
                    }

                    r += "\r\n";
                }
            }


            return r;
        }
    }
}
