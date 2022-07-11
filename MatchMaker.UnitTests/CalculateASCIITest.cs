using NUnit.Framework;
using MatchMaker.Abstract;
using MatchMaker.Concrete;
using System;

namespace MatchMaker.UnitTests
{
    public class CalculateASCIITests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculateASCII_EmtpyString_Exeption()
        {
            //arrange
            IASCIICalculator calculator = new ASCIICalculator();

            //act

            var ex = Assert.Throws<ArgumentNullException>(() => calculator.CalculateASCII(string.Empty));

            //assert

            Assert.IsNotNull(ex);
        }
    }
}