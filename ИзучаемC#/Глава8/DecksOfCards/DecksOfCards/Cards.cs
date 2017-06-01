using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecksOfCards
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

    class CardComparer_bySuit : IComparer<Cards>
    {
        public int Compare(Cards x, Cards y)
        {
            if (x.suit < y.suit)
                return -1;
            if (x.suit > y.suit)
                return 1;
            if (x.value < y.value)
                return -1;
            if (x.value > y.value)
                return 1;
            return 0;
        }

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

    }
}
