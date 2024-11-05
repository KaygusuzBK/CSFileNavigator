using System;

namespace FileExplorerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FileManager fileManager = new FileManager();

            fileManager.ListFilesAndDirectories();

            Console.WriteLine("\nÇıkış");
            Console.ReadKey();
        }
    }
}
