using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN_1.Tools
{
    public static class Rand
    {
        public static float RandomFloat(float min, float max, Random random)
        {
            float x = (float)random.NextDouble();
            float d = max - min;
            float r = min + d * x;
            return r;
        }
    }
}
