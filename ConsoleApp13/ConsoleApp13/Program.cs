using System;
using System.IO;

class DiskManager
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Управление дисками и содержимым ===");
            Console.WriteLine("Доступные диски:");

            DriveInfo[] drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {drives[i].Name} ({drives[i].DriveType})");
            }
            Console.WriteLine("0. Выход");
            Console.Write("Выберите диск для работы: ");

            if (!int.TryParse(Console.ReadLine(), out int diskChoice) || diskChoice < 0 || diskChoice > drives.Length)
            {
                Console.WriteLine("Некорректный ввод. Нажмите любую клавишу для повторного выбора.");
                Console.ReadKey();
                continue;
            }

            if (diskChoice == 0)
            {
                Console.WriteLine("Выход из программы...");
                break;
            }

            DriveInfo selectedDrive = drives[diskChoice - 1];

            if (!selectedDrive.IsReady)
            {
                Console.WriteLine("Диск не готов к работе. Нажмите любую клавишу.");
                Console.ReadKey();
                continue;
            }

            ManageDrive(selectedDrive);
        }
    }

    static void ManageDrive(DriveInfo drive)
    {
        string currentPath = drive.RootDirectory.FullName;

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Работа с диском: {drive.Name}");
            Console.WriteLine($"Свободное место: {drive.AvailableFreeSpace / (1024 * 1024)} МБ из {drive.TotalSize / (1024 * 1024)} МБ");
            Console.WriteLine($"Текущая директория: {currentPath}");
            Console.WriteLine();

            Console.WriteLine("Содержимое директории:");
            try
            {
                string[] directories = Directory.GetDirectories(currentPath);
                string[] files = Directory.GetFiles(currentPath);

                Console.WriteLine("Папки:");
                for (int i = 0; i < directories.Length; i++)
                    Console.WriteLine($"  D{i + 1}: {Path.GetFileName(directories[i])}");

                Console.WriteLine("Файлы:");
                for (int i = 0; i < files.Length; i++)
                    Console.WriteLine($"  F{i + 1}: {Path.GetFileName(files[i])}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при чтении содержимого: " + ex.Message);
            }

            Console.WriteLine("\nДоступные команды:");
            Console.WriteLine(" cd D<number> - перейти в папку");
            Console.WriteLine(" up           - подняться на уровень выше");
            Console.WriteLine(" info         - информация о диске");
            Console.WriteLine(" createfile   - создать новый файл");
            Console.WriteLine(" createdir    - создать новую папку");
            Console.WriteLine(" deletefile   - удалить файл");
            Console.WriteLine(" deletedir    - удалить папку");
            Console.WriteLine(" exit         - вернуться к выбору диска");

            Console.Write("\nВведите команду: ");
            string input = Console.ReadLine().Trim();

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                break;

            if (input.Equals("info", StringComparison.OrdinalIgnoreCase))
            {
                ShowDriveInfo(drive);
                continue;
            }

            if (input.Equals("up", StringComparison.OrdinalIgnoreCase))
            {
                if (currentPath != drive.RootDirectory.FullName)
                {
                    currentPath = Directory.GetParent(currentPath).FullName;
                }
                else
                {
                    Console.WriteLine("Вы уже в корне диска.");
                    Console.ReadKey();
                }
                continue;
            }

            if (input.StartsWith("cd ", StringComparison.OrdinalIgnoreCase))
            {
                string dirCode = input.Substring(3).Trim();
                if (dirCode.StartsWith("D", StringComparison.OrdinalIgnoreCase))
                {
                    if (int.TryParse(dirCode.Substring(1), out int dirIndex))
                    {
                        try
                        {
                            string[] directories = Directory.GetDirectories(currentPath);
                            if (dirIndex > 0 && dirIndex <= directories.Length)
                            {
                                currentPath = directories[dirIndex - 1];
                            }
                            else
                            {
                                Console.WriteLine("Неверный номер папки.");
                                Console.ReadKey();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ошибка при переходе в папку: " + ex.Message);
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный формат номера папки.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Неверный формат команды.");
                    Console.ReadKey();
                }
                continue;
            }

            if (input.Equals("createfile", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Введите имя нового файла: ");
                string fileName = Console.ReadLine().Trim();
                string filePath = Path.Combine(currentPath, fileName);
                try
                {
                    if (!File.Exists(filePath))
                    {
                        File.Create(filePath).Close();
                        Console.WriteLine("Файл создан.");
                    }
                    else
                    {
                        Console.WriteLine("Файл с таким именем уже существует.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при создании файла: " + ex.Message);
                }
                Console.ReadKey();
                continue;
            }

            if (input.Equals("createdir", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Введите имя новой папки: ");
                string dirName = Console.ReadLine().Trim();
                string dirPath = Path.Combine(currentPath, dirName);
                try
                {
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                        Console.WriteLine("Папка создана.");
                    }
                    else
                    {
                        Console.WriteLine("Папка с таким именем уже существует.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при создании папки: " + ex.Message);
                }
                Console.ReadKey();
                continue;
            }

            if (input.Equals("deletefile", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Введите номер файла для удаления (например, F1): ");
                string fileCode = Console.ReadLine().Trim();
                if (fileCode.StartsWith("F", StringComparison.OrdinalIgnoreCase) &&
                    int.TryParse(fileCode.Substring(1), out int fileIndex))
                {
                    try
                    {
                        string[] files = Directory.GetFiles(currentPath);
                        if (fileIndex > 0 && fileIndex <= files.Length)
                        {
                            File.Delete(files[fileIndex - 1]);
                            Console.WriteLine("Файл удалён.");
                        }
                        else
                        {
                            Console.WriteLine("Неверный номер файла.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка при удалении файла: " + ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Неверный формат номера файла.");
                }
                Console.ReadKey();
                continue;
            }

            if (input.Equals("deletedir", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Введите номер папки для удаления (например, D1): ");
                string dirCode = Console.ReadLine().Trim();
                if (dirCode.StartsWith("D", StringComparison.OrdinalIgnoreCase) &&
                    int.TryParse(dirCode.Substring(1), out int dirIndex))
                {
                    try
                    {
                        string[] directories = Directory.GetDirectories(currentPath);
                        if (dirIndex > 0 && dirIndex <= directories.Length)
                        {
                            Directory.Delete(directories[dirIndex - 1], true);
                            Console.WriteLine("Папка удалена.");
                        }
                        else
                        {
                            Console.WriteLine("Неверный номер папки.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка при удалении папки: " + ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Неверный формат номера папки.");
                }
                Console.ReadKey();
                continue;
            }

            Console.WriteLine("Неизвестная команда. Попробуйте снова.");
            Console.ReadKey();
        }
    }

    static void ShowDriveInfo(DriveInfo drive)
    {
        Console.WriteLine($"\nИнформация о диске {drive.Name}:");
        Console.WriteLine($"Тип: {drive.DriveType}");
        Console.WriteLine($"Файловая система: {drive.DriveFormat}");
        Console.WriteLine($"Объем: {drive.TotalSize / (1024 * 1024 * 1024)} ГБ");
        Console.WriteLine($"Свободно: {drive.AvailableFreeSpace / (1024 * 1024 * 1024)} ГБ");
        Console.WriteLine($"Метка тома: {drive.VolumeLabel}");
        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }
}
