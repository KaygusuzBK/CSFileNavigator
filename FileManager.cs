using System;
using System.IO;

namespace FileExplorerApp
{
    public class FileManager
    {
        private string CurrentDirectory { get; set; }

        public FileManager()
        {
            CurrentDirectory = Directory.GetCurrentDirectory();
        }

        public void ListFilesAndDirectories()
        {
            try
            {
                WriteOutput($"BURDASIN: {CurrentDirectory}", MessageType.Bilgi);

                var directories = Directory.GetDirectories(CurrentDirectory);
                var files = Directory.GetFiles(CurrentDirectory);

                WriteOutput("\nKlasörler:", MessageType.Bilgi);
                foreach (var directory in directories)
                {
                    PrintEntryInfo(directory);
                }

                WriteOutput("\nDosyalar:", MessageType.Bilgi);
                foreach (var file in files)
                {
                    PrintEntryInfo(file);
                }
            }
            catch (Exception ex)
            {
                WriteOutput($"Hata: {ex.Message}", MessageType.Hata);
            }
        }

        private void PrintEntryInfo(string path)
        {
            if (File.Exists(path))
            {
                // Dosya bilgilerini yazdırma
                FileInfo fileInfo = new FileInfo(path);
                string sizeFormatted = FormatFileSize(fileInfo.Length);
                WriteOutput($"[DOSYA] {fileInfo.Name} - {sizeFormatted}", MessageType.Bilgi);
            }
            else if (Directory.Exists(path))
            {
                // Klasör bilgilerini yazdırma
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                WriteOutput($"[KLASÖR] {directoryInfo.Name}", MessageType.Bilgi);
            }
            else
            {
                WriteOutput("Geçersiz yol veya dosya/klasör bulunamadı.", MessageType.Uyarı);
            }
        }

        private string FormatFileSize(long sizeInBytes)
        {
            double size = sizeInBytes;
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int order = 0;
            while (size >= 1024 && order < sizes.Length - 1)
            {
                order++;
                size /= 1024;
            }
            return $"{size:0.##} {sizes[order]}";
        }

        public void ChangeDirectory(string directoryName)
        {
            try
            {
                string newDirectory = Path.Combine(CurrentDirectory, directoryName);
                if (Directory.Exists(newDirectory))
                {
                    CurrentDirectory = newDirectory;
                    WriteOutput($"Yeni dizin: {CurrentDirectory}", MessageType.Bilgi);
                }
                else
                {
                    WriteOutput("Dizin bulunamadı!", MessageType.Uyarı);
                }
            }
            catch (Exception ex)
            {
                WriteOutput($"Hata: {ex.Message}", MessageType.Hata);
            }
        }

        private void WriteOutput(string message, MessageType messageType)
        {
            switch (messageType)
            {
                case MessageType.Bilgi:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{message}");
                    break;
                case MessageType.Uyarı:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"[UYARI] {message}");
                    break;
                case MessageType.Hata:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[HATA] {message}");
                    break;
            }
            Console.ResetColor();
        }

        private enum MessageType
        {
            Bilgi,
            Uyarı,
            Hata
        }
    }
}
