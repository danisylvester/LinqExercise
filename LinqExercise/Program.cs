using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            //Print the Sum and Average of numbers
            var avg = numbers.Average();
            Console.WriteLine($"Average of numbers: {avg}");
            var sum = numbers.Sum();
            Console.WriteLine($"Sum of numbers: {sum}");
            Console.WriteLine();
            Console.WriteLine("...................................");
            //Order numbers in ascending order and decsending order. Print each to console.
            Console.WriteLine("Ascending Order:");
            var ascendNum = numbers.OrderBy(n => n);
            foreach(int num in ascendNum)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();
            Console.WriteLine("...................................");
            Console.WriteLine("Descending Order:");
            var descendNum = numbers.OrderByDescending(n => n);
            foreach(int n in descendNum)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine();
            Console.WriteLine("...................................");

            //Print to the console only the numbers greater than 6
            Console.WriteLine("Greater than 6:");
            var numGreater = numbers.Where(n => n < 6);
            foreach(int n in numGreater)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine();
            Console.WriteLine("...................................");
            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Order then print 4:");
            foreach(int num in ascendNum.Take(4))
            {
                Console.WriteLine(num);
            }
            Console.WriteLine();
            Console.WriteLine("...................................");
            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("Change index 4 to your age & print in descending order:");
            numbers[4] = 26;
            foreach(int n in numbers.OrderByDescending(n => n))
            {
                Console.WriteLine(n);
            }
            Console.WriteLine();
            Console.WriteLine("...................................");
            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            var nameContainsCS = employees.Where(e => e.FirstName.StartsWith('C') || e.FirstName.StartsWith('S')).OrderBy(e => e.FirstName);
            foreach(Employee person in nameContainsCS)
            {
                Console.WriteLine(person.FullName);
            }
            Console.WriteLine();
            Console.WriteLine("...................................");
            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var overTwentySix = employees.Where(e => e.Age > 26).OrderBy(a => a.Age).ThenBy(n => n.FirstName);
            foreach(Employee person in overTwentySix)
            {
                Console.WriteLine($"Name: {person.FullName} age: {person.Age}");
            }
            Console.WriteLine();
            Console.WriteLine("...................................");
            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var yearsOE = employees.Where(y => y.YearsOfExperience <= 10 && y.Age > 35);
            var average = yearsOE.Average(e => e.YearsOfExperience);
            var sumOf = yearsOE.Sum(e => e.YearsOfExperience);

            Console.WriteLine($"Average YOE of employees over 35 with less than 11 YOE: {average}");
            Console.WriteLine($"Sum YOE of employees over 35 with less than 11 YOE: {sumOf}");

            Console.WriteLine();
            Console.WriteLine("...................................");
            //Add an employee to the end of the list without using employees.Add()

            employees = employees.Append(new Employee("Dani", "Sylvester", 26, 0)).ToList();
            foreach(var person in employees)
            {
                Console.WriteLine(person.FullName);
            }
            
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
