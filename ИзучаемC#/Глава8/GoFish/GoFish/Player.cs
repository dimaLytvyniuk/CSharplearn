using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoFish
{
    class Player
    {
        private string name;
        public string Name { get { return name; } }
        private Random random;
        private Deck cards;
        private TextBox textBoxOnForm;

        public Player(String name,Random random,TextBox textBoxOnForm)
        {
            this.name = name;
            this.random = random;
            this.textBoxOnForm = textBoxOnForm;
            this.cards = new Deck(new Cards[] { });
            textBoxOnForm.Text += name + " has joined the game" + Environment.NewLine;
        }

        public IEnumerable<Values> PullOutBooks()
        {
            List<Values> books = new List<Values>();
            for(int i=1;i<=13;i++)
            {
                Values value = (Values)i;
                int howMany = 0;
                for (int card = 0; card < cards.Count; card++)
                    if (cards.Peek(card).value == value)
                        howMany++;
                if(howMany==4)
                {
                    books.Add(value);
                    cards.PullOutValues(value);
                }
            }

            return books;
        }

        public Values GetRandomValue()
        {
            int numberBetween1And13 = random.Next(1, 14);
            Values value = (Values)numberBetween1And13;
            return value;
        }

        public Deck DoYouHaveAny(Values value)
        {
            Deck IHaveSome = cards.PullOutValues(value);
            textBoxOnForm.Text+=Name + " has "+IHaveSome.Count + " " + Cards.Plural(value) + Environment.NewLine;
            return IHaveSome;
        }

        public void AskForACard(List<Player> players,int myIndex,Deck stock)
        {
            if (stock.Count>0)
            {
                if (cards.Count == 0)
                    cards.Add(stock.Deal());
                Values Randomvalue = GetRandomValue();
                AskForACard(players, myIndex, stock, Randomvalue); 

            }

        }

        public void AskForACard(List<Player> players, int myIndex, Deck stock,Values value)
        {
            textBoxOnForm.Text += Name + " asks if anyone has a " + value.ToString() + Environment.NewLine;

            int totalCardsGiven = 0;
            for(int i=0;i<players.Count;i++)
            {
                if (i!=myIndex)
                {
                    Player player = players[i];
                    Deck CardsGiven = player.DoYouHaveAny(value);
                    totalCardsGiven += CardsGiven.Count;
                    while (CardsGiven.Count > 0)
                        cards.Add(CardsGiven.Deal());
                }
            }
            if((totalCardsGiven ==0) && (stock.Count>0))
            {
                textBoxOnForm.Text += Name + " must draw from the stock." + Environment.NewLine;
                cards.Add(stock.Deal());
            }

           
        }

        public int CardCount { get { return cards.Count; } }
        public void TakeCard(Cards card) { cards.Add(card); }
        public IEnumerable<string> GetCardNames() { return cards.GetCardNames(); }
        public Cards Peek(int cardNumber) { return cards.Peek(cardNumber); }
        public void SortHand() { cards.Sort(); }
    }
}
