using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp_Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             
            Few key facts about the password:

                - It is a six-digit number.
                - The value is within the range given in your puzzle input.
                - Two adjacent digits are the same (like 22 in 122345).
                - Going from left to right, the digits never decrease; they only ever increase or stay the same (like 111123 or 135679). 

             */

            var min = 307237;
            var max = 769058;

            //Task1

            var numberOfPossiblePasswords1 = 0;

            for (int i = min; i <= max; i++)
            {
                if (IsPossiblePassword(GetDigits(i)))
                {
                    numberOfPossiblePasswords1++;
                }
            }

            Console.WriteLine("Task 1: " + numberOfPossiblePasswords1); //output: 889

            //Task2

            var numberOfPossiblePasswords2 = 0;

            for (int i = min; i <= max; i++)
            {
                var digits = GetDigits(i);
                if (IsPossiblePassword(digits) && AnyStrictDoubles(digits))
                {
                    numberOfPossiblePasswords2++;
                }
            }

            Console.WriteLine("Task 2: " + numberOfPossiblePasswords2); //output: 589

            Console.ReadKey();
        }

        private static int[] GetDigits(int i)
        {
            return i.ToString().ToCharArray().Select(_ => int.Parse(_.ToString())).ToArray();
        }

        private static bool IsPossiblePassword(int[] digits)
        {
            var anyDoubles = false;
            for (int i = 1; i < digits.Length; i++)
            {
                if (digits[i - 1] > digits[i])
                {
                    return false;
                }

                if (digits[i - 1] == digits[i])
                {
                    anyDoubles = true;
                }
            }
            return anyDoubles;
        }

        private static bool AnyStrictDoubles(int[] digits)
        {
            var result = new Dictionary<int, int>();
            for (int i = 1; i < digits.Length; i++)
            {
                var d = digits[i];
                if (digits[i - 1] == d)
                {
                    if (result.ContainsKey(d))
                    {
                        result[d]++;
                    }
                    else
                    {
                        result.Add(d, 2);
                    }
                }
            }
            return result.Values.Any(_ => _ == 2);
        }
    }
}
