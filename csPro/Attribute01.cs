using System;
namespace Demo.cs
{
    class Program
    {
        public abstract class Person
        {
            public abstract string Name { get; set; }
            public abstract int Age { get; set; }
        }
        public class Student : Person
        {
            public string Code { get; set; } = "N.A";
            public override string Name { get; set; } = "N.A";
            public override int Age { get; set; } = 0;
            public override string ToString()
            {
                return $"Code:{Code},Name:{Name},Age:{Age}";
            }
        }

        static void Main(string[] args)
        {
            var s = new Student()    // simple 
            {
                Code = "001",
                Name = "Zara",
                Age = 10
            };
            System.Console.WriteLine($"Student Info:={s}");

            s.Age++;
            System.Console.WriteLine($"Student Info:={s}");

            Console.ReadLine();
        }
    }
}
