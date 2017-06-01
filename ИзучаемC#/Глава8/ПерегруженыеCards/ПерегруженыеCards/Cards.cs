using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards
{
    enum Suits
    {
        Spades=0,
        Clubs=1,
        Diamonds=2,
        Hearts=3,
    }

    enum Values
    {
        Ace=1,
        Two=2,
        Three=3,
        Four=4,
        Five=5,
        Six=6,
        Seven=7,
        Eight=8,
        Nine=9,
        Ten=10,
        Jack=11,
        Queen=12,
        King=13,
    }

    class Cards
    {
        public Cards ( Suits suits,Values values)
        {
            Name = values.ToString() + " of " + suits.ToString();
            suit = suits;
            value = values;
        }

       public Suits suit { get; set; }
        public Values value { get; set; }
        public string Name { get; private set; }

        public static bool DoesCardMatch(Cards cardToCheck,Suits suit)
        {
            if (cardToCheck.suit == suit)
                return true;
            else return false;
        }

        public static bool DoesCardMatch(Cards cardToCheck,Values value)
        {
            if (cardToCheck.value == value)
                return true;
            else
                return false;
        }
    }
}
