using System;
using System.Globalization;

namespace tasks_foris
{
	/// <summary>
	/// 2.	Операция «Ы».
	/// Что выводится на экран? Измените класс Number так, чтобы на экран выводился результат сложения 
	/// для любых значений someValue1 и someValue2
	/// </summary>
	public class Task2
    {
		static readonly IFormatProvider _ifp = CultureInfo.InvariantCulture;

		class Number
		{
			readonly int _number;

			public Number(int number)
			{
				_number = number;
			}

			public override string ToString()
			{
				return _number.ToString(_ifp);
			}

			/// <summary>
			/// Определение оператора сложения для Number и string
			/// </summary>
			/// <param name="num">Число типа Number</param>
			/// <param name="str">Число типа string</param>
			/// <returns>Результат сложения типа string</returns>
			public static string operator +(Number num, string str)
            {
				int value;

				try
                {
					value = num._number + int.Parse(str, _ifp);
				}
				catch (Exception ex)
                {
					throw ex;
				}

				return value.ToString();
            }
		}

		public static void Run()
		{
			int someValue1 = 10;
			int someValue2 = 5;
			// На экран до определения оператора "+", выводилось 105
			string result = new Number(someValue1) + someValue2.ToString(_ifp);
			Console.WriteLine(result);
			Console.ReadKey();
		}

	}
}
