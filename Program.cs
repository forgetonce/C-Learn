using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace DotNetDebugging
{
    delegate int[] Sort(int[] targetArray,int leftOffset,int rightOffset);
    class Person
    {
        private string _name;
        private string _sex;
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string Sex
        {
            get => _sex;
            set => _sex = value;
        }
        public Person(string name, string sex)
        {
            Name = name;
            Sex = sex;
        }
    }

    class Program
    {
        static void QuickSortAsc(int[] targetArray,int leftOffset,int rightOffset)
        {
            int swapLocation = 0;
            int i = leftOffset;
            int j = rightOffset;
            if(leftOffset>rightOffset)
                return;
            else
            {
                int tempBase = targetArray[leftOffset];//临时基准值
                while(i!=j)
                {
                    while(targetArray[j]>=tempBase&&j>i)
                    {
                        j--;
                    }
                    while(targetArray[i]<=tempBase&&i<j)
                    {
                        i++;
                    }
                    
                    if(i<j)
                    {
                        swapLocation = targetArray[i];
                        targetArray[i] = targetArray[j];
                        targetArray[j] = swapLocation;
                    }
                }
                targetArray[leftOffset]=targetArray[i];
                targetArray[i] = tempBase;

                QuickSortAsc(targetArray,leftOffset,i-1);
                QuickSortAsc(targetArray,i+1,rightOffset);
            }
        }
        static void Main(string[] args)
        {
            int[] targetArray = new int[]{6,1,2,7,9,3,4,5,10,8};
            
            QuickSortAsc(targetArray,0,targetArray.Length-1);
            Console.WriteLine();
            foreach (int item in targetArray) Console.Write(item.ToString());
            /*
            int result = Fibonacci (5);
            Console.WriteLine (result);
            */
            /*
            string filePath = @"F:\MyCode\C#\HelloWorld";
            DeleteFile(filePath);
            */
        }
        /*
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
        */
    }
}