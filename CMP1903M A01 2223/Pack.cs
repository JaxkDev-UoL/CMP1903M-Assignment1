using System;
using System.Collections.Generic;

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
            //•	The typeOfShuffle should be 1: Fisher-Yates Shuffle  2: Riffle Shuffle  3: No Shuffle
            // https://en.wikipedia.org/wiki/Fisher–Yates_shuffle#The_modern_algorithm
            if(typeOfShuffle < 1 || typeOfShuffle > 3) {
                throw new ArgumentOutOfRangeException("typeOfShuffle", "typeOfShuffle must be in the range 1-3 inclusive.");
            }
            if(typeOfShuffle == 3) {
                return true;
            }

            Pack pack = Pack.singleton;
            Random rand = new Random();

            if(typeOfShuffle == 1) {
                /*
                    -- To shuffle an array a of n elements (indices 0..n-1):
                    for i from 0 to n−2 do
                        j ← random integer such that i ≤ j < n
                        exchange a[i] and a[j]
                */
                for(int i = 0; i < 51; i++) {
                    int j = rand.Next(i, 52);
                    (pack.pack[j], pack.pack[i]) = (pack.pack[i], pack.pack[j]);
                }
            } else {

            }
            
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
                throw new ArgumentOutOfRangeException("amount", "Amount must be in the range 1-52 inclusive.");
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
