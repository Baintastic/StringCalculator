using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            int sum = 0;
            if (string.IsNullOrEmpty(numbers))
            {
                return sum;
            }
            if (numbers.Contains("-")) {
                throw new Exception("negatives not allowed");
            }
            string[] numbersToAdd = Get(numbers);

            for (int i = 0; i < numbersToAdd.Length; i++)
            {
                sum += int.Parse(numbersToAdd[i]);
            }
            return sum;
        }

        private static string[] Split(string numbers)
        {
            return Regex.Split(numbers, ",|\n|;|#|@|%|!");
        }

        private static string[] Get(string numbers)
        {
            int newLineIndex = numbers.IndexOf('\n');
            if (numbers.Length > 2)
            {
                if (numbers[0] == '/')
                {
                    numbers = numbers.Substring(newLineIndex+1);
                }
            }
            return Split(numbers);
        }
    }
}
