using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GuySerializer
{   
    [DataContract (Namespace = "GuySerializer")]
    class Card
    {
        [DataMember]
        public Suits Suit { get; set; }

        [DataMember]
        public Values Value { get; set; }

        public Card(Suits suit, Values value)
        {
            this.Suit = suit;
            this.Value = value;
        }

        private static Random r = new Random();

        public static Card RandomCard()
        {
            return new Card((Suits)r.Next(4), (Values)r.Next(1, 14));
        }

        public string Name
        {
            get
            {
                return Value.ToString() + " of " + Suit.ToString();
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }

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
}
