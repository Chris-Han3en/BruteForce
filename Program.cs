using System;
using System.Diagnostics;
using System.IO;

namespace Brute_Force_Attacker {
    class Program {
        public char firstchar = '!';
        public char lastchar = '~';
        public int passwordLength = 8;
        public long tries = 0;
        public bool done = false;
        public string password = "hey";

        // Function for brute forcing
        public void CreatePasswords(string keys) {
            if (keys == password) { // Check if the password is a match
                done = true;
            }
            
            if (keys.Length > passwordLength || done == true) {
                // This occurs if the user put in invalid characters or when it found a match
                return;
            }

            // Recursively create passwords
            for (char c = firstchar; c <= lastchar; c++) {
                tries++;
                CreatePasswords(keys + c);
            }
        }

        static void Main(string[] args) {
            Program program = new Program();
            Console.WriteLine("This program was created by Chris Hansen.");
            Console.WriteLine("\n\n----------------------------------------------------------------------------------------------");

            Console.Write("\nPlease enter your password > ");
            program.password = Convert.ToString(Console.ReadLine());
            program.passwordLength = program.password.Length;
            
            Console.WriteLine("\nCracking your password...");

            Stopwatch timer = Stopwatch.StartNew();
            
            // Brute force the password
            program.CreatePasswords(string.Empty);

            timer.Stop();

            long elapsedMs = timer.ElapsedMilliseconds;
            double elapsedTime = elapsedMs / 1000;

            if (elapsedTime > 0) {
                Console.WriteLine("\n\nYour password has been found! Here are the statistics:");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Password: {0}", program.password);
                Console.WriteLine("Password length: {0}", program.passwordLength);
                Console.WriteLine("Tries: {0}", program.tries);
                string plural = "seconds";
                if (elapsedTime == 1) {
                    plural = "second";
                }
                Console.WriteLine("Time to crack: {0} {1}", elapsedTime, plural);
                Console.WriteLine("Passwords per second: {0}", (long)(program.tries / elapsedTime));
            }
            else {
                Console.WriteLine("\n\nYour password has been found! Here are the statistics:");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Password: {0}", program.password);
                Console.WriteLine("Password length: {0}", program.passwordLength);
                Console.WriteLine("Tries: {0}", program.tries);
                Console.WriteLine("Time to crack: {0} seconds", elapsedTime);
            }

            Console.Write("\n\nPress any key to close");
            Console.ReadKey();
        }
    }
}
