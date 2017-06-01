using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticVirtualOverride
{
    class Jewels
    {
        public string Sparkle()
        {
            return "Sparkle, sparkle!";
        }
    }

    class Safe
    {
        private Jewels contents = new Jewels();
        private string safeCombination = "12345";
        public Jewels Open(string combination)
        {
            if (combination == safeCombination)
                return contents;
            else
                return null;

        }

        public void PickLock(Locksmith lockpicker)
        {
            lockpicker.WriteDownCombination(safeCombination);
        }

    }

    class Owner
    {
        private Jewels returnedContents;
        public void ReceiveContents(Jewels safeContents)
        {
            returnedContents = safeContents;
            Console.WriteLine("Thanl you for returning my jewels!" + safeContents.Sparkle());
        }
    }

    class Locksmith
    {
        public void OpenSafe(Safe safe,Owner owner)
        {
            safe.PickLock(this);
            Jewels safeContents = safe.Open(writtenDownCombination);
            ReturnContents(safeContents, owner);
        }

        private string writtenDownCombination = null;

        public void WriteDownCombination(string combination)
        {
            writtenDownCombination = combination;
        }

        public virtual void ReturnContents(Jewels safeContents,Owner owner)
        {
            owner.ReceiveContents(safeContents);
        }

    }

    class JewelThief:Locksmith
    {
        private Jewels stolenJewels = null;
        public override void ReturnContents(Jewels safeContents,Owner owner)
        {
            stolenJewels = safeContents;
            Console.WriteLine("I'm staling the contents!" + stolenJewels.Sparkle());
        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            Owner owner = new Owner();
            Safe safe = new Safe();
            JewelThief jewelThief = new JewelThief();
            jewelThief.OpenSafe(safe, owner);

            Console.ReadKey();
        }
    }
}
