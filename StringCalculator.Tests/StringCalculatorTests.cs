using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void Add_GivenAnEmptyString_ShouldReturn0(){
            //---------------Arrange-------------------
            var sut = CreateStringCalculator();
            var expected = 0;
            //---------------Act ----------------------
            var actual = sut.Add("");
            //---------------Assert -----------------------
            Assert.AreEqual(expected,actual);         
        }

        [TestCase(1, "1")]
        [TestCase(5, "5")]
        [TestCase(10, "10")]
        public void Add_GivenOneNumber_ShouldReturnTheNumberItself(int expected, string numbers)
        {
            var sut = CreateStringCalculator();
            //---------------Act ----------------------
            var actual = sut.Add(numbers);
            //---------------Assert -----------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, "1,2")]
        [TestCase(50, "25,25")]
        [TestCase(1000, "990,10")]
        public void Add_GivenTwoNumbers_ShouldReturnTheSum(int expected, string numbers)
        {
            //---------------Arrange-------------------
            var sut = CreateStringCalculator();
            //---------------Act ----------------------
            var actual = sut.Add(numbers);
            //---------------Assert -----------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase(15, "1,2,3,4,5")]
        [TestCase(85, "25,25,20,10,5")]
        [TestCase(735, "295,100,50,250,40")]
        [TestCase(10, "1,1,1,1,1,1,1,1,1,1")]
        public void Add_GivenUnknownNumbers_ShouldReturnTheSum(int expected, string numbers)
        {
            //---------------Arrange-------------------
            var sut = CreateStringCalculator();
            //---------------Act ----------------------
            var actual = sut.Add(numbers);
            //---------------Assert -----------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase(5, "2\n1,2")]
        [TestCase(7, "2\n1,1\n3")]
        [TestCase(14, "8\n1,2\n2,1")]
        public void Add_GivenNumbersWithNewLines_ShouldReturnTheSum(int expected, string numbers)
        {
            //---------------Arrange-------------------
            var sut = CreateStringCalculator();
            //---------------Act ----------------------
            var actual = sut.Add(numbers);
            //---------------Assert -----------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, "//;\n1#2")]
        [TestCase(7, "//#\n2;1,3\n1")]
        [TestCase(16, "//@\n5,2\n6;3")]
        public void Add_GivenNumbersWithMultipleDelimiters_ShouldReturnTheSum(int expected, string numbers)
        {
            //---------------Arrange-------------------
            var sut = CreateStringCalculator();
            //---------------Act ----------------------
            var actual = sut.Add(numbers);
            //---------------Assert -----------------------
            Assert.AreEqual(expected, actual);
        }

       // [TestCase(1, "//[@#$%];\n-1#2")]
        //[TestCase(7, "//[****]\n2;1,3\n1")]
       // [TestCase(16, "//@#@\n5,2\n6;3")]
        public void Add_GivenNumbersHavngNegative_ShouldReturnNegativesNotAllowed(int expected, string numbers)
        {
            //---------------Arrange-------------------
            var sut = CreateStringCalculator();
            //---------------Act ----------------------
            var actual = sut.Add(numbers);
            //---------------Assert -----------------------
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, "//[@#$%];\n1#2")]
        [TestCase(7, "//[****]\n2;1,3\n1")]
        [TestCase(16, "//@#@\n5,2\n6;3")]
        public void Add_GivenNumbersWithMultipleDelimitersOfAnylength_ShouldReturnTheSum(int expected, string numbers)
        {
            //---------------Arrange-------------------
            var sut = CreateStringCalculator();
            //---------------Act ----------------------
            var actual = sut.Add(numbers);
            //---------------Assert -----------------------
            Assert.AreEqual(expected, actual);
        }

        private static StringCalculator CreateStringCalculator()
        {
            //---------------Arrange-------------------
            return new StringCalculator();
        }

    }
}
