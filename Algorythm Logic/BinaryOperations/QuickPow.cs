using Algorythms_Logic.BinaryOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorythm_Logic.BinaryOperations
{
    internal class QuickPow : BinaryOperation
    {
        public override string Description => "Быстрое возведение в степень (QuickPow)";
        public override int MaxArraySize => 2000000000;
        public override int MaxBasisNumber => 2000000000;
        public override void Execute(int number, int exponent)
        {
            Power(number, exponent);
        }
        private static BigInteger Power(int number, int exponent)
        {
            int f;
            if (exponent%2==1)
            {
                f = number;
            }
            else
            {
                f = 1;
            }
            while(exponent!=0)
            {
                exponent=exponent/2;
                number = number * number;
                if (exponent%2==1) 
                {
                    f=f*number;
                }
            }
            return f;
        }
    }
}
