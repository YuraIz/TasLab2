using System;

namespace Lab_2
{
    internal class
        Task1 //Calculate the maximum degree of two that divides the product of consecutive numbers from a to b
    {
        public uint ReturnDeg(uint first, uint last)
        {
            if (first > last) return 0;
            first += first & 1;
            last -= last & 1;
            uint i = 0;
            ulong productOfNumbers = first;
            for (; (productOfNumbers & 1) == 0; i++) productOfNumbers = productOfNumbers >> 1;

            while (first < last)
            {
                for (productOfNumbers *= first += 2; (productOfNumbers & 1) == 0; i++)
                {
                    productOfNumbers = productOfNumbers >> 1;
                }
            }

            return i;
        }
    }

    internal class Task2
    {
        private int Pow(int x, int a)
        {
            for (int x0 = x; a > 0; a--)
            {
                x *= x0;
            }

            return x;
        }
        
        public float StrToFloat(string @string)
        {
            float number = 0;
            short point = 0;
            for (int i = 0; i < @string.Length; i++, number *= 10)
            {
                if (Convert.ToBoolean(point))
                {
                    point++;
                }
                else if (@string[i] == 46)
                {
                    i++;
                    point++;
                }
                number += @string[i] - 48;
                
            }

            number /= Pow(10, point);
            
            return number;
        }
        public double StrToDouble(string @string)
        {
            double number = 0;
            short point = 0;
            for (int i = 0; i < @string.Length; i++, number *= 10)
            {
                if (Convert.ToBoolean(point))
                {
                    point++;
                }
                else if (@string[i] == 46)
                {
                    i++;
                    point++;
                }
                number += @string[i] - 48;
                
            }

            number /= Pow(10, point);
            
            return number;
        }
    }

    internal class Task3
    {
        private int Pow(int x, int a)
        {
            if (a < 1) return 1;
            for (int x0 = x; a > 1; a--)
            {
                x *= x0;
            }
            
            return x;
        }
        
        private string IntToHex(int number)
        {
            byte[] arr = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                arr[i] = Convert.ToByte((number/Pow(16, 3 - i))%16);
            }

            char[] charArr = new char[4];
            
            for (int i = 0; i < 4; i++)
            {
                charArr[i] = (arr[i] < 9) ? Convert.ToChar(48 + arr[i]) : Convert.ToChar(65 + arr[i] % 10);
            }
            
            string hex = new string(charArr);
            return hex;
        }

        public void WriteNumbers(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(IntToHex(Convert.ToInt32(text[i])) + " ");
            }
        }

    }

    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine("Please, select between 1, 2 and 3");
            switch (Convert.ToChar(Console.Read()))
            {
                case '1':
                {
                    Console.ReadLine();
                    Console.WriteLine("Selected Task 1");
                    Console.WriteLine("Calculate the maximum degree of two that divides the product of consecutive numbers from a to b");
                    Task1 task1 = new Task1();
                    Console.Write("a=");
                    uint a = Convert.ToUInt32(Console.ReadLine());
                    Console.Write("b=");
                    uint b = Convert.ToUInt32(Console.ReadLine());
                    Console.WriteLine("Answer is " + task1.ReturnDeg(a, b));
                    break;
                }
                case '2':
                {
                    Console.ReadLine();
                    Console.WriteLine("Selected Task 2");
                    Console.WriteLine("Convert string to a double");
                    Task2 task2 = new Task2();
                    Console.WriteLine(task2.StrToDouble(Console.ReadLine()));
                    break;
                }
                case '3':
                {
                    Console.ReadLine();
                    Console.WriteLine("Selected Task 3");
                    Console.WriteLine("Write character numbers as hexadecimal numbers");
                    Task3 task3 = new Task3();
                    task3.WriteNumbers(Console.ReadLine());
                    break;
                }
                default:
                {
                    Console.WriteLine("Selected nothing");
                    break;
                }
            }
        }
    }
}