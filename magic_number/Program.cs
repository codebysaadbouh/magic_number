using System;

namespace magic_number
{
    class Program
    {

        static int giveMeMagicNumber(int min, int max)
        {
            Random rand = new Random(); 
            int magic_number = rand.Next(min, max+1);

            return magic_number; 
        }

        static int  demanderNombre(int min, int max)
        {
            string number_str = "";
            int number_int = min - 1;

            while((number_int < min) || (number_int > max))
            {
                Console.WriteLine($"Rentrez un nombre entre {min} et {max} : "); 
                number_str = Console.ReadLine();

                try
                {
                    number_int = int.Parse(number_str);

                    bool intervalle = (number_int < min) || (number_int > max);

                    if (intervalle)
                    {
                        Console.WriteLine($"Le nombre doit être compris {min} entre  et {max} !");
                        number_int = 0;
                        Console.WriteLine();
                    }
                }
                catch
                {
                    Console.WriteLine(); 
                    Console.WriteLine("ERREUR : Rentrez un nombre valide !");
                    Console.WriteLine(); 
                }
            }

            return number_int; 
        }

        static void gamePlay(int LIFE_NUMBERS, int user_number, int magic_number,  int NOMBRE_MIN,  int NOMBRE_MAX)
        {
            while (LIFE_NUMBERS > 0) // OR for(int i = 1; i >= LIFE_NUMBERS; i++) { } OR for(int life_number = 5; life_number > 0; life_number--){}
            {
                Console.WriteLine($"Nombre de chance : {LIFE_NUMBERS}");
                user_number = demanderNombre(NOMBRE_MIN, NOMBRE_MAX);
                Console.WriteLine();
                if (user_number > magic_number)
                {
                    Console.WriteLine($"Attention {user_number} est PLUS GRAND que le nombre magic !");
                    // LIFE_NUMBERS--;
                }
                else if (user_number < magic_number)
                {
                    Console.WriteLine($"Attention {user_number} est PLUS PETIT que le nombre magic !");
                    // LIFE_NUMBERS--;
                }
                else
                {
                    Console.WriteLine($"BRAVO ! Vous avez trouvé le nombre magic !");
                    break;  // If we find the magic number we should stop the loop like this and move on to the next conclusion!
                }
                LIFE_NUMBERS--; // We will decrement in both cases!
            }
            if (LIFE_NUMBERS == 0)
            {
                Console.WriteLine("NULLLLLLLL ! Pas de chance");
                Console.WriteLine($"C'etait {magic_number} le nombre magique :-)");
            }
        }



        // Execute the program
        static void Main(string[] args)
        {
            // Define the interval
            const int NOMBRE_MIN = 1;
            const int NOMBRE_MAX = 40;

            // Randomly generate a number
            int magic_number = giveMeMagicNumber(NOMBRE_MIN, NOMBRE_MAX);

            int user_number = magic_number + 1;

            // Define the number of chances
            int LIFE_NUMBERS = 6;

            // Let's start to game
            gamePlay(LIFE_NUMBERS, user_number, magic_number, NOMBRE_MIN, NOMBRE_MAX); 
        }
    }
}
