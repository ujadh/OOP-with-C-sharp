using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440



{

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SID { get; set; }
        public string Group { get; set; }

        public Student(string firstName, string lastName, string group, int runningNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            SID = GenerateSID(runningNumber);
            Group = group;
        }

        private string GenerateSID(int runningNumber)
        {
            return $"{FirstName[0]}{LastName[0]}{runningNumber:D3}";
        }
    }

    class MiniPeppi
    {
        public List<Student> studentRegister = new List<Student>();
        public int runningNumber = 1;

        public void AddTestStudents()
        {
            AddStudent(new Student("Hanna", "Husso", "TTV19S1", runningNumber++));
            AddStudent(new Student("Kirsi", "Kernell", "TTV19S2", runningNumber++));
            AddStudent(new Student("Masa", "Niemi", "TTV19S3", runningNumber++));
            AddStudent(new Student("Frank", "Tester", "TTV19SM", runningNumber++));
            AddStudent(new Student("Allan", "Aalto", "TTV19SMM", runningNumber++));
        }

        public void AddStudent(Student student)
        {
            if (IsSIDUnique(student.SID))
            {
                studentRegister.Add(student);
                Console.WriteLine("Student added successfully.");
            }
            else
            {
                Console.WriteLine("Error: SID must be unique. Student not added.");
            }
        }

        public void DeleteStudent(string sid)
        {
            Student studentToRemove = studentRegister.FirstOrDefault(student => student.SID == sid);

            if (studentToRemove != null)
            {
                studentRegister.Remove(studentToRemove);
                Console.WriteLine("Student deleted successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void SearchStudent(string searchQuery)
        {
            List<Student> searchResults = studentRegister
                .Where(student => student.FirstName.Contains(searchQuery) ||
                                  student.LastName.Contains(searchQuery) ||
                                  student.SID.Contains(searchQuery))
                .ToList();

            if (searchResults.Count > 0)
            {
                Console.WriteLine("Search Results:");
                foreach (Student student in searchResults)
                {
                    Console.WriteLine($"SID: {student.SID}, Name: {student.FirstName} {student.LastName}, Group: {student.Group}");
                }
            }
            else
            {
                Console.WriteLine("Sorry!No matching students found.");
            }
        }

        private bool IsSIDUnique(string sid)
        {
            return !studentRegister.Any(student => student.SID == sid);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MiniPeppi miniPeppi = new MiniPeppi();
            miniPeppi.AddTestStudents();

            while (true)
            {
                Console.WriteLine("Choose an option from below:");
                Console.WriteLine("1. Add Students.");
                Console.WriteLine("2. Remove Students.");
                Console.WriteLine("3. Search a Student.");
                Console.WriteLine("4. Display All Students.");
                Console.Write("Enter Your Choice: ");
                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    // Add a new student
                    Console.WriteLine("Add a New Student in system:");
                    Console.Write("Please Enter First Name: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Please Enter Last Name: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Please Enter the Group: ");
                    string group = Console.ReadLine();

                    Student newStudent = new Student(firstName, lastName, group, miniPeppi.runningNumber++);
                    miniPeppi.AddStudent(newStudent);
                }
                else if (choice == "2")
                {
                    // Delete a student
                    Console.Write("Enter SID of the student to delete: ");
                    string sidToDelete = Console.ReadLine();
                    miniPeppi.DeleteStudent(sidToDelete);

                    // Display updated list
                    Console.WriteLine("Updated Student Register:");
                    foreach (Student student in miniPeppi.studentRegister)
                    {
                        Console.WriteLine($"SID: {student.SID}, Name: {student.FirstName} {student.LastName}, Group: {student.Group}");
                    }
                }
                else if (choice == "3")
                {
                    Console.Write("Enter search query: ");
                    string searchQuery = Console.ReadLine();
                    miniPeppi.SearchStudent(searchQuery);
                }
                else if (choice == "4")
                {
                    foreach (Student student in miniPeppi.studentRegister)
                    {
                        Console.WriteLine($"SID: {student.SID}, Name: {student.FirstName} {student.LastName}, Group: {student.Group}");
                    }
                }
                else if (choice == "")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option selected!!!");
                }
            }
        }
    }
}

