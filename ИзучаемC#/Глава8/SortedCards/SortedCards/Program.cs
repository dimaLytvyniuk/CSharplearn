using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedCards
{
    class Program
    {
        enum Suits
        {
            Spades = 0,
            Clubs = 1,
            Diamonds = 2,
            Hearts = 3,
        }

        enum Values
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13,
        }

        class Cards
        {
            public Cards(Suits suits, Values values)
            {
                Name = values.ToString() + " of " + suits.ToString();
                value = values;
                suits = suit;
            }
            public Suits suit { get; set; }
            public Values value { get; set; }
            public string Name { get; private set; }

        }

        class CardComparer_byValue : IComparer<Cards>
        {
            public int Compare(Cards x, Cards y)
            {
                if (x.value < y.value)
                    return -1;
                if (x.value > y.value)
                    return 1;
                if (x.suit < y.suit)
                    return -1;
                if (x.suit > y.suit)
                    return 1;
                    return 0;
            }

        }

        private static  void PrintCards(List<Cards> cards)
        {

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(cards[i].Name);
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            List<Cards> fiveCards = new List<Cards>();
            Random random = new Random();
            int numberBetween0And3 = 0;
            int numberBetween1And13 = 0;
            Suits suit;
            Values value;

            for (int i=0;i<5;i++)
            {
                 numberBetween0And3 = random.Next(4);
                 numberBetween1And13 = random.Next(1, 14);
                suit = (Suits)numberBetween0And3;
                value = (Values)numberBetween1And13;
                fiveCards.Add(new Cards(suit, value));
            }

            Console.WriteLine("Five random cards:");

            PrintCards(fiveCards);

            Console.WriteLine("Sorted Cards:");

            CardComparer_byValue valueComparer = new CardComparer_byValue();
            fiveCards.Sort(valueComparer);
            PrintCards(fiveCards);

            Console.ReadKey();
        }
    }
}
