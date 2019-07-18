using ExtensionMethods;
using FSEDemo.Inheritance;
using FSEDemo.Threading;
using System;
using System.Collections.Generic;

namespace FSEDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintHeading("Assignment - 1");
            //FormatQuestion();
            //Console.WriteLine($"1. Write a program in C# Sharp for a 2D array of size 3x3 and print the matrix");
            //FormatSolution();
            //Matrix.DisplayMatrix();

            //FormatQuestion();
            //Console.WriteLine($"2. Write an application to implement multiple inheritance and overriding using virtual method.");
            //FormatSolution();

            //Rectangle rectangle = new Rectangle(5, 7, "Rec #1");
            //Circle circle = new Circle(5, "Circle #1");

            //// Print the area of the object.
            //Console.WriteLine($"Shape details : {rectangle}. Paint cost will be : INR {rectangle.GetCost(rectangle.Area)}.");
            //Console.WriteLine($"Shape details : {circle}.");

            //FormatQuestion();
            //Console.WriteLine($"3. Application is maintaining a collection (List) of Integers as NumList. We need to print the numbers from NumList those are divisible by 3. Implement the functionality using:{Environment.NewLine} \t A.Delegates{Environment.NewLine}\t B.Lambda Expression.");

            //FormatSolution();

            //CollectionDemo.PrintListByLambda();
            //CollectionDemo.PrintListByDelegate();

            ////Student E = new Student();
            ////E.GetInfo();
            ////Stud Stud = new Stud();
            ////Stud.GetInfo();

            //Console.WriteLine($"4.Extend the functionality of the System.String class with function IsEmail() that will check the user input.");
            //FormatSolution();
            //Console.WriteLine(" Is Input string [Usre@MyApp.com] is an Email? {0}", "Usre@MyApp.com".IsEmail());

            //PrintHeading("Assignment - 2");
            //ShowPersonDetails();


            AccountOperations.PerformOperation();
            Console.ReadKey();
        }


        private static void FormatSolution()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Solution :");
            Console.ResetColor();
        }

        private static void FormatQuestion()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
        }

        private static void PrintHeading(string assignmentHeading)
        {
            Console.WriteLine($"================================================================================ {Environment.NewLine} \t\t\t\t{assignmentHeading} {Environment.NewLine}================================================================================");
        }

        private static void ShowPersonDetails()
        {
            List<Person> persons = new List<Person>
            {
                new Student("Kumar", 87),
                new Student("Arvind", 95),
                new Student("Pratik", 83),
                new Professor("Rai", 5),
                new Professor("Raman", 3),
            };

            foreach (var item in persons)
            {
                if (item.IsOutstanding())
                    Console.WriteLine($"My Name is : {item.Name} and I am Outstanding).");
            }

            foreach (var item in persons)
            {
                if (item is Student)
                    ((Student)item).Display();
                else
                    ((Professor)item).Print();
            }
        }
    }
}
