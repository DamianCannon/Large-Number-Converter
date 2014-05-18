using LargeNumberConverter;
using NUnit.Framework;

namespace LargeNumberConverterTests
{
    [TestFixture]
    public class NumberConverterTests
    {
        private INumberConverter _compoundNumberConverter = new NumberConverter();

        [SetUp]
        public void SetUp()
        {
            _compoundNumberConverter = new NumberConverter();
        }

        [TestCase(0, "zero")]
        [TestCase(1, "one")]
        [TestCase(20, "twenty")]
        public void GivenContiguousNonCompoundNumber_ReturnNonCompoundString(int inputNumber, string expectedResult)
        {
            var actualResult = _compoundNumberConverter.Convert(inputNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(30, "thirty")]
        [TestCase(90, "ninety")]
        public void GivenNonContiguousNonCompoundNumber_ReturnNonCompoundString(int inputNumber, string expectedResult)
        {
            var actualResult = _compoundNumberConverter.Convert(inputNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(21, "twenty one")]
        [TestCase(22, "twenty two")]
        [TestCase(99, "ninety nine")]
        public void GivenCompoundNumberLessThan100_ReturnCompoundString(int inputNumber, string expectedResult)
        {
            var actualResult = _compoundNumberConverter.Convert(inputNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(100, "one hundred")]
        [TestCase(900, "nine hundred")]
        public void GivenWholeHundredNumberMoreThan99LessThan1000_ReturnCompoundString(int inputNumber, string expectedResult)
        {
            var actualResult = _compoundNumberConverter.Convert(inputNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(101, "one hundred and one")]
        [TestCase(105, "one hundred and five")]
        [TestCase(240, "two hundred and forty")]
        [TestCase(627, "six hundred and twenty seven")]
        [TestCase(999, "nine hundred and ninety nine")]
        public void GivenNonWholeNumberMoreThan99LessThan1000_ReturnCompoundString(int inputNumber, string expectedResult)
        {
            var actualResult = _compoundNumberConverter.Convert(inputNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(1000, "one thousand")]
        [TestCase(1001, "one thousand and one")]
        [TestCase(4321, "four thousand three hundred and twenty one")]
        [TestCase(9999, "nine thousand nine hundred and ninety nine")]
        public void GivenWholeNumberMoreThan999LessThan10000_ReturnCompoundString(int inputNumber, string expectedResult)
        {
            var actualResult = _compoundNumberConverter.Convert(inputNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(10000, "ten thousand")]
        [TestCase(10101, "ten thousand one hundred and one")]
        [TestCase(99999, "ninety nine thousand nine hundred and ninety nine")]
        public void GivenWholeNumberMoreThan9999LessThan100000_ReturnCompoundString(int inputNumber, string expectedResult)
        {
            var actualResult = _compoundNumberConverter.Convert(inputNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(100000, "one hundred thousand")]
        [TestCase(540320, "five hundred and forty thousand three hundred and twenty")]
        [TestCase(999999, "nine hundred and ninety nine thousand nine hundred and ninety nine")]
        public void GivenWholeNumberMoreThan99999LessThan1000000_ReturnCompoundString(int inputNumber, string expectedResult)
        {
            var actualResult = _compoundNumberConverter.Convert(inputNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(1000000, "one million")]
        [TestCase(8000400, "eight million four hundred")]
        [TestCase(9999999, "nine million nine hundred and ninety nine thousand nine hundred and ninety nine")]
        public void GivenWholeNumberMoreThan999999LessThan10000000_ReturnCompoundString(int inputNumber, string expectedResult)
        {
            var actualResult = _compoundNumberConverter.Convert(inputNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(10000000, "ten million")]
        [TestCase(56945781, "fifty six million nine hundred and forty five thousand seven hundred and eighty one")]
        [TestCase(99999999, "ninety nine million nine hundred and ninety nine thousand nine hundred and ninety nine")]
        public void GivenWholeNumberMoreThan9999999LessThan100000000_ReturnCompoundString(int inputNumber, string expectedResult)
        {
            var actualResult = _compoundNumberConverter.Convert(inputNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(100000000, "one hundred million")]
        [TestCase(501034000, "five hundred and one million thirty four thousand")]
        [TestCase(999999999, "nine hundred and ninety nine million nine hundred and ninety nine thousand nine hundred and ninety nine")]
        public void GivenWholeNumberMoreThan99999999LessThan1000000000_ReturnCompoundString(int inputNumber, string expectedResult)
        {
            var actualResult = _compoundNumberConverter.Convert(inputNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(-21, "negative twenty one")]
        [TestCase(-56945781, "negative fifty six million nine hundred and forty five thousand seven hundred and eighty one")]
        public void GivenCompoundLessThan0_ReturnNegativeCompoundString(int inputNumber, string expectedResult)
        {
            var actualResult = _compoundNumberConverter.Convert(inputNumber);
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}