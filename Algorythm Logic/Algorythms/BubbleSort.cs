using Algorythms_Logic.Algorythms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace Algorythm_Logic.Algorythms
{
    public class BubbleSort:Algorythm
    {
        public override string Description => "Сортировка Пузырьком";
        public override int MaxArraySize => 30000;

        public override void Execute(int[] array)
        {
            int n= array.Length;
            bool swapped;

            for (int i= 0;i<n-1;i++ ) 
            {
                swapped = false;

                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
            }
            return;
        }
    }
}
