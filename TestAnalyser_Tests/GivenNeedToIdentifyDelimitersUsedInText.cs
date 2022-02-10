using System.Linq;
using NUnit.Framework;
using TextAnalyser;

namespace TestAnalyser_Tests
{
    class GivenNeedToIdentifyDelimitersUsedInText
    {
        [TestCase("parcel, envelope, box & pencil", "&,")]
        [TestCase("kite & string", "&")]
        [TestCase("john | paul - Ringo", "-|")]
        public void CanExtrapulateDelimiters(string freeText, string expectedDelimiters)
        {
            var textParser = new TextParserAnalyser();
            var result = textParser.FindDelimitersUsed(freeText).ToArray();
            Assert.That(result, Is.EqualTo(expectedDelimiters));
        }

    }
}
