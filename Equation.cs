using System;

namespace AssemblyCSharp
{
	public class Equation
	{
		String expression;

		public Equation (String str)
		{
			expression = str;
		}

		static void Main ()
		{
			Console.WriteLine ("Hello, World!");
		}
	}
}

/*L1T1 Создать класс с именем Equation, объекты которого предназначены 
для хранения алгебраических уравнений второго порядка в виде 
ax2+bx+c=0. Определить переменные класса, конструкторы, метод 
вычисления количества корней и метод отображения хранящейся в объекте 
информации.*/