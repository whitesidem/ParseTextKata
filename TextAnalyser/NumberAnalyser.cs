using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalyser
{
    public class NumberAnalyser
    {
        private readonly string _defaultDelimeters = "\n\r,-";

        /// <summary>
        /// Pass in free text phrase of numbers so they can be parsed and summed
        /// </summary>
        /// <param name="freeText">Text containing delimited numbers of named numbers - eg "one,2,3" or include delimiter "d:&five&six"</param>
        /// <returns>The sum of all the parsed numbers</returns>
        public int Parse(string freeText)
        {
            ThrowExceptionIfNull(freeText);
            freeText = TrimSpacesFromText(freeText);
            if (TextIsEmpty(freeText)) return 0;

            var numberSet = HasProvidedDelimeter(freeText) ? 
                GetNumberSetWithUserDefinedDelimeter(freeText) : 
                GetNumberSetUsingDefaultDelimeters(freeText);

            return SumNumbers(numberSet);
        }

        private static string TrimSpacesFromText(string freeText)
        {
            return freeText.Trim().ToLower();
        }

        private static bool HasProvidedDelimeter(string freeText)
        {
            return freeText.StartsWith("d:") && freeText.Length >= 3;
        }

        private List<string> GetNumberSetUsingDefaultDelimeters(string freeText)
        {
            return freeText.Split(_defaultDelimeters.ToCharArray()).ToList();
        }

        private static List<string> GetNumberSetWithUserDefinedDelimeter(string freeText)
        {
            var delimiter = ExtractDelimeterFromText(freeText);
            var text = RemoveDelimiterFromText(freeText);
            return text.Split(delimiter).ToList();
        }

        private static char ExtractDelimeterFromText(string freeText)
        {
            return freeText.Substring(2, 1)[0];
        }

        private static string RemoveDelimiterFromText(string freeText)
        {
            return freeText.Substring(3);
        }

        private int SumNumbers(IEnumerable<string> freeText)
        {
            var sum = freeText.Select(CastTextToValue).Sum();
            return sum;
        }

        private int CastTextToValue(string freeText)
        {
            switch (freeText)
            {
                case "zero":
                case "0":
                    {
                        return 0;
                    }
                case "one":
                case "1":
                    {
                        return 1;
                    }
                case "two":
                case "2":
                    {
                        return 2;
                    }
                case "three":
                case "3":
                    {
                        return 3;
                    }
                case "four":
                case "4":
                    {
                        return 4;
                    }
                case "five":
                case "5":
                    {
                        return 5;
                    }
                case "six":
                case "6":
                    {
                        return 6;
                    }
                case "seven":
                case "7":
                    {
                        return 7;
                    }
                case "eight":
                case "8":
                    {
                        return 8;
                    }
                case "nine":
                case "9":
                    {
                        return 9;
                    }
                default:
                {
                    throw new ArgumentException($"Could not cast the passed text to a number: {freeText}");
                }
            }
        }

        private static bool TextIsEmpty(string freeText)
        {
            return freeText == "";
        }

        private static void ThrowExceptionIfNull(string freeText)
        {
            if (freeText == null)
            {
                throw new ArgumentException("Passed text is null");
            }
        }
    }
}

