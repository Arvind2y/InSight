using System;

namespace FSEDemo.Inheritance
{
    public abstract class Person
    {
        public string Name = string.Empty;

        public Person() { }

        public Person(string name)
        {
            this.Name = name;
        }

        public string GetName()
        {
            return this.Name;
        }

        public void SetName(string name)
        {
            this.Name = name;
        }

        public abstract bool IsOutstanding();
    }

    public class Professor : Person
    {
        public int BookPublished { get; set; }

        public Professor() { }

        public Professor(string name, int bookPublished) : base(name)
        {
            this.BookPublished = bookPublished;
        }

        public void Print()
        {
            Console.WriteLine($"I am a Professor. My Name is : {this.Name} and published : {this.BookPublished} books!");
        }

        public override bool IsOutstanding()
        {
            return this.BookPublished > 4 ? true : false;
        }
    }

    public class Student : Person
    {
        public double Percentage { get; set; }

        public Student() { }

        public Student(string name, double percentage) : base(name)
        {
            this.Percentage = percentage;
        }

        public void Display()
        {
            Console.WriteLine($"I am a Student. My Name is \"{this.Name} \" and acquired {this.Percentage} Percentage!");
        }

        public override bool IsOutstanding()
        {
            return this.Percentage > 85 ? true : false;
        }
    }
}
