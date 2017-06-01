using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serizieble_Cards
{
    public partial class Form1 : Form
    {
        Random random = new Random();
       


        private Deck RandomDeck(int number)
        {
            Deck myDeck = new Deck(new Cards[] { });
            for (int i=0;i< number;i++)
            {
                myDeck.Add(new Cards((Suits)random.Next(4), (Values)random.Next(1, 14)));
            }
            return myDeck;
        }

        private void DealCards(Deck deckToDeal,string title)
        {
            Console.WriteLine(title);
            while(deckToDeal.Count>0)
            {
                Cards nextCard = deckToDeal.Deal(0);
                Console.WriteLine(nextCard.Name);
            }
            Console.WriteLine("---------------------");
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Deck deckToWrite = RandomDeck(5);
            using (Stream output = File.Create("Deck1.dat"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(output, deckToWrite);
            }
            DealCards(deckToWrite, "Что было записано в файл");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Stream input = File.OpenRead("Deck1.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                Deck deckFromFile = (Deck)bf.Deserialize(input);
                DealCards(deckFromFile, "Что было прочитано из файла");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (Stream output = File.Create("Deck2.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                for(int i=1;i<=5;i++)
                {
                    Deck deckToWrite = RandomDeck(random.Next(1, 11));
                    bf.Serialize(output, deckToWrite);
                    DealCards(deckToWrite, "Колода #" + i + " записана");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (Stream input = File.OpenRead("Deck2.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                for(int i=1;i<=5;i++)
                {
                    Deck deckToRead = (Deck)bf.Deserialize(input);
                    DealCards(deckToRead, "Колода #" + i + " прочитана");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (Stream output = File.Create("ace-h.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();

                Cards card1 = new Cards((Suits)0, (Values)3);
                    bf.Serialize(output, card1);
                Console.WriteLine("карта " + card1.Name + " записана");
            }

            using (Stream output = File.Create("ace-d.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();

                Cards card1 = new Cards((Suits)2, (Values)6);
                bf.Serialize(output, card1);
                Console.WriteLine("карта " + card1.Name + " записана");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            byte[] firstFile = File.ReadAllBytes("ace-h.dat");
            byte[] secondFile = File.ReadAllBytes("ace-d.dat");
            for (int i = 0; i < firstFile.Length; i++)
                if (firstFile[i] != secondFile[i])
                    Console.WriteLine("Byte #{0}: {1} versus {2}", i, firstFile[i], secondFile[i]);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader(@"C:\files\inputFile.txt"))
                using (StreamWriter writer =new StreamWriter(@"C:\files\output.txt"))
            {
                int position = 0;

                while (!reader.EndOfStream)
                {
                    char[] buffer = new char[16];
                    int charactersRead = reader.ReadBlock(buffer, 0, 16);
                    writer.Write("{0}: ", String.Format("{0:x4}", position));
                    position += charactersRead;

                    for(int i=0;i<16;i++)
                    {
                        if (i < charactersRead)
                        {
                            string hex = String.Format("{0:x2}", (byte)buffer[i]);
                            writer.Write(hex + " ");
                        }
                        else
                            writer.Write(" ");
                        if (i == 7) { writer.Write("-- "); }
                        if(buffer[i]<32 || buffer[i]>250) { buffer[i] = '.'; }
                    }
                    string bufferContents = new string(buffer);

                    writer.WriteLine(" " + bufferContents.Substring(0, charactersRead));
                }
            }
        }
    }
}
