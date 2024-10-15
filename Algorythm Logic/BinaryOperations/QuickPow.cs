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
        private int stepCount;
        public override int StepCount { get { return stepCount; } }
        public override string Description => "Быстрое возведение в степень (QuickPow)";
        public override int MaxArraySize => 2000000000;
        public override int MaxBasisNumber => 2000000000;
        public override void Execute(int number, int exponent)
        {
            stepCount = 0;
            Power(number, exponent);
        }
        private long Power(int number, int exponent)
        {
            long f;
            if (exponent%2==1)
            {
                f = number;
                stepCount++;
            }
            else
            {
                f = 1;
                stepCount++;
            }
            while(exponent!=0)
            {
                exponent=exponent/2;
                number = number * number;
                if (exponent%2==1) 
                {
                    f=f*number;
                }
                stepCount++;
            }
            return f;
        }
    }
}
