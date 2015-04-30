using System;
using NUnit.Framework;

namespace KataStringCalculator
{
    public class StringCalculatorTests
    {
        [Test]
        public void Should_return_0_when_input_is_an_empty_string()
        {
            Assert.AreEqual(0, new StringCalculator().Add(String.Empty));
        }

        [TestCase("1",1)]
        [TestCase("2",2)]
        [TestCase("3",3)]
        public void Should_return_a_number_when_input_is_just_a_number(string input, int expected)
        {
            Assert.AreEqual(expected, new StringCalculator().Add(input));
        }

        [TestCase("1,1",2)]
        [TestCase("1,2",3)]
        [TestCase("1,3",4)]
        [TestCase("1,4",5)]
        public void Should_return_the_sum_when_two_number_seperated_by_comma_as_the_input(string input, int expected)
        {
            Assert.AreEqual(expected, new StringCalculator().Add(input));
        }

        [TestCase("1,1,1,1", 4)]
        [TestCase("1,1,1,2", 5)]
        [TestCase("1,1,1,3", 6)]
        public void Should_return_the_sum_when_any_number_seperated_by_comma_as_the_input(string input, int expected)
        {
            Assert.AreEqual(expected, new StringCalculator().Add(input));
        }

        [TestCase("1\n1,1,1", 4)]
        [TestCase("1,1\n1,2", 5)]
        [TestCase("1,1,1\n3", 6)]
        public void Should_return_the_sum_when_any_number_seperated_by_comma_and_new_line_as_the_input(string input, int expected)
        {
            Assert.AreEqual(expected, new StringCalculator().Add(input));
        }

        [TestCase("//,\n1,1,1,1", 4)]
        [TestCase("//;\n1;1;1;2", 5)]
        [TestCase("//:\n1:1:1:3", 6)]
        public void Should_return_the_sum_when_any_number_seperated_by_a_new_delimiter_as_the_input(string input, int expected)
        {
            Assert.AreEqual(expected, new StringCalculator().Add(input));
        }

        [TestCase("-1,2,3,4", 10)]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Negatives not allowed: -1")]
        public void Should_throw_an_exception_Negatives_notallowed_when_input_contains_one_negative_value(string input, int expected)
        {
            new StringCalculator().Add(input);
        }

        [TestCase("-1,-2,3,4", 10)]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Negatives not allowed: -1,-2")]
        public void Should_throw_an_exception_Negatives_notallowed_when_input_contains_two_negative_value(string input, int expected)
        {
            new StringCalculator().Add(input);
        }

        [TestCase("-1,-2,-3,4", 10)]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = "Negatives not allowed: -1,-2,-3")]
        public void Should_throw_an_exception_Negatives_notallowed_when_input_contains_tree_negative_value(string input, int expected)
        {
            new StringCalculator().Add(input);
        }

        [TestCase("1001,1,2,3,4", 10)]
        [TestCase("1,2, 2000, 3,4", 10)]
        [TestCase("1,2, 3, 3000, 4", 10)]
        public void Should_ignore_numbers_when_any_are_bigger_than_1000(string input, int expected)
        {
            Assert.AreEqual(expected, new StringCalculator().Add(input));
        }
    }
}
