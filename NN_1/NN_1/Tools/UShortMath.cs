using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN_1.Tools
{
    public static class UShortMath
    {
        public static ushort Algebra(ushort a, ushort b, char _operator)
        {
            ushort r = 0;

            int a1 = a;
            int b1 = b;
            int r1;

            switch (_operator)
            {
                case '+':
                    r1 = a1 + b1;
                    break;
                case '-':
                    r1 = a1 - b1;
                    break;
                case '*':
                    r1 = a1 * b1;
                    break;
                case '/':
                    if (b1 != 0)
                    {
                        r1 = (int)Math.Round((float)a1 / b1);
                        break;
                    }
                    else
                    {
                        throw new DivideByZeroException("Error in UMath.Algebra(), divide by zero.");
                    }
                default:
                    throw new NotImplementedException("Error in UMath.Algebra(), can't recognize operator " + _operator + "");
            }
            
            if (r1 > 65535)
            {
                throw new OverflowException("Error in UMath.Algebra(), (" + a.ToString() + " " + _operator + " " + b.ToString() + ") is outside of ushort bounds.");
            }

            if (r1 < 0)
            {
                throw new ArgumentException("Error in UMath.Algebra(), (" + a.ToString() + " " + _operator + " " + b.ToString() + ") is negative.");
            }

            r = (ushort)r1;
            return r;
        }
    }
}
