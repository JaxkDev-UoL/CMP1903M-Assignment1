using System;
using System.Collections.Generic;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        static Pack singleton;

        List<Card> pack;

        public Pack() {
            if(Pack.singleton != null) {
                // Only one pack, via singleton should exist.
                return;
            }
            Pack.singleton = this;
            Pack.resetPack();
        }

        //Resets the entire pack to a default 52 card unshuffled state.
        public static void resetPack() {
            if(Pack.singleton == null) {
                new Pack();
                //Pack constructor will call this, no need to continue.
                return;
            }

            Pack pack = Pack.singleton;
            pack.pack = new List<Card>(52);
            for(int i = 1; i < 5; i++) {
                for(int j = 1; j < 14; j++) {
                    try {
                        pack.pack.Add(new Card(j, i));
                    } catch(ValueException exception) {
                        Console.WriteLine("Error has occured while adding cards to pack - " + exception.Message);
                    } catch(Exception exception) {
                        Console.WriteLine("Unhandled exception while adding cards to pack - Suit: " + i.ToString() + ", Value: " + j.ToString() + " - " + exception.Message);
                    }
                }
            }
        }

        public static bool shuffleCardPack(int typeOfShuffle) {
            //•	The typeOfShuffle should be 1: Fisher-Yates Shuffle  2: Riffle Shuffle  3: No Shuffle
            // https://en.wikipedia.org/wiki/Fisher–Yates_shuffle#The_modern_algorithm
            if(typeOfShuffle < 1 || typeOfShuffle > 3) {
                throw new ValueException(typeOfShuffle, "typeOfShuffle must be in the range 1-3 inclusive.");
            }
            if(typeOfShuffle == 3) {
                return true;
            }

            Pack pack = Pack.singleton;
            Random rand = new Random();

            if(typeOfShuffle == 1) {
                // Fisher-Yates Shuffle
                /*
                    -- To shuffle an array a of n elements (indices 0..n-1):
                    for i from 0 to n−2 do
                        j ← random integer such that i ≤ j < n
                        exchange a[i] and a[j]
                */
                for(int i = 0; i <= 50; i++) {
                    int j = rand.Next(i, 52);
                    (pack.pack[j], pack.pack[i]) = (pack.pack[i], pack.pack[j]);
                }
            } else {
                // Riffle Shuffle
                // https://www.youtube.com/watch?v=o-KBNdbJOGk
                // Perfect in-shuffle, the pack is split exactly in half.
                // Each iteration the card from the top of each stack is taken to form a new pack.
                // Resulting in a new pack with both halves exactly intertwined (alternating from first half and second half).
                List<Card> half_a = pack.pack.GetRange(0, 26);
                List<Card> half_b = pack.pack.GetRange(26, 26);
                List<Card> new_pack = new List<Card>(52);
                for(int i = 25; i >= 0; i--) {
                    new_pack.Add(half_b[i]);
                    new_pack.Add(half_a[i]);
                }
                pack.pack = new_pack;
            }

            return true;

        }

        public static Card deal() {
            //Deals one card
            Pack pack = Pack.singleton;
            Card c = pack.pack[0];
            pack.pack.RemoveAt(0);
            pack.pack.Add(c);
            //Messages moved inside relevant functions as per reviews feedback
            Console.WriteLine("-- Dealt single card. --");
            return c;

        }

        public static List<Card> dealCard(int amount) {
            if(amount > 52 || amount < 1) {
                throw new ValueException(amount, "Amount must be in the range 1-52 inclusive.");
            }
            //Deals the number of cards specified by 'amount'
            Pack pack = Pack.singleton;
            List<Card> cards = pack.pack.GetRange(0, amount);
            pack.pack.RemoveRange(0, amount);
            cards.ForEach(pack.pack.Add);
            Console.WriteLine("-- Dealt " + amount.ToString() + " cards. --");
            return cards;
        }
    }
}
