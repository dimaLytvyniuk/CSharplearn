using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecksOfCards
{
    public partial class Form1 : Form
    {
        Deck deck1;
        Deck deck2;
        Random random;
        public Form1()
        {
            InitializeComponent();
            ResetDeck(1);
            ResetDeck(2);
            RedrawDeck(1);
            RedrawDeck(2);

        }

        private void moveToDeck2_Click(object sender, EventArgs e)
        {
            deck2.Add(deck1.Deal(DeckBox1.SelectedIndex));
            RedrawDeck(1);
            RedrawDeck(2);
        }

        private void ResetDeck(int index)
        {
            random = new Random();
            if (index==1)
            {
                deck1 = new Deck(new Cards[] { });
                for(int i=0;i<10;i++)
                {
                    deck1.Add(new Cards((Suits)random.Next(4), (Values)random.Next(1, 14)));
                }
                deck1.Sort();
            }

            else
            {
                deck2 = new Deck();
            }
        }

        private void RedrawDeck(int DeckNumber)
        {
            if (DeckNumber==1)
            {
                DeckBox1.Items.Clear();
                foreach (string cardName in deck1.GetCardNames())
                    DeckBox1.Items.Add(cardName);
                label1.Text = "Deck #1 (" + deck1.Count + " cards)";
            }
            else
            {
                DeckBox2.Items.Clear();
                foreach (string cardName in deck2.GetCardNames())
                    DeckBox2.Items.Add(cardName);
                label2.Text = "Deck #2 (" + deck2.Count + " cards)";
            }
        }

        private void reset1_Click(object sender, EventArgs e)
        {
            ResetDeck(1);
            RedrawDeck(1);
        }

        private void reset2_Click(object sender, EventArgs e)
        {
            ResetDeck(2);
            RedrawDeck(2);
        }

        private void shuffle1_Click(object sender, EventArgs e)
        {
            deck1.Shuffle();
            RedrawDeck(1);
        }

        private void shuffle2_Click(object sender, EventArgs e)
        {
            deck2.Shuffle();
            RedrawDeck(2);
        }

        private void moveToDeck1_Click(object sender, EventArgs e)
        {
            deck1.Add(deck2.Deal(DeckBox2.SelectedIndex));
            RedrawDeck(1);
            RedrawDeck(2);
        }
    }
}
