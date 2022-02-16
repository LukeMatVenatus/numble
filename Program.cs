using System;
using Pastel;

namespace NumberWordle
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            bool playing = true;
            int difficulty = 4; // If difficulty is 4, the game will use a 4 digit number etc.
            while (playing)
            {
                Console.WriteLine("Welcome to Number Wordle!");
                // Generate random number
                // Console.WriteLine(Convert.ToInt32(Math.Pow(10.0, difficulty)) - 1);
                string randomNumber = Convert.ToString(new Random().Next(Convert.ToInt32(Math.Pow(10.0, difficulty - 1)), Convert.ToInt32(Math.Pow(10.0, difficulty)) - 1));
                Console.Title = "The answer is definitely not " + randomNumber;
                // Take input as guess and sanitise
                Console.WriteLine("Please enter your guess:");

                int guesses = 0;
                int correct = 0, exact = 0;
                while (exact != difficulty)
                {
                    string guess = "";
                    while (guess == "")
                    {
                        try
                        {
                            guess = Console.ReadLine();
                            int.Parse(guess); // Make sure guess is numbers only
                            if (guess.Length != difficulty) throw new Exception(); // Make sure guess is only 4 characters, no more no less
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Incorrect format, please enter again:");
                            guess = "";
                        }
                    }
                    
                    for (int i = 0; i < difficulty; i++)
                    {
                        if (guess[i] == randomNumber[i]) exact ++; // Checks if number is in correct position
                        else if (randomNumber.Contains(Convert.ToString(guess[i]))) correct ++; // Checks if number is used
                    }
                    if (exact != difficulty)
                    {
                        Console.WriteLine("You had {0} correct numbers in the wrong position, and {1} in the correct position", colouredNumber(correct), colouredNumber(exact));
                        Console.WriteLine("Try again:");
                        correct = 0;
                        exact = 0;
                    }
                    guesses++;
                }
                Console.WriteLine("Correct! It took you {0} guess{1}!", colouredNumber(guesses), (guesses != 1 ? "es" : ""));
                string playAgain = "";
                Console.WriteLine("Would you like to play again?");
                while (playAgain == "")
                {

                    try
                    {
                        playAgain = Console.ReadLine();
                        if (playAgain.ToLower() != "yes" && playAgain.ToLower() != "no") throw new Exception();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Invalid response. Please responding with yes or no.");
                        playAgain = "";
                    }
                }
                if (playAgain.ToLower() == "no") playing = false;
            }

            Console.WriteLine("Hope you had fun!");

        }

        static string colouredNumber(int number)
        {
            if (number == 0) return number.ToString().Pastel("#ff3333");
            if (number > 0) return number.ToString().Pastel("#33ff33");

            return "";
        }
    }
}