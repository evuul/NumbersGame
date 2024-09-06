namespace NumbersGame;

class Program
{
    static void Main(string[] args)
    {
        Random random =  new Random();
        int secretNumber = random.Next(1, 20);
        int attempts = 0;
        bool isRunning = true;
        
        Console.WriteLine("Välkommen jag tänker på ett nummer kan du gissa vilket? \nDu får fem försök:");
        
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

    static bool guessCheck(int guess, int secretNumber) // metod för att kontrollera om gissningen är korrekt
    {
        return guess == secretNumber;
    }
}