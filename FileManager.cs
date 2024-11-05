using System;
using System.IO;

namespace FileExplorerApp
{
    public class FileManager
    {
        public string CurrentDirectory { get; private set; }

        public FileManager()
        {
            // Geçerli dizini al
            CurrentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine($"Şuan burdayım: {CurrentDirectory}");  
        }

        public void ListFilesAndDirectories()
        {
            try
            {
                Console.WriteLine($"BURDASIN: {CurrentDirectory}");



                var directories = Directory.GetDirectories(CurrentDirectory);
                Console.WriteLine("\nKlasörler:");
                foreach (var dir in directories)
                {
                    Console.WriteLine($"[D] {Path.GetFileName(dir)}");
                }

                // Dosyaları listele
                var files = Directory.GetFiles(CurrentDirectory);
                Console.WriteLine("\nDosyalar:");
                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    Console.WriteLine($"[F] {fileInfo.Name} - {fileInfo.Length / 1024} KB");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }
        }
    }
}
