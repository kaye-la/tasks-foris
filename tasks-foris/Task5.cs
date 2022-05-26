using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace tasks_foris
{
    /// <summary>
    /// 5.	Слон из мухи.
    /// Программа выводит на экран строку «Муха», а затем продолжает выполнять остальной код.
    /// Реализуйте метод TransformToElephant так, чтобы программа выводила на экран строку «Слон», 
    /// а затем продолжала выполнять остальной код, не выводя перед этим на экран строку «Муха».
    /// </summary>
    public class Task5
    {
        public static void Run()
        {
            TransformToElephant();
            Console.WriteLine("Муха");
            Console.WriteLine("Муха2");
            Console.WriteLine("Муха3");
            Console.WriteLine("Муха");
            Console.WriteLine("Муха4");
            Console.WriteLine("Муха5");
        }

        static void TransformToElephant()
        {
            Console.WriteLine("Слон");
            // При вызове класса, сохраняет исходный вывод. При запуске в первый раз Console.WriteLine() присваивает исходный вывод
            // тем самым "Муха" не отобразится в первый раз 
            Console.SetOut(new ConsoleWriter());
        }

        class ConsoleWriter : StringWriter
        {
            TextWriter _tWriter;

            public ConsoleWriter()
            {
               _tWriter = Console.Out;
            }

            public override void WriteLine(string value)
            {
                Console.SetOut(_tWriter);
            }
        }

    }
}
