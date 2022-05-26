using System;
using System.Collections.Generic;
using System.Linq;

namespace tasks_foris
{
    /// <summary>
    /// 3.	Мне только спросить!
    /// Реализуйте метод по сигнатуре (метод EnumerateFromTail)
    /// </summary>
    public static class Task3
    {
        /// <summary>
        /// <para> Отсчитать несколько элементов с конца </para>
        /// <example> new[] {1,2,3,4}.EnumerateFromTail(2) = (1, ), (2, ), (3, 1), (4, 0)</example>
        /// </summary> 
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="tailLength">Сколько элеметнов отсчитать с конца  (у последнего элемента tail = 0)</param>
        /// <returns></returns>
        public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
        {
            int? tail = 0;
            int len = enumerable.Count();
            IEnumerable<(T, int?)> arr = new List<(T, int?)>();

            // Начинаем с конца enumerable, чтобы List не был перевернутым задом наперед, используем метод Prepend()
            // который добавляет элементы в начало
            for (int i = len - 1; i >= 0; i--)
            {
                if (tailLength - tail <= 0)
                    tail = null;
                
                arr = arr.Prepend((enumerable.ElementAt(i), tail));
                tail += 1;
            }

            return arr;
        }

        public static void Run()
        {
            int[] arr = new int[] { 1, 2, 3, 4 };
            int tailLength = 2;
            var res = arr.EnumerateFromTail(tailLength);

            Console.Write("new[] {");
            foreach (var el in arr)
            {
                if (el == arr.Last())
                    Console.Write(el);
                else
                    Console.Write(el + ", ");
            }
            Console.Write("}.EnumerateFromTail(" + tailLength + ") = ");

            foreach (var el in res)
            {
                if (el == res.Last())
                    Console.Write("(" + el.item + ", " + el.tail + ")");
                else
                    Console.Write("(" + el.item + ", " + el.tail + "), ");
            }
            Console.WriteLine();
        }

    }
}
