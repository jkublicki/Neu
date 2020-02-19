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

        public void MakeTest()
        {


            Console.WriteLine("\r\n------ TEST: początek --------------");

            NetworkTypeA n = new NetworkTypeA(1, 2, 1);

            for (int i = 0; i < 100000; i++)
            {
                bool success = true;

                WeightsUpdater.SetRandomWeights(-10.0f, 10.0f, n);

                //f(0, 0) = 0
                n.SetInput(0, 0.0f);
                n.SetInput(1, 0.0f);
                Calculator.SetNetworkValues(n);
                if(!AreFloatsEqual(n.GetOutputValue(0), 0.0f, 0.001f))
                {
                    success = false;
                }
                //f(1, 0) = 1
                n.SetInput(0, 1.0f);
                n.SetInput(1, 0.0f);
                Calculator.SetNetworkValues(n);
                if (!AreFloatsEqual(n.GetOutputValue(0), 1.0f, 0.001f))
                {
                    success = false;
                }
                //f(0, 1) = 1
                n.SetInput(0, 0.0f);
                n.SetInput(1, 1.0f);
                Calculator.SetNetworkValues(n);
                if (!AreFloatsEqual(n.GetOutputValue(0), 1.0f, 0.001f))
                {
                    success = false;
                }
                //f(1, 1) = 0
                n.SetInput(0, 1.0f);
                n.SetInput(1, 1.0f);
                Calculator.SetNetworkValues(n);
                if (!AreFloatsEqual(n.GetOutputValue(0), 0.0f, 0.001f))
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
