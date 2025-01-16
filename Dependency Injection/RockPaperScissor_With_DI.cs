using System;

namespace RockPaperScissors_DI
{
    public enum Choice
    {
        Rock,
        Paper,
        Scissors
    }

    // Interface for handling player input
    public interface IPlayerInput
    {
        Choice GetPlayerChoice();
    }

    // Interface for generating the computer's choice
    public interface IComputerChoiceGenerator
    {
        Choice GetComputerChoice();
    }

    // Implementation of IPlayerInput using the console for user input
    public class ConsolePlayerInput : IPlayerInput
    {
        public Choice GetPlayerChoice()
        {
            while (true)
            {
                Console.WriteLine("Enter a choice: (R) for Rock, (P) for Paper, (S) for Scissors:");
                string input = Console.ReadLine()?.ToUpper();

                // Parse the input into a Choice enum
                if (TryParseChoice(input, out Choice choice))
                    return choice;

                Console.WriteLine("Invalid choice, try again.");
            }
        }

        private bool TryParseChoice(string input, out Choice choice)
        {
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

    // Implementation of IComputerChoiceGenerator using random choices
    public class RandomComputerChoiceGenerator : IComputerChoiceGenerator
    {
        private readonly Random _rand = new Random();

        public Choice GetComputerChoice()
        {
            return (Choice)_rand.Next(3);
        }
    }

    // GameManager uses dependency injection for its dependencies
    public class GameManager
    {
        private readonly IPlayerInput _playerInput;
        private readonly IComputerChoiceGenerator _computerChoiceGenerator;

        public GameManager(IPlayerInput playerInput, IComputerChoiceGenerator computerChoiceGenerator)
        {
            _playerInput = playerInput; // Injected player input dependency
            _computerChoiceGenerator = computerChoiceGenerator; // Injected computer choice dependency
        }

        public void PlayGame()
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors!");

            while (true)
            {
                // Get player and computer choices from the injected dependencies
                var playerChoice = _playerInput.GetPlayerChoice();
                var computerChoice = _computerChoiceGenerator.GetComputerChoice();

                Console.WriteLine($"You chose: {playerChoice}");
                Console.WriteLine($"Computer chose: {computerChoice}");

                // Determine the winner and display the result
                var result = DetermineWinner(playerChoice, computerChoice);
                Console.WriteLine($"Result: {result}");
            }
        }

        private string DetermineWinner(Choice player, Choice computer)
        {
            if (player == computer) return "It's a tie!";
            if ((player == Choice.Rock && computer == Choice.Scissors) ||
                (player == Choice.Paper && computer == Choice.Rock) ||
                (player == Choice.Scissors && computer == Choice.Paper))
                return "You win!";
            return "You lose!";
        }
    }


}
