using System.Collections.Generic;
using System.Linq;

namespace TextAnalyser
{

    public class TextParserAnalyser
    {
        private readonly string _possibleDelimiters = "&,-|;";

        /// <summary>
        /// Pass in any text phrase containing any combination of delimiters '&',',','-','|' or ';')
        /// </summary>
        /// <param name="freeText">Phrase to parse, example "lock, stock & barrel"</param>
        /// <returns>Distinct list of delimiters used as list of char</returns>
        public IEnumerable<char> FindDelimitersUsed(string freeText)
        {
            return _possibleDelimiters.ToCharArray().Intersect(freeText.ToCharArray());
        }

    }
}
