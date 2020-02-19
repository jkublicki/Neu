using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN_1
{
    class Test
    {
        private bool AreFloatsEqual(float a, float b, float error)
        {
            if(Math.Abs(a - b) < error)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SmallTest()
        {
            ushort x = Tools.UShortMath.Algebra(63000, 63, '/');
            Console.WriteLine("x = " + x.ToString());

            Perceptron p = new Perceptron(3);

            p.Weights = new float[3] { 0.1f, 0.2f, 0.3f };

            Console.WriteLine("w " + p.Weights[0].ToString());

            //NetworkTypeA n1 = new NetworkTypeA(500, 500, 1);
        }

        public void MakeTest()
        {


            Console.WriteLine("\r\n------ TEST: początek --------------");

            NetworkTypeA n = new NetworkTypeA(1, 2, 1);

            for (int i = 0; i < 100000; i++)
            {
                bool success = true;

                WeightsUpdater.SetRandomWeights(-10.0f, 10.0f, n);

                //f(0, 0) = 0
                n.Inputs = new float[] { 0.0f, 0.0f };

                Calculator.SetNetworkValues(n);
                if(!AreFloatsEqual(n.Outputs[0].Output, 0.0f, 0.001f))
                {
                    success = false;
                }
                //f(1, 0) = 1
                n.Inputs = new float[] { 1.0f, 0.0f };

                Calculator.SetNetworkValues(n);
                if (!AreFloatsEqual(n.Outputs[0].Output, 1.0f, 0.001f))
                {
                    success = false;
                }
                //f(0, 1) = 1
                n.Inputs = new float[] { 0.0f, 1.0f };

                Calculator.SetNetworkValues(n);
                if (!AreFloatsEqual(n.Outputs[0].Output, 1.0f, 0.001f))
                {
                    success = false;
                }
                //f(1, 1) = 0
                n.Inputs = new float[] { 1.0f, 1.0f };

                Calculator.SetNetworkValues(n);
                if (!AreFloatsEqual(n.Outputs[0].Output, 0.0f, 0.001f))
                {
                    success = false;
                }

                if(success)
                {
                    Console.WriteLine("\r\nZNALEZIONO");
                    Console.WriteLine(n.PrintState());
                    break;
                }
            }

            

            Console.WriteLine("\r\n------ TEST: koniec ----------------");







        }
    }
}
