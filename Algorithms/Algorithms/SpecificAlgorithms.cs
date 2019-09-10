using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class SpecificAlgorithms
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
        
        private static Dictionary<int, string> RomanNumberRepresentation = new Dictionary<int, string>()
        {
            { 1, "I"},
            { 5, "V" },
            { 10, "X"},
            { 50, "L" },
            { 100, "C" },
            { 500, "D" },
            { 1000, "M" },
        };
    }
}
