using Algorythms_Logic.Algorythms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorythms_Logic.MatrixOperations
{
    public abstract class MatrixOperation : Algorythm
    {
        public override abstract int MaxArraySize { get; }
        public override abstract string Description { get; }
        public abstract int NumberOfOperands { get; }
        public virtual void Execute(params int[][,] matrices) { }
    }
}
