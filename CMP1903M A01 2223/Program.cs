using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Program
    {
        static void Main(string[] args)
        {
            new Pack();
            Card c = Pack.deal();
            Console.WriteLine(c.ToString());
            List<Card> cards = Pack.dealCard(20);
            cards.ForEach(card => Console.WriteLine(card.ToString()));
            cards = Pack.dealCard(40);
            cards.ForEach(card => Console.WriteLine(card.ToString()));
        }
    }
}
