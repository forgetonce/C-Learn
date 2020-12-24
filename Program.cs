using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace DotNetDebugging
{
    public delegate void Study(string content);
    class Person
    {
        private string name;
        private string sex;
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Sex
        {
            get => sex;
            set => sex = value;
        }
        public Person(string name, string sex)
        {
            Name = name;
            Sex = sex;
        }
    }

    class Program
    {
        static void StudyChinese(string content)
        {
            Console.WriteLine($"I have learnt {content}");
        }
        static void DeleteFile(string filePath)
        {
            Directory.Delete(filePath, true);
        }
        static void Main(string[] args)
        {
            /*
            int result = Fibonacci (5);
            Console.WriteLine (result);
            */
            /*
            string filePath = @"F:\MyCode\C#\HelloWorld";
            DeleteFile(filePath);
            */
            string baidu = "www.baidu.com";
            string url = "<a href ='" + baidu + "'></a>";
            Person person = new Person("Bruce", "male");
            
            Func<int,int,int> func = new Func<int,int,int> ((a,b)=>{return a+b;});
            int result = func(100,200);
            Console.WriteLine(result);
        }
        static int Fibonacci(int n)
        {
            Debug.WriteLine($"Entering {nameof(Fibonacci)} method");
            Debug.WriteLine($"We are looking for the {n}th number");
            int n1 = 0;
            int n2 = 1;
            int sum = 0;

            for (int i = 2; i < n; i++)
            {
                sum = n1 + n2;
                n1 = n2;
                n2 = sum;
            }
            return n == 0 ? n1 : n2;
        }
    }
}