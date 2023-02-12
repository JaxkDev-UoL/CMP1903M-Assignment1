using System;

namespace CMP1903M_A01_2223
{
    class Program
    {
        static void Main(string[] args)
        {
            new Pack();
            Pack.shuffleCardPack(1);
            Pack.dealCard(52).ForEach(card => Console.WriteLine(card.ToString()));
        }
    }
}
