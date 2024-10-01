using Algorythms_Logic.Algorythms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorythms_Logic.Algorythms
{
    public class ArrayProduct : Algorythm
    {
        public override string Description => "Перемножение всех чисел в массиве";
        public override int MaxArraySize => 6000;

        public override void Execute(int[] array)
        {
            BigInteger prod = 1;
            foreach (int num in array)
            {
                prod = BigInteger.Multiply(prod, num);
            }
            return;
        }
    }
}
