using Algorythms_Logic.Algorythms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorythms_Logic.BinaryOperations
{
    public abstract class BinaryOperation : Algorythm
    {
        private int stepCount;
        public abstract int StepCount { get; }
        public override abstract string Description { get; }
        public override abstract int MaxArraySize { get; }
        public abstract int MaxBasisNumber { get; }
        public virtual void Execute(int basis, int arg) { }
    }
}
