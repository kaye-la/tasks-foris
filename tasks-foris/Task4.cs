using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tasks_foris
{
    /// <summary>
    /// 4.	Высший сорт.
    /// Реализуйте метод Sort.Известно, что потребители метода зачастую не будут вычитывать данные до конца.
    /// </summary>
    public class Task4
    {
        /// <summary>
        /// Возвращает отсортированный по возрастанию поток чисел
        /// </summary>
        /// <param name="inputStream">Поток чисел от 0 до maxValue. Длина потока не превышает миллиарда чисел.</param>
        /// <param name="sortFactor">Фактор упорядоченности потока. Неотрицательное число. Если в потоке встретилось число x, то в нём больше не встретятся числа меньше, чем (x - sortFactor).</param>
        /// <param name="maxValue">Максимально возможное значение чисел в потоке. Неотрицательное число, не превышающее 2000.</param>
        /// <returns>Отсортированный по возрастанию поток чисел.</returns>
        static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
        {
            if (inputStream == null)
                throw new ArgumentNullException("inputStream is null");
            if (sortFactor < 0)
                throw new ArgumentOutOfRangeException("sortFactor must be >= 0");
            if (maxValue > 2000 || maxValue < 0)
                throw new ArgumentOutOfRangeException("maxValue range = 0-2000");

            int[] arr = inputStream.ToArray();
            int currIndex = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > arr[currIndex] || i + 1 == arr.Length)
                {
                    int[] temp = new int[i - currIndex + 1];
                    Array.Copy(arr, currIndex, temp, 0, i - currIndex + 1);
                    HeapSort(temp);
                    Array.Copy(temp, 0, arr, currIndex, i - currIndex + 1);
                    currIndex = i;
                }
            }
            return arr;
        }

        public static void HeapSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
                MakeHeap(arr, n, i);
            for (int i = n - 1; i > 0; i--)
            {
                Swap(arr, 0, i);
                MakeHeap(arr, i, 0);
            }
        }

        /// <summary>
        /// Вспомогательный метод для создания кучи для i элемента (root - max element)
        /// </summary>
        private static void MakeHeap(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[left] > arr[largest])
                largest = left;
            if (right < n && arr[right] > arr[largest])
                largest = right;
            if (largest != i)
            {
                Swap(arr, i, largest);
                MakeHeap(arr, n, largest);
            }
        }

        private static void Swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        public static void Run()
        {
            List<int> list = new List<int>() { 11, 7, 6, 8, 9, 10, 16, 15, 11, 13, 15, 12, 20, 22, 21 };

            IEnumerable<int> arr = Sort(list, 5, 20);
            foreach (var a in arr)
                Console.Write(a + " ");
        }
    }
}
