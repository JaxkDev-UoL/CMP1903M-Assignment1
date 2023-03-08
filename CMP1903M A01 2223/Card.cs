using System;

namespace CMP1903M_A01_2223
{
    class Card
    {
        //Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
        //Encapsulated true private value and suit with getters and setters.

        private int _Value;
        public int Value {
            get {
                return _Value;
            }
            set {
                if(value > 13 || value < 1) {
                    throw new ValueException(value, "Value must be in the range 1-13 inclusive.");
                }
                _Value = value;
            }
        }

        private int _Suit;
        public int Suit {
            get {
                //Abstraction, we don't use names anywhere only a number represena
                return _Suit;
            }
            set {
                if(value > 4 || value < 1) {
                    throw new ValueException(value, "Must be in the range 1-4 inclusive.");
                }
                _Suit = value;
            }
        }

        public Card(int Value, int Suit) {
            this.Value = Value;
            this.Suit = Suit;
        }

        public override string ToString() {
            return "Suit: " + this.Suit + ", Value: " + this.Value;
        }
    }
}
