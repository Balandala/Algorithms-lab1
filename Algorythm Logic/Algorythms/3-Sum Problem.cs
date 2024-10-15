using Algorythms_Logic.Algorythms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorythm_Logic.Algorythms
{
    internal class _3_Sum_Problem : Algorythm
    {
        public override string Description => "Нахождение троек в массиве, сумма которых равно 0";
        public override int MaxArraySize => 30000;

        public override void Execute(int[] array)
        {
            List<int[]> triplets = FindTriplets(array);
            return;
        }
        private static List<int[]> FindTriplets(int[] array)
        {
            List<int[]> triplets = new List<int[]>();
            int n = array.Length;

            // Сортируем массив
            Array.Sort(array);

            // Перебираем элементы массива
            for (int i = 0; i < n - 2; i++)
            {
                // Пропускаем дубликаты
                if (i > 0 && array[i] == array[i - 1])
                    continue;

                int left = i + 1;
                int right = n - 1;

                while (left < right)
                {
                    int sum = array[i] + array[left] + array[right];

                    if (sum == 0)
                    {
                        triplets.Add(new int[] { array[i], array[left], array[right] });

                        // Пропускаем дубликаты
                        while (left < right && array[left] == array[left + 1])
                            left++;
                        while (left < right && array[right] == array[right - 1])
                            right--;

                        left++;
                        right--;
                    }
                    else if (sum < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return triplets;
        }
    }
}
