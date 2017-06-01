using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Cards cardToCheck = new Cards(Suits.Clubs, Values.Three);
            bool doesItMatch = Cards.DoesCardMatch(cardToCheck, Suits.Hearts);
            bool doesItMatch_1 = Cards.DoesCardMatch(cardToCheck, Values.Three);

            Console.WriteLine(doesItMatch);
            Console.WriteLine(doesItMatch_1);

            
        }
    }
}
