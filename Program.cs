using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        Console.InputEncoding = UTF8Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("Виберіть операцію: \n1. Додавання\n2. Віднімання\n3. Множення\n4. Ділення\n5. Корінь квадратний\n6. Піднесення в степінь\n0. Вихід");

            string choice = Console.ReadLine();

            if (choice == "0")
                break;

            try
            {
                switch (choice)
                {
                    case "1":
                        PerformOperation(Add);
                        break;
                    case "2":
                        PerformOperation(Subtract);
                        break;
                    case "3":
                        PerformOperation(Multiply);
                        break;
                    case "4":
                        PerformOperation(Divide);
                        break;
                    case "5":
                        PerformSquareRoot();
                        break;
                    case "6":
                        PerformPower();
                        break;
                    default:
                        Console.WriteLine("Неправильний вибір операції.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Помилка: {ex.Message}");
                Console.ResetColor();
            }
        }
    }

    static void PerformOperation(Func<double, double, double> operation)
    {
        double a = GetInput("Введіть перше число: ");
        double b = GetInput("Введіть друге число: ");
        double result = operation(a, b);
        Console.WriteLine($"Результат: {result}");
    }

    static void PerformSquareRoot()
    {
        double a = GetInput("Введіть число: ");
        if (a < 0)
            throw new ArgumentException("Неможливо взяти корінь з від'ємного числа.");
        double result = Math.Sqrt(a);
        Console.WriteLine($"Результат: {result}");
    }

    static void PerformPower()
    {
        double a = GetInput("Введіть число: ");
        double b = GetInput("Введіть степінь: ");
        if (b < 0)
            throw new ArgumentException("Степінь не може бути від'ємною.");
        double result = Math.Pow(a, b);
        Console.WriteLine($"Результат: {result}");
    }

    static double GetInput(string prompt)
    {
        Console.Write(prompt);
        return double.Parse(Console.ReadLine());
    }

    static double Add(double a, double b) => a + b;
    static double Subtract(double a, double b) => a - b;
    static double Multiply(double a, double b) => a * b;
    static double Divide(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Ділення на нуль неможливе.");
        return a / b;
    }
}
