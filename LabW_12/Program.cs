using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {        
        string filePath = "test.txt"; // Робимо файл test.txt директорії
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
            Console.WriteLine("Файл test.txt створено.");
        }
        else
        {
            Console.WriteLine("Файл test.txt вже iснує.");
        }
               
        Console.WriteLine("\nЗавдання 1: Перегляд вмiсту файлу");
        ViewFileContent(filePath);

        Console.WriteLine("\nЗавдання 2: Збереження масиву у файл");
        SaveArrayToFile();

        Console.WriteLine("\nЗавдання 3: Завантаження масиву з файлу");
        LoadArrayFromFile();

        Console.WriteLine("\nЗавдання 4: Генерацiя та вiдображення 20 випадкових чисел");
        GenerateNumbers();
    }

    static void ViewFileContent(string filePath)
    {
        if (File.Exists(filePath))
        {
            StreamReader reader = new StreamReader(filePath);
            string content = reader.ReadToEnd();
            reader.Close();
            Console.WriteLine(content);
        }
        else
        {
            Console.WriteLine("Файл не iснує.");
        }
    }

    static void SaveArrayToFile()
    {
        Console.WriteLine("Введiть елементи масиву через пробiл:");
        string[] input = Console.ReadLine().Split(' ');
        int[] array = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            array[i] = int.Parse(input[i]);
        }

        Console.WriteLine("Введiть шлях до файлу для збереження:");
        string filePath = Console.ReadLine();

        StreamWriter writer = new StreamWriter(filePath);
        foreach (int num in array)
        {
            writer.Write(num + " ");
        }
        writer.Close();
        Console.WriteLine("Масив збережено у файл.");
    }

    static void LoadArrayFromFile()
    {
        Console.WriteLine("Введiть абсолютний шлях до файлу для завантаження масиву:");
        string filePath = Console.ReadLine();

        if (File.Exists(filePath))
        {
            StreamReader reader = new StreamReader(filePath);
            string content = reader.ReadToEnd();
            reader.Close();

            string[] numbers = content.Split(' ');
            int[] array = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                array[i] = int.Parse(numbers[i]);
            }

            Console.WriteLine("Масив завантажено з файлу: " + string.Join(", ", array));
        }
        else
        {
            Console.WriteLine("Файл не iснує.");
        }
    }

    static void GenerateNumbers()
    {
        Random random = new Random();
        int[] numbers = new int[20];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(1, 101); // Генеруємо випадкове число від 1 до 100
        }

        Console.WriteLine("Згенерованi числа: " + string.Join(", ", numbers));
    }
}
