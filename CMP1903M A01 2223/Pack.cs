using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        static Pack singleton;

        List<Card> pack;

        public Pack()
        {
            if(Pack.singleton != null) {
                // Onlt one pack, via singleton should exist.
                return;
            }
            Pack.singleton = this;

            //Initialise the card pack here
            this.pack = new List<Card>(52);
            for(int i = 1; i < 5; i++) {
                for(int j = 1; j < 14; j++) {
                    this.pack.Add(new Card(j, i));
                }
            }
        }

        public static bool shuffleCardPack(int typeOfShuffle)
        {
            Pack pack = Pack.singleton;
            
            return true;

        }

        public static Card deal()
        {
            //Deals one card
            Pack pack = Pack.singleton;
            Card c = pack.pack[0];
            pack.pack.RemoveAt(0);
            pack.pack.Add(c);
            return c;

        }

        public static List<Card> dealCard(int amount)
        {
            if(amount > 52 || amount < 1) {
                throw new ArgumentOutOfRangeException("amount", "Amount must be between 1-52 inclusive.");
            }
            //Deals the number of cards specified by 'amount'
            Pack pack = Pack.singleton;
            List<Card> cards = pack.pack.GetRange(0, amount);
            pack.pack.RemoveRange(0, amount);
            cards.ForEach(pack.pack.Add);
            return cards;
        }
    }
}
