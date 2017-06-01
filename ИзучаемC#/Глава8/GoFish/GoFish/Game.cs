using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoFish
{
    class Game
    {
        private List<Player> players;
        private Dictionary<Values, Player> books;
        private Deck stock;
        private TextBox textBoxOnForm;

        public Game (string playerName,IEnumerable<string> opponentNames,TextBox textBoxOnForm)
        {
            Random random = new Random();
            this.textBoxOnForm = textBoxOnForm;
            players = new List<Player>();
            players.Add(new Player(playerName, random, textBoxOnForm));
            foreach (string player in opponentNames)
                players.Add(new Player(player, random, textBoxOnForm));
            books = new Dictionary<Values, Player>();
            stock = new Deck();
            Deal();
            players[0].SortHand();
        }

        private void Deal()
        {
            stock.Shuffle();
              for (int i=0;i<5;i++)
                foreach (Player player in players)
                    player.TakeCard(stock.Deal());
            

            foreach (Player player in players)
                PullOutBooks(player);
        }

        public bool PlayOneRound(int selectedPlayerCard)
        {
            Values cardToAskFor = players[0].Peek(selectedPlayerCard).value;
            for(int i=0;i<players.Count;i++)
            {
                if(i==0)
                players[0].AskForACard(players, 0, stock,cardToAskFor);
                else
                    players[i].AskForACard(players, i, stock);
                if(PullOutBooks(players[i]))
                {
                    textBoxOnForm.Text += players[i].Name + " drew a new hand" + Environment.NewLine;
                    int card = 1;
                    while(card<=5 && stock.Count>0)
                    {
                        players[i].TakeCard(stock.Deal());
                        card++;
                    }
                }
                players[0].SortHand();
                if (stock.Count==0)
                {
                    textBoxOnForm.Text = "The stock is out of cards.Game over!" + Environment.NewLine;
                    return true;
                }

             }

            return false;
        }

        
        public bool PullOutBooks(Player player)
        {
            IEnumerable<Values> booksToreturn=player.PullOutBooks();
            foreach (Values value in booksToreturn)
                books.Add(value, player);
            if (player.CardCount == 0)
            {
                return true;
            }
            
                return false;
        }

        public string DescribeBooks()
        {
            string toReturn="";
            foreach(Values value in books.Keys)
            {
                toReturn += books[value].Name + " has a book of " + Cards.Plural(value) + Environment.NewLine;
            }

            return toReturn;
        }

        public string GetWinnerName()
        {
            Dictionary<string, int> winners=new Dictionary<string, int>();
            foreach(Values value in books.Keys)
            {
                string name = books[value].Name;
                if (winners.ContainsKey(name))
                    winners[name]++;
                else
                    winners.Add(name, 1);
            }

            int mostBooks = 0;
            foreach(string name in winners.Keys)
                if (winners[name] > mostBooks)
                    mostBooks = winners[name];
                bool tie = false;
                string winnerList = "";
            foreach (string name in winners.Keys)
                if (winners[name] == mostBooks)
                {
                    if(!String.IsNullOrEmpty(winnerList))
                    {
                        winnerList += " and ";
                        tie = true;
                    }
                    winnerList += name;
                }
            winnerList += " with " + mostBooks + " books ";
            if (tie)
                return "A tie between " + winnerList;
            else
                return winnerList;
            }

        public IEnumerable<string> GetPlayerCardNames()
        {
            return players[0].GetCardNames();
        }

        public string DescribePlayerHands()
        {
            string toReturn="";
            foreach(Player player in players)
            {
                toReturn += player.Name + " has " + player.CardCount;
                if (player.CardCount == 1)
                    toReturn += " card." + Environment.NewLine;
                else
                    toReturn += " cards." + Environment.NewLine; 
            }

            toReturn += "The stock has " + stock.Count + " cards left.";
            return toReturn;
        }
    }
}
