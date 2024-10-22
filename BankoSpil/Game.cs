using System;

namespace BankoGame
{
    public class Game
    {
        private BankoCard playerCard;

        public void start()
        {
            // get player name 
            Console.WriteLine("Enter your name:");
            string playerName = Console.ReadLine();

            //Create Card for  player
            playerCard = new BankoCard(playerName);

            // show initial Card
            playerCard.ShowCard();

            // Main game loop
            while (true)
            {
                Console.WriteLine("\nEnter Number between (1-90) or 'q' to quit ");
                string input = Console.ReadLine();

                // Check if the player want to quit

                if (input.ToLower() == "q")
                {
                    break;
                }
                
                // Try to conver input to number
                if (int.TryParse(input, out int number ))
                {
                    // Check if number is valid (1-90)
                    if (number >= 1 && number <= 90)
                    {
                        // Try to mark the number
                        if (playerCard.MarkNumber(number))
                        {
                            Console.WriteLine("Found Number and Mark");
                        }

                        else
                        {
                            Console.WriteLine(" Number not found on your Card");
                        }

                        // Show updated card 
                        playerCard.ShowCard();

                        if (CheckWin())
                        {
                            Console.WriteLine("Congratulations You've won!");
                            break;
                        }

                       
                    }
                    else
                    {
                        Console.WriteLine("Please Enter a number between 1-90.");
                    }
                   
                }

                else
                {
                    Console.WriteLine("Invalid input please enter a number or 'q'.");
                }
            }


        }

        private bool CheckWin()
        {
            for (int row = 0; row < 3; row++)
            {
                bool rowComplete = true;
                for (int col = 0; col < 9; col++)
                {
                    if (playerCard.Numbers[row, col] !=0)
                    {
                        rowComplete = false;
                        break;
                    }
                }

                if (rowComplete) return true;
            }

            return false;
        }

    }
}
