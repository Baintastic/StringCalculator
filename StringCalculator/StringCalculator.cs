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
            var sum = 0;
            if (string.IsNullOrEmpty(numbers))
            {
                return sum;
            }
            var numbersToAdd = Get(numbers);
            sum = Calculate(numbersToAdd);
            return sum;
        }

        private static string[] Get(string numbers)
        {
            StringValidator validator = new StringValidator();
            numbers = validator.Validate(numbers);
            return Split(numbers);
        }

        private static string[] Split(string numbers)
        {
            return numbers.Split(new[] { '\n', '[', ']', ',', ';', '#', '@', '%', '!','*'}, StringSplitOptions.RemoveEmptyEntries);     
        }

        private static int Calculate(string[] numbersToAdd)
        {
            var total = 0;
            for (int i = 0; i < numbersToAdd.Length; i++)
            {
                var number = int.Parse(numbersToAdd[i]);
                if (number <= 1000)
                {
                    total += number;
                }
            }
            return total;
        }

    }
}
