using System;

namespace CMP1903M_A01_2223
{
	public static class Testing
	{
		public static void run() {
			/*
			 * class Testing which:
				o	Creates a Pack object
				o	Calls the shuffleCardPack method with the different shuffle types
				o	Calls the deal methods
				o	Check what is returned
			 */
			new Pack();
			Pack.shuffleCardPack(1);
			Pack.shuffleCardPack(2);
			Pack.shuffleCardPack(3);
			Console.WriteLine("-- Deal Single --");
			Console.WriteLine(Pack.deal().ToString());
			Console.WriteLine("-- Deal Multiple --");
			Pack.dealCard(20).ForEach(card => Console.WriteLine(card.ToString()));
		}
	}
}

