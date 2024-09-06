namespace NumbersGame;

class Program
{
    static void Main(string[] args)
    {
        bool isRunning = true;
        
        while (isRunning)
        {
            Console.WriteLine("\nVälkommen till mitt gissningsspel. Klarar du av att gissa rätt nummer?");
            Console.WriteLine("\nBörja med att välja svårighetsgrad:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Lätt 1-10 5 försök");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("2. Medel 1-20 4 försök");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("3. Svår 1-50 3 försök");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("4. Avsluta");
            Console.ResetColor();

            string input = Console.ReadLine();

            int maxNumbers = 0;
            int maxAttempts = 0;
            
            switch (input)
            {
                case "1": // easy
                    maxNumbers = 10;
                    maxAttempts = 5;
                    PlayGame(maxNumbers, maxAttempts);
                    break;
                case "2": // medium
                    maxNumbers = 20;
                    maxAttempts = 4;
                    PlayGame(maxNumbers, maxAttempts);
                    break;
                case "3": // hard
                    maxNumbers = 50;
                    maxAttempts = 3;
                    PlayGame(maxNumbers, maxAttempts);
                    break;
                case "4": // quit
                    Console.WriteLine("Tack för att du spelade!");
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Ogiltligt val, försök igen.");
                    break;
            }
        }

        static void PlayGame(int maxNumbers, int maxAttempts)
        {
            Random random = new Random();
            int secretNumber = random.Next(1, maxNumbers + 1);
            int attempts = 0;

            Console.WriteLine($"Välkommen jag tänker på ett nummer kan du gissa vilket? \nDu har {maxAttempts} försök:");

            while (attempts < 5)
            {
                int guess = int.Parse(Console.ReadLine());
                attempts++;
                if (guessCheck(guess, secretNumber))
                {
                    Console.WriteLine($"Grattis du har gissat korrekt! Du lyckades på {attempts} försök.");
                    return;
                }
                else if (guess < secretNumber)
                {
                    Console.WriteLine("Fel, Nummret jag tänker på är större. Försök igen.");
                }
                else
                {
                    Console.WriteLine("Fel, Numret jag tänker på är mindre. Försök igen.");
                }
            }
            Console.WriteLine($"\nDu har använt alla dina gissningar. Numret jag tänkte på var {secretNumber}. Bättre lycka nästa gång!");
        }
    }

    static bool guessCheck(int guess, int secretNumber) // metod för att kontrollera om gissningen är korrekt
    {
        return guess == secretNumber;
    }
}