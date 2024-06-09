using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440


{
    public class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }
    }

    public class Employee : Person
    {
        public string Profession { get; set; }
        public double Salary { get; set; }

        public Employee(string name, string profession, double salary)
            : base(name)
        {
            Profession = profession;
            Salary = salary;
        }
    }

    public class Boss : Employee
    {
        public string Car { get; set; }
        public double Bonus { get; set; }

        public Boss(string name, string profession, double salary, string car, double bonus)
            : base(name, profession, salary)
        {
            Car = car;
            Bonus = bonus;
        }
    }

    class Program
    {
        static void Main()
        {
            // Create objects with the provided information
            Employee aaratiBista = new Employee("Aarati Bista", "Teacher", 1200);
            Boss ujjwalAdhikari = new Boss("Ujjwal Adhikari", "Head of Institute", 9000, "Audi", 5000);
            Employee principalTeacher = new Employee("Aarati Bista", "Principal Teacher", 2200);

            // Print the information of the objects
            Console.WriteLine("Employee:");
            Console.WriteLine($"- Name: {aaratiBista.Name} Profession: {aaratiBista.Profession} Salary: {aaratiBista.Salary}");

            Console.WriteLine("Boss:");
            Console.WriteLine($"- Name: {ujjwalAdhikari.Name} Profession: {ujjwalAdhikari.Profession} Salary: {ujjwalAdhikari.Salary} Car: {ujjwalAdhikari.Car} Bonus: {ujjwalAdhikari.Bonus}");

            Console.WriteLine("Employee:");
            Console.WriteLine($"- Name: {principalTeacher.Name} Profession: {principalTeacher.Profession} Salary: {principalTeacher.Salary}");
        }
    }
}