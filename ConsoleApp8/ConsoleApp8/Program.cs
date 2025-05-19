using System;
using System.Collections.Generic;

namespace InteractiveNovel
{
    class Program
    {
        // Хранение состояния игрока (например, очки, предметы, решения)
        static int courage = 0;
        static int wisdom = 0;
        static bool hasKey = false;
        static bool hasFriend = false;

        static void Main()
        {
            Console.WriteLine("Добро пожаловать в интерактивную новеллу!");
            Console.WriteLine("Чтобы выйти из игры в любой момент, введите 'exit'.\n");

            while (true)
            {
                Step1();
            }
        }

        static void Step1()
        {
            Console.WriteLine("Вы просыпаетесь в темной комнате. Что вы делаете?");
            Console.WriteLine("1) Осмотреться");
            Console.WriteLine("2) Позвать на помощь");
            Console.WriteLine("3) Попытаться открыть дверь");

            string choice = ReadChoice(3);

            switch (choice)
            {
                case "1":
                    courage++;
                    Step2();
                    break;
                case "2":
                    wisdom++;
                    Step3();
                    break;
                case "3":
                    Step4();
                    break;
            }
        }

        static void Step2()
        {
            Console.WriteLine("\nВы осматриваетесь и находите ключ на полу.");
            Console.WriteLine("1) Взять ключ");
            Console.WriteLine("2) Игнорировать ключ");

            string choice = ReadChoice(2);

            if (choice == "1")
            {
                hasKey = true;
                Console.WriteLine("Вы взяли ключ.");
                Step5();
            }
            else
            {
                Step6();
            }
        }

        static void Step3()
        {
            Console.WriteLine("\nВаши крики услышал странник и пришел на помощь.");
            hasFriend = true;
            Step7();
        }

        static void Step4()
        {
            Console.WriteLine("\nДверь заперта, и вы не можете её открыть.");
            Step2();
        }

        static void Step5()
        {
            Console.WriteLine("\nВы нашли тайный проход.");
            Console.WriteLine("1) Войти в проход");
            Console.WriteLine("2) Вернуться к двери");

            string choice = ReadChoice(2);

            if (choice == "1")
                Step8();
            else
                Step9();
        }

        static void Step6()
        {
            Console.WriteLine("\nВы игнорируете ключ и остаетесь в комнате.");
            Console.WriteLine("1) Позвать на помощь");
            Console.WriteLine("2) Попытаться открыть дверь снова");

            string choice = ReadChoice(2);

            if (choice == "1")
                Step3();
            else
                Step4();
        }

        static void Step7()
        {
            Console.WriteLine("\nСтранник предлагает помочь выбраться.");
            Console.WriteLine("1) Пойти с ним");
            Console.WriteLine("2) Отказаться и искать выход самостоятельно");

            string choice = ReadChoice(2);

            if (choice == "1")
                Step10();
            else
                Step11();
        }

        static void Step8()
        {
            Console.WriteLine("\nПроход ведет в подземелье.");
            Console.WriteLine("1) Исследовать подземелье");
            Console.WriteLine("2) Вернуться назад");

            string choice = ReadChoice(2);

            if (choice == "1")
                Step12();
            else
                Step9();
        }

        static void Step9()
        {
            Console.WriteLine("\nВы возвращаетесь к двери.");
            if (hasKey)
            {
                Console.WriteLine("Вы используете ключ, чтобы открыть дверь.");
                Step13();
            }
            else
            {
                Console.WriteLine("Дверь заперта, и у вас нет ключа.");
                Step6();
            }
        }

        static void Step10()
        {
            Console.WriteLine("\nВместе с другом вы выходите из здания.");
            EndingGood1();
        }

        static void Step11()
        {
            Console.WriteLine("\nВы заблудились и попали в ловушку.");
            EndingBad1();
        }

        static void Step12()
        {
            Console.WriteLine("\nВ подземелье вы находите древний артефакт.");
            wisdom++;
            Console.WriteLine("1) Взять артефакт");
            Console.WriteLine("2) Оставить артефакт");

            string choice = ReadChoice(2);

            if (choice == "1")
                Step14();
            else
                Step15();
        }

        static void Step13()
        {
            Console.WriteLine("\nВы выходите на свободу.");
            if (courage > 1)
                EndingGood2();
            else
                EndingNeutral();
        }

        static void Step14()
        {
            Console.WriteLine("\nАртефакт дает вам силу.");
            courage++;
            EndingGood3();
        }

