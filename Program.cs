using System;

namespace FileExplorerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileManager = new FileManager();
            Run(fileManager); // İlk çalıştırma
        }

        static void Run(FileManager fileManager)
        {
            fileManager.ListFilesAndDirectories();
            var input = GetUserCommand();

            if (!ProcessCommand(input, fileManager))
            {
                Run(fileManager);
            }
        }

        static string[] GetUserCommand()
        {
            Console.WriteLine("\nKomut girin (cd <dizin_adi> veya .. geri gitmek, exit)");
            string input = Console.ReadLine();
            return input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }

        static bool ProcessCommand(string[] commands, FileManager fileManager)
        {
            if (commands.Length == 0)
            {
                Console.WriteLine("Geçerli bir komut girin.");
                return false;
            }

            string command = commands[0].ToLower();

            switch (command)
            {
                case "cd":
                    if (commands.Length > 1)
                    {
                        ChangeDirectory(commands[1], fileManager);
                    }
                    else
                    {
                        Console.WriteLine("Dizin adı belirtilmedi.");
                    }
                    return false;

                case "..":
                    ChangeDirectory("..", fileManager);
                    return false;

                case "exit":
                    Console.WriteLine("Programdan çıkılıyor...");
                    return true;

                default:
                    Console.WriteLine("Hatalı komut.");
                    return false;
            }
        }

        static void ChangeDirectory(string directory, FileManager fileManager)
        {
            fileManager.ChangeDirectory(directory);
        }
    }
}
