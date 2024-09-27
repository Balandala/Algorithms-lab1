using Algorythms_Logic.Algorythms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorythm_Logic.Algorythms
{
    public class ArrayMult : Algorythm
    {
        private int maxArraySize = 10000;
        public new int MaxArraySize
        {
            get { return maxArraySize; }
        }
        public override void Execute(int[] array)
        {
            long sum = 1;
            foreach (int num in array)
            {
                if (Math.Abs(sum - long.MaxValue) < num)
                    sum = 1;
                else
                    sum *= num;
            }
            return;
        }
    }
}
