using Algorythms_Logic.Algorythms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorythm_Logic.Algorythms
{
    public class TimSort:Algorythm
    {
        public override string Description => "Гибридный алгоритм сортировки Timsort";
        public override int MaxArraySize => 100000;

        public override void Execute(int[] array)
        {
            Timsort_(array);
        }
        private static void Timsort_(int[] array)
        {
            int minRun = CalculateMinRun(array.Length);
            List<int[]> runs = new List<int[]>();

            // Разделение массива на "runs"
            int start = 0;
            while (start < array.Length)
            {
                int end = FindRun(array, start);
                int[] run = new int[end - start];
                Array.Copy(array, start, run, 0, run.Length);
                InsertionSort(run);
                runs.Add(run);
                start = end;
            }

            // Слияние "runs"
            while (runs.Count > 1)
            {
                int[] run1 = runs[0];
                int[] run2 = runs[1];
                runs.RemoveAt(0);
                runs.RemoveAt(0);
                int[] mergedRun = Merge(run1, run2);
                runs.Add(mergedRun);
            }

            // Копирование отсортированных данных обратно в массив
            if (runs.Count > 0)
            {
                Array.Copy(runs[0], 0, array, 0, array.Length);
            }
        }

        private static int CalculateMinRun(int n)
        {
            int r = 0;
            while (n >= 64)
            {
                r |= n & 1;
                n >>= 1;
            }
            return n + r;
        }

        private static int FindRun(int[] array, int start)
        {
            int end = start + 1;
            if (end >= array.Length)
                return end;

            if (array[start] > array[end])
            {
                while (end < array.Length && array[end - 1] > array[end])
                    end++;
                Reverse(array, start, end - 1);
            }
            else
            {
                while (end < array.Length && array[end - 1] <= array[end])
                    end++;
            }

            return end;
        }

        private static void Reverse(int[] array, int start, int end)
        {
            while (start < end)
            {
                int temp = array[start];
                array[start] = array[end];
                array[end] = temp;
                start++;
                end--;
            }
        }

        private static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }

        private static int[] Merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];
            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    result[k] = left[i];
                    i++;
                }
                else
                {
                    result[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < left.Length)
            {
                result[k] = left[i];
                i++;
                k++;
            }

            while (j < right.Length)
            {
                result[k] = right[j];
                j++;
                k++;
            }

            return result;
        }
    }
}
