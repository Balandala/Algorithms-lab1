using Algorythms_Logic.BinaryOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorythm_Logic.BinaryOperations
{
    internal class QuickPowClassic : BinaryOperation
    {
        public override string Description => "Классическое быстрое возведение в степень (QuickPowClassic)";
        public override int MaxArraySize => 2000000000;
        public override int MaxBasisNumber => 2000000000;
        public override void Execute(int number, int exponent)
        {
            Power(number, exponent);
        }
        private static BigInteger Power(int number, int exponent)
        {
            int f=1;
            while (exponent!=0) 
            {
                if (exponent%2==0) 
                {
                    number = number * number;
                    exponent = exponent/2;
                }
                else 
                {
                    f = f * number;
                    exponent = exponent-1;
                }
            }
            
            return f;
        }
    }
}
