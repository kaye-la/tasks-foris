using System;
using System.Diagnostics;

namespace tasks_foris
{
	/// <summary>
	/// 1.	Ломай меня полностью.
	/// Реализуйте метод FailProcess так, чтобы процесс завершался.Предложите побольше различных решений.
	/// </summary>
	public class Task1
	{
		public static void Run()
		{
			try
			{
				FailProcess();
			}
			catch { }

			Console.WriteLine("Failed to fail process!");
			Console.ReadKey();
		}

		/// <summary>
		/// Метод завершает текущий процесс программы
		/// </summary>
		static void FailProcess()
		{
			// Два метода, которые завершают текущий процесс:
			// Environment.Exit(0);
			// Process.GetCurrentProcess().Kill();

			// Если нужно завершить определенный процесс (например, word.exe)
			foreach (Process process in Process.GetProcessesByName("word"))
			{
				process.Kill();
			}
		}
	}
}