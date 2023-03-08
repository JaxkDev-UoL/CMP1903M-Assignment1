using System;

namespace CMP1903M_A01_2223
{
    class Program
    {
        static void Main(string[] args) {

            try {
                Testing.demo();
            }catch(ValueException) {
                Console.WriteLine("Unhandled card/pack error has occured.");
                //Exception will be printed below.
            }catch(Exception exception) {
                Console.WriteLine("Failed to run test demo, error has occured - " + exception.Message);
            }

            Testing.menu();
        }
    }
}
