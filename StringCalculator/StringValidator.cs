using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class StringValidator
    {
        public string Validate(string numbers)
        {
            CheckForNegative(numbers);

            if (numbers.Length > 2)
            {
                numbers = CutOffDelimiter(numbers);
            }
            return numbers;
        }

        private static string CutOffDelimiter(string numbers)
        {
            int newLineIndex = numbers.IndexOf('\n');
            if (numbers[0] == '/')
            {
                numbers = numbers.Substring(newLineIndex + 1);
            }

            return numbers;
        }

        private static void CheckForNegative(string numbers)
        {
            string negatives = "";
            negatives = Get(numbers, negatives);

            if (negatives.Length > 0)
            {
                ThrowException(negatives);
            }
        }

        private static string Get(string numbers, string negatives)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == '-')
                {
                    negatives += " -";
                    int index = i;
                    while (index < numbers.Length - 1 && Char.IsNumber(numbers[index + 1]))
                    {
                        negatives += "" + numbers[index + 1];
                        index++;
                    }
                }
            }
            return negatives;
        }

        private static void ThrowException(string negativeNumbers)
        {
            throw new Exception("negatives not allowed :" + negativeNumbers + "");
        }
    }
}