        static void Step15()
        {
            Console.WriteLine("\nВы оставляете артефакт и уходите.");
            EndingNeutral();
        }

        // Дополнительные шаги для достижения 20+

        static void Step16()
        {
            Console.WriteLine("\nВы встречаете загадочного старца.");
            Console.WriteLine("1) Поговорить с ним");
            Console.WriteLine("2) Игнорировать и идти дальше");

            string choice = ReadChoice(2);

            if (choice == "1")
            {
                wisdom++;
                Step17();
            }
            else
            {
                Step18();
            }
        }

        static void Step17()
        {
            Console.WriteLine("\nСтарец дает вам мудрый совет.");
            EndingGood4();
        }

        static void Step18()
        {
            Console.WriteLine("\nВы заблудились в лесу.");
            EndingBad2();
        }

        static void Step19()
        {
            Console.WriteLine("\nВы находите лодку у реки.");
            Console.WriteLine("1) Переплыть реку");
            Console.WriteLine("2) Идти вдоль берега");

            string choice = ReadChoice(2);

            if (choice == "1")
                EndingBad3();
            else
                EndingGood5();
        }

        static void Step20()
        {
            Console.WriteLine("\nВы видите свет вдалеке.");
            Console.WriteLine("1) Идти к свету");
            Console.WriteLine("2) Остаться на месте");

            string choice = ReadChoice(2);

            if (choice == "1")
                EndingGood6();
            else
                EndingBad4();
        }

        // Концовки

        static void EndingGood1()
        {
            Console.WriteLine("\nКонцовка: Вы спасены благодаря другу. Поздравляем!");
            EndGame();
        }

        static void EndingGood2()
        {
            Console.WriteLine("\nКонцовка: Вы смело вышли на свободу. Отличная работа!");
            EndGame();
        }

        static void EndingGood3()
        {
            Console.WriteLine("\nКонцовка: С силой артефакта вы стали героем!");
            EndGame();
        }

        static void EndingGood4()
        {
            Console.WriteLine("\nКонцовка: Мудрость старца помогла вам найти путь домой.");
            EndGame();
        }

        static void EndingGood5()
        {
            Console.WriteLine("\nКонцовка: Вы нашли безопасный путь вдоль реки.");
            EndGame();
        }

        static void EndingGood6()
        {
            Console.WriteLine("\nКонцовка: Свет привел вас к спасению.");
            EndGame();
        }

        static void EndingNeutral()
        {
            Console.WriteLine("\nКонцовка: Вы вышли из приключения целым, но без особых достижений.");
            EndGame();
        }

        static void EndingBad1()
        {
            Console.WriteLine("\nКонцовка: Вы попали в ловушку и не смогли выбраться.");
            EndGame();
        }

        static void EndingBad2()
        {
            Console.WriteLine("\nКонцовка: Вы заблудились в лесу и потеряли надежду.");
            EndGame();
        }

        static void EndingBad3()
        {
            Console.WriteLine("\nКонцовка: Река была слишком быстрой, и вы утонули.");
            EndGame();
        }

        static void EndingBad4()
        {
            Console.WriteLine("\nКонцовка: Вы остались на месте и были найдены слишком поздно.");
            EndGame();
        }

        // Метод для завершения игры и выхода или рестарта
        static void EndGame()
        {
            Console.WriteLine("\nХотите сыграть снова? (да/нет)");
            string answer = Console.ReadLine().ToLower();
            if (answer == "да" || answer == "yes")
            {
                // Сбросить состояние
                courage = 0;
                wisdom = 0;
                hasKey = false;
                hasFriend = false;
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Спасибо за игру!");
                Environment.Exit(0);
            }
        }

        // Метод для чтения выбора пользователя с ограничением вариантов
        static string ReadChoice(int optionsCount)
        {
            while (true)
            {
                Console.Write("Ваш выбор: ");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "exit")
                {
                    Console.WriteLine("Выход из игры...");
                    Environment.Exit(0);
                }

                // Принимаем как номер варианта (1, 2, 3...)
                if (int.TryParse(input, out int choiceNum))
                {
                    if (choiceNum >= 1 && choiceNum <= optionsCount)
                        return choiceNum.ToString();
                }

                Console.WriteLine($"Пожалуйста, введите число от 1 до {optionsCount} или 'exit' для выхода.");
            }
        }
    }
}
