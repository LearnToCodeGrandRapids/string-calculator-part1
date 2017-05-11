using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace StringCalculator
{
    public class Test
    {
        [Fact]
        public void Add_ShouldReturn0_ForEmptyString()
        {
            var sc = new StringCalculator();

            const int expected = 0;

            var actual = sc.Add(string.Empty);
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_ShouldReturn7_ForString7()
        {
            var sc = new StringCalculator();

            const int expected = 7;

            var actual = sc.Add("7");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_ShouldReturn3_ForStrings1And2()
        {
            var sc = new StringCalculator();

            const int expected = 3;

            var actual = sc.Add("1,2");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_ShouldReturn100_ForABunchOfNumbers()
        {
            var sc = new StringCalculator();

            const int expected = 100;

            var actual = sc.Add("1,9,10,30,50");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_ShouldReturn6_For1NewLine2Comma3()
        {
            var sc = new StringCalculator();

            const int expected = 6;

            var actual = sc.Add("1\n2,3");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Add_ShouldReturn3_For1SemiColon2WithSemiColonDelimiter()
        {
            var sc = new StringCalculator();

            const int expected = 3;

            var actual = sc.Add("//;\n1;2");

            Assert.Equal(expected, actual);
        }
    }

    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            var delimiters = new List<char>(new[] { ',', '\n' });

            // a custom delimiter will follow two forward slashes at the
            // beginning of the string
            if (numbers.StartsWith("//"))
            {
                delimiters.Add(numbers[2]);
                numbers = numbers.Substring(4);
            }

            var numberTokens = numbers.Split(delimiters.ToArray()).ToList();

            var runningTotal = 0;

            foreach (var token in numberTokens)
            {
                runningTotal += int.Parse(token);
            }

            return runningTotal;
        }
    }
}
