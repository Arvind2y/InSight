using ExtensionMethods;
using FSEDemo.Inheritance;
using FSEDemo.LINQ;
using System;
using System.Collections.Generic;

namespace FSEDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // CSharpAssignment();

            // LINQ assignments
            LINQAssignments();

            Console.ReadKey();
        }

        private static void LINQAssignments()
        {
            PrintHeading("LINQ Assignment - 1");
            FormatQuestion();
            Console.WriteLine($"1.Given an array of numbers. Find the cube of the numbers that are greater than 100 but less than 1000 using LINQ.");
            FormatSolution();
            LinqExercise.GetNumberCube();

            FormatQuestion();
            Console.WriteLine($"3.Create an Order class that has order id, item name, order date and quantity. Create a collection of Order objects. Display the data day wise from most recently ordered to least recently ordered and by quantity from highest to lowest.");
            FormatSolution();
            LinqExercise.ShowLatestOrders();

            LinqExercise.ShowOrdersByQuantity();

            FormatQuestion();
            Console.WriteLine($"4.For the previous exercise, write a LINQ query that displays the details grouped by the month in the descending order of the order date.");
            FormatSolution();
            LinqExercise.GroupOrdersbyMonth();

            FormatQuestion();
            Console.WriteLine($"5, You have created Order class in the previous exercise and that has order id, item name, order date and quantity.Create another class called Item that has item name and price.Write a LINQ query such that it returns order id, item name, order date and the total price(price* quantity) grouped by the month in the descending order of the order date. \n 6. Do the previous exercise using anonymous types. ");
            FormatSolution();
            LinqExercise.GetOrderIterDetails();

            FormatQuestion();
            Console.WriteLine($"7. Check if all the quantities in the Order collection is > 0. Get the name of the item that was ordered in largest quantity in a single order. (Hint: use LINQ methods to sort) Find if there are any orders placed before Jan of this year.");
            FormatSolution();
            LinqExercise.GetHighestQuantityItem();
            

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

        private static void CSharpAssignment()
        {
            PrintHeading("Assignment - 1");
            FormatQuestion();
            Console.WriteLine($"1. Write a program in C# Sharp for a 2D array of size 3x3 and print the matrix");
            FormatSolution();
            Matrix.DisplayMatrix();

            FormatQuestion();
            Console.WriteLine($"2. Write an application to implement multiple inheritance and overriding using virtual method.");
            FormatSolution();

            Rectangle rectangle = new Rectangle(5, 7, "Rec #1");
            Circle circle = new Circle(5, "Circle #1");

            // Print the area of the object.
            Console.WriteLine($"Shape details : {rectangle}. Paint cost will be : INR {rectangle.GetCost(rectangle.Area)}.");
            Console.WriteLine($"Shape details : {circle}.");

            FormatQuestion();
            Console.WriteLine($"3. Application is maintaining a collection (List) of Integers as NumList. We need to print the numbers from NumList those are divisible by 3. Implement the functionality using:{Environment.NewLine} \t A.Delegates{Environment.NewLine}\t B.Lambda Expression.");

            FormatSolution();

            CollectionDemo.PrintListByLambda();
            CollectionDemo.PrintListByDelegate();

            //Student E = new Student();
            //E.GetInfo();
            //Stud Stud = new Stud();
            //Stud.GetInfo();

            Console.WriteLine($"4.Extend the functionality of the System.String class with function IsEmail() that will check the user input.");
            FormatSolution();
            Console.WriteLine(" Is Input string [Usre@MyApp.com] is an Email? {0}", "Usre@MyApp.com".IsEmail());

            PrintHeading("Assignment - 2");
            ShowPersonDetails();
        }
    }
}
