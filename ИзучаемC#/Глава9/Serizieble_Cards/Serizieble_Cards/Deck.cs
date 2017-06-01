using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serizieble_Cards
{
    [Serializable]

    class Deck
    {
        private List<Cards> cards;
        private Random random = new Random();

        public Deck()
        {
            cards = new List<Cards>();
            for (int suit = 0; suit <= 3; suit++)
                for (int value = 1; value <= 13; value++)
                    cards.Add(new Cards((Suits)suit, (Values)value));
        }

        public Deck(IEnumerable<Cards> intialCards)
        {
            cards = new List<Cards>(intialCards);
        }

        public int Count { get { return cards.Count; } }

        public void Add(Cards cardToAdd)
        {
            cards.Add(cardToAdd);
        }

        public Cards Deal(int index)
        {
            Cards CardToDeal = cards[index];
            cards.RemoveAt(index);
            return CardToDeal;
        }

        public void Shuffle()
        {
            List<int> indexOfRandom = new List<int>();
            int randomIndex;

            List<Cards> cards1 = new List<Cards>();

            for (int i = 0; i < cards.Count; i++)
            {
                cards1.Add(null);
            }

                for (int i=0;i<cards.Count;i++)
            {
                randomIndex = random.Next(cards.Count);

                while (indexOfRandom.Contains(randomIndex) == true)
                {
                    randomIndex = random.Next(cards.Count);
                }

                indexOfRandom.Add(randomIndex);

                cards1[randomIndex] = cards[i];
            }

            cards = cards1;

        }

        public IEnumerable<string> GetCardNames()
        {
            string[] listNames = new string[cards.Count];

            for(int i=0;i < cards.Count;i++)
            {
                listNames[i] = cards[i].Name;
            }

            return listNames;

        }

        public void Sort()
        {
            cards.Sort(new CardComparer_bySuit());
        }
    }
}
