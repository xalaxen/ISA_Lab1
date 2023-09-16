using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab1
{
    class Program
    {
        static string path = "students.csv";
        static void Main(string[] args)
        {
            ObservableCollection<Student> students = Functions.ReadAllDate(path);
            while (true)
            {
                ConsoleKey ans;
                int note_number;
                Console.WriteLine("Что хотите сделать?:\n" +
                    "1. Вывод всех записей на экран.\n" +
                    "2. Вывод записи по номеру.\n" +
                    "3. Запись данных в файл.\n" +
                    "4. Удаление записи из файла.\n" +
                    "5. Добавление записи в файл.\n" +
                    "Выход из приложения - ESC.\n");
                ans = Console.ReadKey().Key;
                Console.WriteLine();

                switch (ans)
                {
                    case ConsoleKey.D1:
                        Functions.PrintAllNotes(students);
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Введите номер записи для вывода: ");
                        note_number = Convert.ToInt32(Console.ReadLine());
                        Functions.PrintNotesByNumber(note_number, ref students);
                        break;
                    case ConsoleKey.D3:
                        Functions.WriteNotesToFile(ref students, path);
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("Введите номер записи для удаления: ");
                        int note_delete = Int32.Parse(Console.ReadLine()) - 1;
                        Functions.RemoveNotesFromFile(note_delete, ref students);
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine("Введите фамилию: ");
                        string surname = Console.ReadLine().ToString();
                        Console.WriteLine("Введите имя: ");
                        string name = Console.ReadLine().ToString();
                        Console.WriteLine("Введите отчество: ");
                        string patronomyc = Console.ReadLine().ToString();
                        Console.WriteLine("Введите пол (м/ж): ");
                        string sex = Console.ReadLine();
                        Console.WriteLine("Введите возраст: ");
                        int age = Int32.Parse(Console.ReadLine());
                        Functions.AddNoteToFile(surname, name, patronomyc, sex, age, ref students);
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        Console.WriteLine("Такого пункта меню нет!\n");
                        break;
                }
            }
        }
    }
}
