namespace NumbersGame;

class Program
{
    static void Main(string[] args)
    {
        bool isRunning = true; // create a bool to keep the game running
        
        while (isRunning) // loop to keep the meny running
        {
            DisplayMenu(); // call the DisplayMenu method

            string input = Console.ReadLine(); // user input for difficulty level

            int maxNumbers = 0; // Declare the variable to store the max guess, will be assigned a value in the switch case depending on difficulty level
            int maxAttempts = 0; // Declare the variable to store the allowed number of attempts, will be assigned a value in the switch case depending on difficulty level
            
            switch (input)
            {
                case "1": // easy
                    maxNumbers = 10; // set maxnumbers to 10 for easy mode
                    maxAttempts = 5; // set maxattempts to 5 for easy mode
                    PlayGame(maxNumbers, maxAttempts); // call the PlayGame method
                    break;
                case "2": // medium
                    maxNumbers = 20; // set maxnumbers to 20 for medium mode
                    maxAttempts = 4; // set maxattempts to 4 for medium mode
                    PlayGame(maxNumbers, maxAttempts); // call the PlayGame method
                    break;
                case "3": // hard
                    maxNumbers = 50; // set maxnumbers to 50 for hard mode
                    maxAttempts = 3; // set maxattempts to 3 for hard mode
                    PlayGame(maxNumbers, maxAttempts); // call the PlayGame method
                    break;
                case "4": // quit
                    Console.WriteLine("Tack för att du spelade!"); // thank you message
                    isRunning = false; // set isRunning to false to exit the loop
                    break;
                default:
                    Console.WriteLine("Ogiltligt val måste vara en siffra, försök igen."); // invalid input message instead of a crash
                    break;
            }
        } 
        
        // My methods for the game
        static void DisplayMenu() // method to display the menu
        {
            // welcome message and difficulty level selection
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
        }
        
        static void PlayGame(int maxNumbers, int maxAttempts) // The game logic is created in my method PlayGame
        {
            Random random = new Random(); // create a new random object
            int secretNumber = random.Next(1, maxNumbers + 1); // generate a random number between 1 and maxNumbers
            int attempts = 0;

            Console.WriteLine($"Välkommen jag tänker på ett nummer kan du gissa vilket? \nDu har {maxAttempts} försök:");

            while (attempts < maxAttempts) // loop for the amount of maxAttempts
            {
                if (!int.TryParse(Console.ReadLine(), out int guess)) // check if the input is a number
                {
                    Console.WriteLine("Ogiltlig inmatning måste vara ett nummer, försök igen."); // invalid input message must be a number
                    continue; // continue to the next iteration of the loop
                }
                attempts++; // increment attempts after each guess
                
                if (guessCheck(guess, secretNumber)) // call the guessCheck method to check if the guess is correct
                {
                    Console.WriteLine($"Grattis du har gissat korrekt! Du lyckades på {attempts} försök.");
                    return;
                }
                else if (guess < secretNumber) // if the guess is lower than the secret number
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
    
    static bool guessCheck(int guess, int secretNumber) // method to check if the guess is correct
    {
        return guess == secretNumber; // return true if the guess is correct
    }
}