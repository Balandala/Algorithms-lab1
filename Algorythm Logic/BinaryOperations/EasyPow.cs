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
        private int stepCount;
        public override int StepCount { get { return stepCount; } }
        public override string Description => "Наивный алгоритм возведения в степень";
        public override int MaxArraySize => 200000000;
        public override int MaxBasisNumber => 2000000000;
        public override void Execute(int number, int exponent) 
        {
            stepCount = 0;
            long result = 1;
            if (exponent == 0)
                return;
            for (int i = 0; i < exponent; i++)
            {
                result *= number;
                stepCount++;
            }
            return;
        }
    }
}
