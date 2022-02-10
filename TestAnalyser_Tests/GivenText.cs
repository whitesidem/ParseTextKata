using System;
using NUnit.Framework;

namespace TestAnalyser_Tests
{
    class GivenText
    {

        [TestFixture]
        public class WhenParsed
        {
            private TextAnalyser.NumberAnalyser _uut;

            [SetUp]
            public void SetUp()
            {
                _uut = new TextAnalyser.NumberAnalyser();
            }

            [Test]
            public void AndTextIsEmptyReturnsSumOf0()
            {
                var sum = _uut.Parse("");
                Assert.That(sum == 0);
            }

            [TestCase(null, "null passed")]
            [TestCase("invalid", "not valid text")]
            public void AndTextIsInvalid(string text, string description)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    _uut.Parse("invalid");
                });
            }

            [TestCase("One",1)]
            [TestCase("Two",2)]
            [TestCase("Three",3)]
            [TestCase("Four",4)]
            [TestCase("Five",5)]
            [TestCase("Six",6)]
            [TestCase("Seven",7)]
            [TestCase("Eight",8)]
            [TestCase("Nine",9)]
            public void AndTextIsAValidNumberReturnsTheValueOfTheNumber(string text, int expectedValue)
            {
                var sum = _uut.Parse(text);
                Assert.That(sum, Is.EqualTo(expectedValue));
            }

            [TestCase("Seven,Three",10)]
            [TestCase("One,Two",3)]
            [TestCase("One,Two-Three\nfour\rfive",15)]
            [TestCase("One,One,One",3)]
            [TestCase("One\nZero\nOne",2)]
            [TestCase("One,Two,Three,Four,Five,Six,Seven,Eight,Nine",45)]
            [TestCase("1,Two,3,Four,5,Six,7,Eight,9,0",45)]
            public void AndMultipleValuesAreSummed(string text, int expectedValue)
            {
                var sum = _uut.Parse(text);
                Assert.That(sum, Is.EqualTo(expectedValue));
            }

            [TestCase("d:|Seven|Three",10)]
            [TestCase("d:;Seven;One;Nine;3",20)]
            public void AndValuesAreSummedWithAnyDelimiter(string text, int expectedValue)
            {
                var sum = _uut.Parse(text);
                Assert.That(sum, Is.EqualTo(expectedValue));
            }

        }
    }
}
