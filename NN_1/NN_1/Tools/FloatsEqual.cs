using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN_1.Tools
{
    public static class FloatsEqual
    {
        public static bool AreFloatsEqual(float a, float b, float error)
        {
            if (Math.Abs(a - b) < error)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
