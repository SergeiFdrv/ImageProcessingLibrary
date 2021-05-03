using System;

namespace ImageToText.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string path;
            ImageToTextLibrary.Converter converter = new();
            Func<string> func = null;
            do
            {
                Console.WriteLine("Введите путь к файлу:");
                path = Console.ReadLine();
                Console.WriteLine("T - найти текст, F - найти лицо");
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.T:
                        func = () => converter.DetectText(path); break;
                    case ConsoleKey.F:
                        func = () => converter.DetectFace(path).ToString(); break;
                }
                Console.WriteLine();
                if (System.IO.File.Exists(path))
                {
                    Console.WriteLine(
                        "--- Результат: ---\n" +
                        func?.Invoke() +
                        "\n------------------");
                }
                else
                {
                    Console.WriteLine("Файл не найден");
                }
                Console.WriteLine("Нажмите любую клавишу. Выйти - Escape");
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
