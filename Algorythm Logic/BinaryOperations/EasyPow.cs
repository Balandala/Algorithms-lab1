using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorythms_Logic.BinaryOperations
{
    internal class EasyPow : BinaryOperation
    {
        public override string Description => "Наивный алгоритм возведения в степень";
        public override int MaxArraySize => 2000000000;
        public override int MaxBasisNumber => 2000000000;
        public override void Execute(int basis, int arg) 
        {
            BigInteger result = BigInteger.One;
            if (arg == 0)
                return;
            for (int i = 0; i < arg; i++)
            {
                result = BigInteger.Multiply(result, basis);
            }
            return;
        }
    }
}
