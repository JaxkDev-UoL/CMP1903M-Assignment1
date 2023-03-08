using System;

namespace CMP1903M_A01_2223
{
	public static class Testing
	{
		public static void demo() {
			/*
			 * class Testing which:
				o	Creates a Pack object
				o	Calls the shuffleCardPack method with the different shuffle types
				o	Calls the deal methods
				o	Check what is returned
			 */
			Console.WriteLine("> Test demonstration:\n");
			Pack.resetPack();
			Pack.shuffleCardPack(1);
			Pack.shuffleCardPack(2);
			Pack.shuffleCardPack(3);
			Console.WriteLine(Pack.deal().ToString());
			Pack.dealCard(20).ForEach(card => Console.WriteLine(card.ToString()));
			Console.WriteLine("\n> End of test demonstration.\n");
		}

		public static void menu() {
			Pack.resetPack();
		}
	}
}

