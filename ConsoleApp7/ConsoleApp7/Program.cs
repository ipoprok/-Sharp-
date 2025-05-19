using System;

class SimpleCalculator
{
    static void Main()
    {
        Console.WriteLine("Простой калькулятор");
        Console.WriteLine("Доступные операции:");
        Console.WriteLine("+  - сложение");
        Console.WriteLine("-  - вычитание");
        Console.WriteLine("*  - умножение");
        Console.WriteLine("/  - деление");
        Console.WriteLine("%  - остаток от деления");
        Console.WriteLine("++ - инкремент (увеличение числа на 1)");
        Console.WriteLine("-- - декремент (уменьшение числа на 1)");
        Console.WriteLine();

        while (true)
        {
            Console.Write("Введите операцию (+, -, *, /, %, ++, --) или 'exit' для выхода: ");
            string op = Console.ReadLine();

            if (op == "exit")
                break;

            if (op == "++" || op == "--")
            {
                // Для инкремента и декремента нужен один операнд
                double num = ReadNumber("Введите число: ");
                if (op == "++")
                    num++;
                else
                    num--;
                Console.WriteLine("Результат: " + num);
            }
            else
            {
                // Для остальных операций нужны два числа
                double num1 = ReadNumber("Введите первое число: ");
                double num2 = ReadNumber("Введите второе число: ");

                switch (op)
                {
                    case "+":
                        Console.WriteLine("Результат: " + (num1 + num2));
                        break;
                    case "-":
                        Console.WriteLine("Результат: " + (num1 - num2));
                        break;
                    case "*":
                        Console.WriteLine("Результат: " + (num1 * num2));
                        break;
                    case "/":
                        if (num2 == 0)
                            Console.WriteLine("Ошибка: деление на ноль невозможно!");
                        else
                            Console.WriteLine("Результат: " + (num1 / num2));
                        break;
                    case "%":
                        if (num2 == 0)
                            Console.WriteLine("Ошибка: деление на ноль невозможно!");
                        else
                            Console.WriteLine("Результат: " + (num1 % num2));
                        break;
                    default:
                        Console.WriteLine("Неизвестная операция.");
                        break;
                }
            }

            Console.WriteLine();
        }
    }

    static double ReadNumber(string prompt)
    {
        double number;
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out number))
                return number;
            Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
        }
    }
}