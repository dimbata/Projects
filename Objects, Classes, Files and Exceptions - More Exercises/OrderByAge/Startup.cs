using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderByAge
{
    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<Student> students = new List<Student>();
            while (input != "End")
            {
                List<string> commands = input.Split(' ').ToList();
                students.Add(new Student(commands[0], commands[1], commands[2]));
                input = Console.ReadLine();
            }

            var orderedStudents = students.OrderBy(x => x.age);
            foreach (var student in orderedStudents)
            {
                student.Informator();
            }

        }
    }

    public class Student
    {
        public string name;
        public string ID;
        public int age;

        public Student(string name, string ID, string age)
        {
            this.name = name;
            this.ID = ID;
            this.age = int.Parse(age);
        }

        public void Informator()
        {
            Console.WriteLine($"{name} with ID: {ID} is {age} years old.");
        }
    }
}
