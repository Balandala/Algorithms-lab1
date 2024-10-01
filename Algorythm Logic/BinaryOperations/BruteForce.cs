﻿using Algorythms_Logic.BinaryOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorythm_Logic.BinaryOperations
{
    internal class BruteForce : BinaryOperation
    {
        public override string Description => "Полный перебор";
        public override int MaxArraySize => 10;
        public override int MaxBasisNumber => 10;
        public override void Execute(int basis, int arg)
        {
            string digits = "0123456789";
            string choosenDigits = digits.Substring(0, basis);
            StartBruteForce("", arg, choosenDigits);
        }
        private static void StartBruteForce(string result, int maxLength, string abc)
        {
            if (result.Length == maxLength)
            {
                return;
            }
            else
            {
                for (int i = 0; i < abc.Length; i++) 
                {
                    StartBruteForce(result + abc[i], maxLength, abc);
                }
            }
        }
    }
}
