using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorythms_Logic.Algorythms
{
    public class Constant : Algorythm
    {
        private int maxArraySize = 10000;
        public new int MaxArraySize
        {
            get { return maxArraySize; }
        }
        public override void Execute(int[] array)
        {
            return;
        }
    }
}
