using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;

namespace Lab1
{
    public class Functions
    {
        public List<Student> ReadAllDate(string path)
        {
            List<Student> students = new List<Student>();
            using (StreamReader sr = new StreamReader(path))
            {
                string tempNotes;
                while ((tempNotes = sr.ReadLine()) != null)
                {
                    try
                    {
                        students.Add(new Student(tempNotes.Split(',')[0],
                                                tempNotes.Split(',')[1],
                                                tempNotes.Split(',')[2],
                                                Convert.ToBoolean(tempNotes.Split(',')[3]),
                                                Convert.ToInt32(tempNotes.Split(',')[4])));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

            return students;
        }

        public void PrintAllNotes(List<Student> students)
        {
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine((i + 1) + ": " + 
                    "ФИО: " + students[i].Surname + " " + students[i].Name + " " + students[i].Patronymic +
                    " | Пол: " + ConvertSex(students[i].Sex) + 
                    " | Возраст: " + students[i].Age);
            }
            Console.WriteLine("\n");
        }

        public string ConvertSex(bool s)
        {
            if (s == true) { return "М"; }
            else { return "Ж"; }
        }

        public void PrintNotesByNumber(int note_number, ref List<Student> students)
        {
            try
            {
                Student nstudent = students[note_number - 1];
                Console.WriteLine("ФИО: " + nstudent.Surname + " "
                                + nstudent.Name + " "
                                + nstudent.Patronymic + " | "
                                + "Пол: " + ConvertSex(nstudent.Sex) + " | "
                                + "Возраст: " + nstudent.Age + "\n");
            }
            catch (Exception e) { Console.WriteLine("Такой записи нет!\n"); }

        }

        public void WriteNotesToFile(ref List<Student> students, string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                for (int i = 0; i < students.Count; i++)
                {
                    string student_line = students[i].Surname + "," + students[i].Name + "," +
                        students[i].Patronymic + "," + students[i].Sex + "," + students[i].Age;
                    sw.WriteLine(student_line);
                }
            }
            Console.WriteLine("Даныне записаны в файл!\n");
        }

        public void RemoveNotesFromFile(int note_number, ref List<Student> students)
        {
            try { students.RemoveAt(note_number); }
            catch (Exception e) { Console.WriteLine("Записи с таким номром не существует!\n"); }
        }

        public void AddNoteToFile(string surname, string name, string patronymic, string sex, int age, ref List<Student> students)
        {
            bool tsex = true;
            if (sex == "М" || sex == "м") { tsex = true; }
            if (sex == "Ж" || sex == "ж") { tsex = false; } else { Console.WriteLine("Форма заполнена не верно!\n"); }
            try
            {
                students.Add(new Student(surname, name, patronymic, tsex, age));
            }
            catch(Exception e) { Console.WriteLine("Форма заполнена не верно!\n"); }
        }
    }
}
