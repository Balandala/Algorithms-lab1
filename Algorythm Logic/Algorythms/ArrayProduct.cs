using Algorythms_Logic.Algorythms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorythm_Logic.Algorythms
{
    public class ArrayProduct : Algorythm
    {
        public override string Description => "Перемножение всех чисел в массиве";
        public override int MaxArraySize => 200000;

        public override void Execute(int[] array)
        {
            long sum = 1;
            foreach (int num in array)
            {
                if (Math.Abs(sum - long.MaxValue) < Math.Abs(num))
                    sum = 1;
                else
                    sum *= num;
            }
            return;
        }
    }
}
