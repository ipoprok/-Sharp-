using System;

namespace BankAndMathTasks
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите задачу для выполнения:");
                Console.WriteLine("1 - Сумма вклада с ежемесячным начислением 7% (for)");
                Console.WriteLine("2 - Сумма вклада с ежемесячным начислением 7% (while)");
                Console.WriteLine("3 - Таблица умножения");
                Console.WriteLine("4 - Умножение двух чисел с проверкой диапазона");
                Console.WriteLine("0 - Выход");
                Console.Write("Введите номер задачи: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DepositWithFor();
                        break;
                    case "2":
                        DepositWithWhile();
                        break;
                    case "3":
                        MultiplicationTable();
                        break;
                    case "4":
                        MultiplyWithRangeCheck();
                        break;
                    case "0":
                        Console.WriteLine("Выход из программы...");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
                Console.ReadKey();
            }
        }

        // Задача 1: Сумма вклада с for
        static void DepositWithFor()
        {
            Console.Clear();
            Console.WriteLine("Задача 1: Сумма вклада с ежемесячным начислением 7% (for)");

            decimal deposit = ReadDecimal("Введите сумму вклада: ");
            int months = ReadInt("Введите количество месяцев: ");

            decimal amount = deposit;
            for (int i = 0; i < months; i++)
            {
                amount += amount * 0.07m;
            }

            Console.WriteLine($"Конечная сумма вклада через {months} месяцев: {amount:F2}");
        }

        // Задача 2: Сумма вклада с while
        static void DepositWithWhile()
        {
            Console.Clear();
            Console.WriteLine("Задача 2: Сумма вклада с ежемесячным начислением 7% (while)");

            decimal deposit = ReadDecimal("Введите сумму вклада: ");
            int months = ReadInt("Введите количество месяцев: ");

            decimal amount = deposit;
            int i = 0;
            while (i < months)
            {
                amount += amount * 0.07m;
                i++;
            }

            Console.WriteLine($"Конечная сумма вклада через {months} месяцев: {amount:F2}");
        }

        // Задача 3: Таблица умножения
        static void MultiplicationTable()
        {
            Console.Clear();
            Console.WriteLine("Задача 3: Таблица умножения (1-10)");

            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.Write($"{i * j,4}");
                }
                Console.WriteLine();
            }
        }

        // Задача 4: Умножение с проверкой диапазона
        static void MultiplyWithRangeCheck()
        {
            Console.Clear();
            Console.WriteLine("Задача 4: Умножение двух чисел с проверкой диапазона [0..10]");

            while (true)
            {
                int num1 = ReadInt("Введите первое число (0-10): ");
                int num2 = ReadInt("Введите второе число (0-10): ");

                if (num1 < 0 || num1 > 10 || num2 < 0 || num2 > 10)
                {
                    Console.WriteLine("Введённые числа недопустимы. Числа должны быть от 0 до 10.\n");
                    continue;
                }

                int product = num1 * num2;
                Console.WriteLine($"Результат умножения: {product}");
                break;
            }
        }

        // Вспомогательный метод для чтения целого числа с проверкой
        static int ReadInt(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result))
                    return result;
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
        }

        // Вспомогательный метод для чтения десятичного числа с проверкой
        static decimal ReadDecimal(string prompt)
        {
            decimal result;
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out result))
                    return result;
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
        }
    }
}