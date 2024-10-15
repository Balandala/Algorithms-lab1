using Algorythms_Logic.Algorythms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorythm_Logic.Algorythms
{
    public class RadixSort : Algorythm
    {
        public override string Description => "Поразрядная сортировка";
        public override int MaxArraySize => 5000000;

        public override void Execute(int[] array)
        {
            // Если массив пустой, выходим из метода
            if (array.Length == 0)
                return;

            int n = array.Length;
            int max = array.Max();
            // Сортируем по каждому разряду
            for (int exp = 1; max / exp > 0; exp *= 10)
                CountingSort(array, n, exp);
            return;
        }
        private static void CountingSort(int[] arr, int n, int exp)
        {
            int[] output = new int[n];
            int[] count = new int[10];

            // Подсчитываем количество вхождений каждого числа
            for (int i = 0; i < n; i++)
                count[(arr[i] / exp) % 10]++;

            // Изменяем count[], чтобы теперь count[i] содержал реальную позицию цифры в output[]
            for (int i = 1; i < 10; i++)
                count[i] += count[i - 1];

            // Строим выходной массив
            for (int i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            // Копируем отсортированный массив обратно в arr[]
            for (int i = 0; i < n; i++)
                arr[i] = output[i];
        }
    }
}
