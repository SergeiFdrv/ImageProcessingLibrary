using System;

namespace ImageToText.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string path;
            ImageToTextLibrary.Converter converter = new ImageToTextLibrary.Converter();
            do
            {
                Console.WriteLine("Введите путь к файлу:");
                path = Console.ReadLine();
                if (System.IO.File.Exists(path))
                {
                    Console.WriteLine(
                        "--- Результат: ---\n" +
                        converter.DetectText(path) +
                        "\n------------------");
                }
                else
                {
                    Console.WriteLine("Файл не найден");
                }
                Console.WriteLine("Нажмите Escape, чтобы выйти");
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
