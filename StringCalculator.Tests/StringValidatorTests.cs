using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Tests
{
    [TestFixture]
    class StringValidatorTests
    {
        [TestCase("negatives not allowed : -1", "-1")]
        [TestCase("negatives not allowed : -12", "-12")]
        [TestCase("negatives not allowed : -132", "-132")]
        public void Validate_GivenANumberHavingANegative_ShouldReturnNegativesNotAllowed(string expected, string numbers)
        {
            //---------------Arrange-------------------
            var sut = CreateStringValidator();
            //---------------Act ----------------------
            var actual = Assert.Throws<Exception>(() => sut.Validate(numbers));
            //---------------Assert -----------------------
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("negatives not allowed : -1 -2", "//;\n-1;-2")]
        [TestCase("negatives not allowed : -2", "//#\n-2#1#3\n1")]
        [TestCase("negatives not allowed : -600", "//@\n5@2\n-600@3000")]
        public void Validate_GivenNumbersHavingNegatives_ShouldReturnNegativesNotAllowed(string expected, string numbers)
        {
            //---------------Arrange-------------------
            var sut = CreateStringValidator();
            //---------------Act ----------------------
            var actual = Assert.Throws<Exception>(() => sut.Validate(numbers));
            //---------------Assert -----------------------
            Assert.AreEqual(expected, actual.Message);
        }

        private static StringValidator CreateStringValidator()
        {
            return new StringValidator();
        }
    }



}
