using System;
using System.Collections.Generic;

namespace CMP1903M_A01_2223
{
    // 'Additional classes to those provided by the base code are implemented – point out with comments'
	// Point ^
    public static class Testing
	{

		//Runs the spec specified testing requirements. (Additional Method)
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

		//Runs a continuous loop for user testing. (Additional Method)
		public static void menu() {
			bool running = true;

			//Keep running until exit choice is selected.
			while(running) {
				int? option = null;
				while(option == null) {
					Testing.displayMenu();
					string inp = Console.ReadLine();
					if(inp == null) {
						//Visual Studio on mac doesn't let me input, note null input is different to blank input.
						//Null means it cannot read input.
						Console.WriteLine("Input is not being received, cannot run testing menu.");
						return;
					}
					try {
						option = int.Parse(inp);
					} catch(Exception) {
                        //Other exceptions can arise eg Format and Overflow when massive ints are entered.
                        Console.WriteLine("Input must be in the range 1-7 inclusive.");
                        option = null;
                    }
					//Make sure option is valid 1-7
					if(option != null && (option > 7 || option < 1)) {
						Console.WriteLine("Input must be in the range 1-7 inclusive.");
                        option = null;
                    }
				}

				switch(option) {
					case 1:
						Pack.resetPack();
						Console.WriteLine("Pack reset to default unshuffled state.");
						break;

					case 2:
						Pack.shuffleCardPack(1);
						Console.WriteLine("Pack shuffled with 'Fisher-Yates'.");
						break;

					case 3:
						Pack.shuffleCardPack(2);
						Console.WriteLine("Pack shuffled with 'Riffle'.");
						break;

					case 4:
						Pack.shuffleCardPack(3);
						Console.WriteLine("Pack shuffled with 'No Shuffle'.");
						break;

					case 5:
						Console.WriteLine("Dealing one card:\n" + Pack.deal().ToString());
						break;

					case 6:
						//Get amount of cards to deal from user (1-52 inclusive)
						int? amount = null;
						while(amount == null) {
							Console.WriteLine("How many cards to deal? (1-52): ");
							string inp = Console.ReadLine();
							try {
								amount = int.Parse(inp);
							} catch(Exception) {
                                //Other exceptions can arise eg Format and Overflow when massive ints are entered.
                                Console.WriteLine("Input must be a number in the range 1-52 inclusive.");
                                option = null;
                            }
                            if(amount != null && (amount < 1 || amount > 52)){
								Console.WriteLine("Input must be in the range 1-52 inclusive.");
								amount = null;
							}
						}
						Console.WriteLine("Dealing '" + amount.ToString() + "' cards:");
						//Can safely cast here as it will never be null due to while loop above.
						List<Card> cards = Pack.dealCard((int)amount);
						cards.ForEach(card => { Console.WriteLine(card.ToString()); });
						break;

					case 7:
						Console.WriteLine("Stopping...");
						running = false;
						break;

					default:
						Console.WriteLine("Error, Option should be in the range 1-7 inclusive.");
						break;
				}
			}
		}

		//(Additional Method)
		private static void displayMenu() {
			Console.WriteLine("\n-- Testing Menu --");
			Console.WriteLine(
				"1 - Reset Card Pack\n" +
				"2 - Shuffle n.1, Fisher-Yates\n" +
				"3 - Shuffle n.2, Riffle\n" +
				"4 - Shuffle n.3, No Shuffle\n" +
				"5 - Deal one card\n" +
				"6 - Deal multiple cards\n" +
				"7 - Exit\n\n" +
				"Please enter the respective number 1-7:"
			);
        }
	}
}

