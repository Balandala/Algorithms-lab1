using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorythms_Logic.Algorythms
{
    public abstract class Algorythm
    {
        private int maxArraySize;
        public int MaxArraySize
        {
            get { return maxArraySize; }
        }
        public abstract void Execute(int[] array);
    }
}
