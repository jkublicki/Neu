using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN_1
{
    public class NetworkTypeA : Network, INetwork //jak Network, ale ze specyficzną funkcją
    {
        public NetworkTypeA(int n_width, int n_height, int n_outputsHeight) : base(n_width, n_height, n_outputsHeight)
        {
        }

        public float TresholdFunction(float value)
        {
            if (value > 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


    }
}
