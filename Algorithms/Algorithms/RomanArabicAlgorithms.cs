using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class RomanArabicAlgorithms
    {
        public static string IntToRoman(int num)
        {
            var roman = "";
            var thousandsResult = GetThousandPart(num);
            var hundreadResult = GetPartForRank(thousandsResult.number, 100);
            var tenResult = GetPartForRank(hundreadResult.number, 10);
            var oneResult = GetPartForRank(tenResult.number, 1);

            roman += thousandsResult.roman;
            roman += hundreadResult.roman;
            roman += tenResult.roman;
            roman += oneResult.roman;

            return roman;
        }

        public static int RomanToInt(string s)
        {
            var arabian = 0; 
            var thousandToIntResult = GetPartForRomanRank(s, 1000);
            var hundreadToIntResult = GetPartForRomanRank(thousandToIntResult.roman, 100);
            var tenToIntResult = GetPartForRomanRank(hundreadToIntResult.roman, 10);
            var oneToIntResult = GetPartForRomanRank(tenToIntResult.roman, 1);

            arabian += thousandToIntResult.number;
            arabian += hundreadToIntResult.number;
            arabian += tenToIntResult.number;
            arabian += oneToIntResult.number;

            return arabian;
        }
        
        private static (int number, string roman) GetThousandPart(int num)
        {
            var number = num;
            var roman = string.Empty;
            
            var thousands = num / 1000;
            if (thousands != 0)
            {
                number -= thousands * 1000;
                for (var i = 0; i < thousands; i++)
                {
                    roman += RomanNumberRepresentation[1000];
                }
            }

            return (number, roman);
        }

        private static (int number, string roman) GetPartForRank(int num, int rank)
        {
            var number = num;
            var roman = string.Empty;

            var nineRank = 9 * rank;
            var fiveRank = 5 * rank;
            var fourRank = 4 * rank;
            var tenRank = 10 * rank;
            
            if (number >= nineRank)
            {
                number -= nineRank;
                roman += RomanNumberRepresentation[rank] + RomanNumberRepresentation[tenRank];
            }
            else 
            {
                if (number >= fiveRank)
                {
                    number -= fiveRank;
                    roman += RomanNumberRepresentation[fiveRank];
                }

                if (number >= fourRank)
                {
                    number -= fourRank; 
                    roman += RomanNumberRepresentation[rank] + RomanNumberRepresentation[fiveRank];
                }
                else
                {
                    var ranksCount = number / rank;
                    for (var i = 0; i < ranksCount; i++)
                    {
                        roman += RomanNumberRepresentation[rank];
                    }

                    number -= ranksCount * rank;
                }
            }
            
            return (number, roman);
        }
        
        private static (string roman, int number) GetPartForRomanRank(string str, int rank)
        {
            var roman = str;
            var number = 0;
            
            var nineIntRank = 9 * rank;
            var fiveIntRank = 5 * rank;
            var fourIntRank = 4 * rank;
            var tenIntRank = 10 * rank;
            
            var nineRomanRank = RomanNumberRepresentation[rank] + RomanNumberRepresentation[tenIntRank];
            var fiveRomanRank = RomanNumberRepresentation[fiveIntRank];
            var fourRomanRank = RomanNumberRepresentation[rank] + RomanNumberRepresentation[fiveIntRank];
            var romanRank = RomanNumberRepresentation[rank];
            
            if (roman.StartsWith(nineRomanRank))
            {
                roman = roman.Substring(nineRomanRank.Length);
                number += nineIntRank;
            }
            else 
            {
                if (roman.StartsWith(fiveRomanRank))
                {
                    roman = roman.Substring(fiveRomanRank.Length);
                    number += fiveIntRank;
                }

                if (roman.StartsWith(fourRomanRank))
                {
                    roman = roman.Substring(fourRomanRank.Length); 
                    number += fourIntRank;
                }
                else
                {
                    while (roman.StartsWith(romanRank))
                    {
                        roman = roman.Substring(romanRank.Length);
                        number += rank;
                    }
                }
            }
            
            return (roman, number);
        }
        
        private static Dictionary<int, string> RomanNumberRepresentation = new Dictionary<int, string>()
        {
            { 1, "I"},
            { 5, "V" },
            { 10, "X"},
            { 50, "L" },
            { 100, "C" },
            { 500, "D" },
            { 1000, "M" },
            { 5000, "MMMMM"},
            { 10000, "MMMMMMMMMMM"}
        };
    }
}
