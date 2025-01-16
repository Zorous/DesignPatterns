using System;

namespace RockPaperScissors_NoDI
{
    public enum Choice
    {
        Rock,
        Paper,
        Scissors
    }

    public class GameManager
    {
        // Random instance for generating computer choices
        private Random _rand = new Random();

        public void PlayGame()
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors!");

            while (true)
            {
                // Prompt user for their choice
                Console.WriteLine("Enter a choice: (R) for Rock, (P) for Paper, (S) for Scissors:");
                string input = Console.ReadLine()?.ToUpper();

                // Allow user to quit
                if (input == "Q")
                {
                    Console.WriteLine("Thanks for playing!");
                    break;
                }

                // Parse user input into a Choice enum
                if (!TryParseChoice(input, out Choice playerChoice))
                {
                    Console.WriteLine("Invalid choice, try again.");
                    continue;
                }

                // Generate computer's choice
                Choice computerChoice = GetComputerChoice();
                Console.WriteLine($"Computer chose: {computerChoice}");

                // Determine the winner and display the result
                var result = DetermineWinner(playerChoice, computerChoice);
                Console.WriteLine($"Result: {result}");
            }
        }

        private Choice GetComputerChoice()
        {
            // Randomly generate a computer choice (0=Rock, 1=Paper, 2=Scissors)
            return (Choice)_rand.Next(3);
        }

        private string DetermineWinner(Choice player, Choice computer)
        {
            // Determine the game result based on rules
            if (player == computer) return "It's a tie!";
            if ((player == Choice.Rock && computer == Choice.Scissors) ||
                (player == Choice.Paper && computer == Choice.Rock) ||
                (player == Choice.Scissors && computer == Choice.Paper))
                return "You win!";
            return "You lose!";
        }

        private bool TryParseChoice(string input, out Choice choice)
        {
            // Map user input (R, P, S) to the corresponding Choice enum
            choice = input switch
            {
                "R" => Choice.Rock,
                "P" => Choice.Paper,
                "S" => Choice.Scissors,
                _ => (Choice)(-1)
            };
            return choice != (Choice)(-1);
        }
    }

    /*class Program
    {
        static void Main(string[] args)
        {
            // Initialize the game and start it
            var game = new GameManager();
            game.PlayGame();
        }
    }*/
}
