using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace tasks_foris
{
	/// <summary>
	/// 1.	Ломай меня полностью.
	/// Реализуйте метод FailProcess так, чтобы процесс завершался.Предложите побольше различных решений.
	/// </summary>
	class Task1
	{
		static void Run()
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
			Process.GetCurrentProcess().Kill();

			// Либо как-нибудь сломать программу
			FailProcess();
		}
	}
}