using System;
using System.Collections.Generic;
using System.Linq;

namespace KataStringCalculator
{
    public class StringCalculator
    {
        private readonly char[] _delimiters = { ',', '\n' };

        public int Add(string expression)
        {
            if (string.IsNullOrEmpty(expression)) return 0;
                        
            var delimiter = _delimiters;

            if (ContainsDelimiter(expression))
            {
                delimiter = HandleDelimiters(ref expression);
            }

            return Add(expression, delimiter);
        }

        private int Add(string expression, char[] delimiter)
        {
            var errors = new List<int>();

            int result = expression.Split(delimiter).Sum(item => Add(item.ToInteger(), errors));

            if (errors.IsThereError()) throw new ArgumentException(errors.PrepareErrorMessage());

            return result;
        }

        private int Add(int value, ICollection<int> errors)
        {
            if (value.IsNegativeValue()) errors.Add(value);

            if (value.IsValueBiggerThanThousand()) return 0;

            return value;
        }

        private char[] HandleDelimiters(ref string input)
        {       
            char delimiter = input[2];
            input = input.Substring(4);
            return new[] { delimiter, ',', '\n' };            
        }

        private bool ContainsDelimiter(string input)
        {
            return input.StartsWith("//");
        }
    }
}