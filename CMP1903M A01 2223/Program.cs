using System;

namespace CMP1903M_A01_2223
{
    class Program
    {
        static void Main(string[] args)
        {
            new Pack();
            for(int i = 0; i < 5; i++) Pack.shuffleCardPack(2);
            
            Pack.dealCard(52).ForEach(card => Console.WriteLine(card.ToString()));
        }
    }
}
