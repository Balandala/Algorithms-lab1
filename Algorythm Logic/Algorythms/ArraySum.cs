using Algorythms_Logic.Algorythms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorythms_Logic.Algorythms
{ 
    public class ArraySum : Algorythm
    {
        public override string Description => "Сложение всех чисел в массиве";
        public override int MaxArraySize => 200000;

        public override void Execute(int[] array)
        {
            BigInteger sum = 0;
            foreach (int num in array)
            {
                sum = BigInteger.Add(sum, num);
            }
            return;
        }
    }
}
