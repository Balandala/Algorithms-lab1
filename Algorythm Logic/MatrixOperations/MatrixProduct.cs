using Algorythms_Logic.Algorythms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorythms_Logic.MatrixOperations
{
    public class MatrixProduct : MatrixOperation
    {
        public override int MaxArraySize => 1000;
        public override string Description => "Умножение матриц";
        public override int NumberOfOperands => 2;
        public override void Execute(params int[][,] matrices)
        {
            int[,] mx1 = matrices[0];
            int[,] mx2 = matrices[1];
            int size = mx1.GetLength(0);
            int[,] result = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < size; k++)
                    {
                        sum += mx1[i, k] * mx2[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            return;
        }
    }
}
