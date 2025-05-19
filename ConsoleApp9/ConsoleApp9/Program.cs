using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticalTasksApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задача 1: Сумма чисел в списке
            Console.WriteLine("Задача 1: Сумма чисел в списке");
            List<int> numbers = ReadIntListFromConsole();
            int sum = SumList(numbers);
            Console.WriteLine($"Сумма чисел: {sum}\n");

            // Задача 2: Проверка на палиндром
            Console.WriteLine("Задача 2: Проверка на палиндром");
            Console.Write("Введите строку: ");
            string inputStr = Console.ReadLine();
            bool isPalindrome = IsPalindrome(inputStr);
            Console.WriteLine(isPalindrome ? "Строка является палиндромом" : "Строка не является палиндромом");
            Console.WriteLine();

            // Задача 3: Факториал числа
            Console.WriteLine("Задача 3: Факториал числа");
            Console.Write("Введите неотрицательное целое число: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n >= 0)
            {
                long fact = Factorial(n);
                Console.WriteLine($"Факториал числа {n} равен {fact}\n");
            }
            else
            {
                Console.WriteLine("Некорректный ввод\n");
            }

            // Задача 4: Поиск максимального элемента в списке
            Console.WriteLine("Задача 4: Поиск максимального элемента в списке");
            Console.WriteLine("Введите список чисел для поиска максимума:");
            List<int> numbersForMax = ReadIntListFromConsole();
            try
            {
                int max = MaxElement(numbersForMax);
                Console.WriteLine($"Максимальный элемент: {max}\n");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message + "\n");
            }

            // Задача 5: Удаление дубликатов из списка
            Console.WriteLine("Задача 5: Удаление дубликатов из списка");
            Console.WriteLine("Введите список чисел для удаления дубликатов:");
            List<int> numbersWithDuplicates = ReadIntListFromConsole();
            List<int> distinctNumbers = RemoveDuplicates(numbersWithDuplicates);
            Console.WriteLine("Список без дубликатов:");
            Console.WriteLine(string.Join(", ", distinctNumbers));

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Метод для чтения списка целых чисел из консоли (числа разделяются пробелами)
        static List<int> ReadIntListFromConsole()
        {
            while (true)
            {
                Console.Write("Введите числа через пробел: ");
                string line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine("Пустой ввод. Попробуйте снова.");
                    continue;
                }

                string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                List<int> result = new List<int>();
                bool allParsed = true;

                foreach (var part in parts)
                {
                    if (int.TryParse(part, out int num))
                    {
                        result.Add(num);
                    }
                    else
                    {
                        Console.WriteLine($"Некорректное число: {part}. Попробуйте снова.");
                        allParsed = false;
                        break;
                    }
                }

                if (allParsed)
                    return result;
            }
        }

        static int SumList(List<int> numbers)
        {
            int sum = 0;
            foreach (var num in numbers)
                sum += num;
            return sum;
        }

        static bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;

            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                if (s[left] != s[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }

        static long Factorial(int n)
        {
            if (n <= 1)
                return 1;
            return n * Factorial(n - 1);
        }

        static int MaxElement(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                throw new ArgumentException("Список не должен быть пустым");

            int max = numbers[0];
            foreach (var num in numbers)
            {
                if (num > max)
                    max = num;
            }
            return max;
        }

        static List<int> RemoveDuplicates(List<int> numbers)
        {
            return numbers.Distinct().ToList();
        }
    }
}
