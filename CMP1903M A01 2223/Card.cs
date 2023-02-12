using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        //Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
        //The 'set' methods for these properties could have some validation
        public int Value { get; private set; }
        public int Suit { get; private set; }

        public Card(int Value, int Suit) {
            if(Value > 13 || Value < 1) {
                throw new ArgumentOutOfRangeException("Value", "Value must be in the range 1-13 inclusive.");
            }
            if(Suit > 4 || Suit < 1) {
                throw new ArgumentOutOfRangeException("Suit", "Suit must be in the range 1-4 inclusive.");
            }
            this.Value = Value;
            this.Suit = Suit;
        }

        public override string ToString() {
            return "Suit: " + this.Suit + ", Value: " + this.Value;
        }
    }
}
