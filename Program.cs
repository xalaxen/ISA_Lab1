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
        static void Main(string[] args)
        {
            string path = "students.csv";
            Functions fn = new Functions();
            List<Student> students = fn.ReadAllDate(path);
            while (true)
            {
                Console.WriteLine("Что хотите сделать?:\n" +
                    "1. Вывод всех записей на экран.\n" +
                    "2. Вывод записи по номеру.\n" +
                    "3. Запись данных в файл.\n" +
                    "4. Удаление записи из файла.\n" +
                    "5. Добавление записи в файл.\n" +
                    "Выход из приложения - ESC.\n");
                ConsoleKey ans = Console.ReadKey().Key;
                Console.WriteLine();

                switch (ans)
                {
                    case ConsoleKey.D1:
                        fn.PrintAllNotes(students);
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Введите номер записи для вывода: ");
                        int note_number = Convert.ToInt32(Console.ReadLine());
                        fn.PrintNotesByNumber(note_number, ref students);
                        break;
                    case ConsoleKey.D3:
                        fn.WriteNotesToFile(ref students, path);
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine("Введите номер записи для удаления: ");
                        int note_delete = Int32.Parse(Console.ReadLine()) - 1;
                        fn.RemoveNotesFromFile(note_delete, ref students);
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
                        try
                        {
                            int age = Int32.Parse(Console.ReadLine());
                            fn.AddNoteToFile(surname, name, patronomyc, sex, age, ref students);
                        }
                        catch (Exception ex) { Console.WriteLine("Форма заполнена не верно!\n"); }
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
