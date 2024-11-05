using System;

namespace FileExplorerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FileManager fileManager = new FileManager();

            while (true)
            {
                fileManager.ListFilesAndDirectories();

                Console.WriteLine("\nKomut girin (cd <dizin_adi> ve ya  .. geri gitmek, exit)");
                string input = Console.ReadLine();
                string[] commands = input.Split(' '); 

                if (commands[0] == "cd" && commands.Length > 1)
                {
                    fileManager.ChangeDirectory(commands[1]);
                }
                else if (commands[0] == "..")
                {
                    fileManager.ChangeDirectory("..");
                }
                else if (commands[0] == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı");
                }
            }
        }
    }
}
