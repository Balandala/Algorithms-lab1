using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorythms_Logic.Algorythms
{
    public abstract class Algorythm
    {
        public abstract string Description { get; }
        public abstract int MaxArraySize { get; }
        public virtual void Execute(int[] array) { }
    }
}
