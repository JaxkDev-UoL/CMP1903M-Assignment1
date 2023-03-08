using System;

namespace CMP1903M_A01_2223
{
    class Program
    {
        static void Main(string[] args) {

            try {
                Testing.demo();
            }catch(ValueException exception) {
                Console.WriteLine("Failed to run demonstration, details: " + exception.Message);
            }catch(Exception exception) {
                Console.WriteLine("Failed to run test demo, unknown error has occured - " + exception.Message);
            }

            //NOTE THIS WILL NOT WORK IN VISUAL STUDIO IDE RUN/DEBUG RUN, INPUT IS NOT ALLOWED.
            //(At least not on my mac, had to directly execute the built .exe with mono via cli)
            Testing.menu();
        }
    }
}
