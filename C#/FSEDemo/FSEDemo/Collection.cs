using System;
using System.Collections.Generic;

namespace FSEDemo
{
    public class CollectionDemo
    {
        public delegate List<int> DivisibleBy3(List<int> list);
        static List<int> numList = new List<int>() { 10, 13, 4, 8, 9, 15, 16, 18 };

        /// <summary>
        /// Print the list of integer using lambda expression
        /// </summary>
        public static void PrintListByLambda()
        {
            Console.WriteLine($"Solution {Environment.NewLine}List of numbers which are divisible by 3 using lambda expression!");
            var divisibleBy3 = numList.FindAll(x => x % 3 == 0);
            DisplayList(divisibleBy3);
        }

        /// <summary>
        /// Print the list using the delegate
        /// </summary>
        public static void PrintListByDelegate()
        {
            Console.WriteLine("List of numbers divisible by 3 using delegate!");

            //Creating and assigning anonymous function to delegate
            DivisibleBy3 divisibleBy3 = delegate (List<int> list)
            {
                List<int> result = new List<int>();
                foreach (var item in list)
                {
                    if (item % 3 == 0)
                        result.Add(item);
                }
                return result;
            };

            // Calling delegate
            DisplayList(divisibleBy3(numList));
        }

        /// <summary>
        /// Print list of of items from input parameters
        /// </summary>
        /// <param name="list"></param>
        private static void DisplayList(List<int> list)
        {
            Console.Write($"{'\u007b'}");
            foreach (var item in list)
            {
                Console.Write($"{item}\t");
            }
            Console.Write($"\b\b\b\b\b\b{'\u007d'}{Environment.NewLine}");
        }
    }
}
