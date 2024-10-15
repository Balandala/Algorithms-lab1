using Algorythms_Logic.Algorythms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorythm_Logic.Algorythms
{
    public class QuickSort : Algorythm
    {
        public override string Description => "Быстрая сортировка";
        public override int MaxArraySize => 10000000;

        public override void Execute(int[] array)
        {
            QuickSort_(array, 0,array.Length-1);
        }
        private static void QuickSort_(int[] array, int low, int high)
        {
            if (low < high)
            {
                // Находим индекс опорного элемента
                int pi = Partition(array, low, high);

                // Рекурсивно сортируем элементы до и после опорного элемента
                QuickSort_(array, low, pi - 1);
                QuickSort_(array, pi + 1, high);
            }
        }
        private static int Partition(int[] array, int low, int high)
        {
            // Опорный элемент (pivot) - последний элемент массива
            int pivot = array[high];
            int i = low - 1;

            for (int j=low;j<high;j++)
            {
                // Если текущий элемент меньше или равен опорному
                if (array[j]<= pivot)
                {
                    i++;

                    // Меняем местами array[i] и array[j]
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
            // Меняем местами array[i+1] и опорный элемент (array[high])
            int temp1 = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp1;
            return i + 1;
        }
    }
}
