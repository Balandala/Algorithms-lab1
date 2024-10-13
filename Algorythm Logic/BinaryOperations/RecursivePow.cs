using Algorythms_Logic.BinaryOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorythm_Logic.BinaryOperations
{
    internal class RecursivePow : BinaryOperation
    {
        private int stepCount;
        public override int StepCount { get { return stepCount; } }
        public override string Description => "Возведение в степень (рекурсивный алгоритм)";
        public override int MaxArraySize => 2000000000;
        public override int MaxBasisNumber => 2000000000;
        public override void Execute(int number, int exponent)
        {
            stepCount = 0;
            Power(number, exponent);
        }
        private long Power(int number, int exponent)
        {
            // Базовый случай: если степень равна 0, возвращаем 1
            if (exponent == 0)
            {
                stepCount++;
                return 1;
            }

            // Рекурсивный случай: уменьшаем степень вдвое и умножаем результат на себя
            long temp = Power(number, exponent / 2);

            // Если степень четная
            if (exponent % 2 == 0)
            {
                stepCount++;
                return temp * temp;
            }
            // Если степень нечетная
            else
            {
                stepCount++;
                return number * temp * temp;
            }
        }
    }
}
