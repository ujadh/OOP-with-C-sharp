using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440
{
    public class Student
    {
        // This is the properties of input
        public string Name { get; set; }
        public int Age { get; set; }
        public string Subject { get; set; }

        // Using Constructor
        public Student(string name, int age, string major)
        {
            Name = name;
            Age = age;
            Subject = major;
        }

        // This is the method to display student information
        public string GetStudentInfo()
        {
            return $"Name: {Name}, Age: {Age}, Subject: {Subject}";
        }
    }

    class Program
    {
        static void Main()
        {
            // Here i am creating a list to store student objects
            List<Student> students = new List<Student>();

            // Here i am creating and adding five students objects randomly to the list
            students.Add(new Student("Dorje", 27, "CSC"));
            students.Add(new Student("Hari", 52, "PHD"));
            students.Add(new Student("Ummar", 41, "BUSINESS"));
            students.Add(new Student("Kale", 39, "MATHS"));
            students.Add(new Student("Mote", 33, "LITERATURE"));

            // Print student data using a loop
            Console.WriteLine("Student Information are given below:");
            foreach (Student student in students)
            {
                Console.WriteLine(student.GetStudentInfo());
            }
        }
    }
}