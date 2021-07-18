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


        static void Main(string[] args)
        {
            const int NOMBRE_MIN = 1;
            const int NOMBRE_MAX = 10;

            int magic_number = giveMeMagicNumber(NOMBRE_MIN, NOMBRE_MAX);

            int user_number = magic_number + 1;

            int LIFE_NUMBERS = 5;
            
            while (LIFE_NUMBERS > 0) // OU for(int i = 1; i >= LIFE_NUMBERS; i++) { } OU for(int life_number = 5; life_number > 0; life_number--){}
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
                    break;  // Si nous trouvons le nombre magique il faut arrêter la boucle ainsi et passer à la conclusion suivante !
                }
                LIFE_NUMBERS--; // Nous allons decrementer danas les deux cas !
            }
                
            if (LIFE_NUMBERS == 0)
            {
                Console.WriteLine("NULLLLLLLL ! Pas de chance");
                Console.WriteLine($"C'etait {magic_number} le nombre magique :-)");
            }
        }
    }
}
