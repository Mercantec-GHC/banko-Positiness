using System;
using System.ComponentModel.DataAnnotations;

namespace BankoGame
{
    public class BankoCard
    {
        // Store the player's name and card numbers
        public string PlayerName { get; private set; }
        public int[,] Numbers { get; private set; }

        // Constructor That takes the player name and numbers
        public BankoCard (string playerName)
        {
            PlayerName = playerName;

            Numbers = new int[3, 9];
            CreateCard();

        }
        // Create the Card with Random Numbers between 1-90
        public void CreateCard()
        {
            Random random = new Random();
            // fill each colomn
            for (int col =  0; col <9; col ++)
            {
                int min = (col * 10) + 1;// 1,11, 21...
                int max = (col == 8) ? 90 : (col + 1 ) * 10;// 10, 20, 30....90


                // Fill each row int curent colomn
                for (int row = 0; row < 3; row++)
                {
                    Numbers [row, col] = random.Next(min, max + 1);
                }
            }

        }

        // Show Card on the Screen
        public void ShowCard()
        {
            Console.WriteLine($"\nCard for Player: {PlayerName}");
            Console.WriteLine("----------------------");

            for (int row = 0; row < 3; row++)
            { 
                for (int col = 0; col < 9; col++)
                {
                    if (Numbers[row, col ] == 0)
                    {
                        Console.Write("XX"); // Marked Number
                    }
                    else
                    {
                        Console.Write($"{Numbers[row, col]:D2}"); // regular numbers
                    }
                }

                Console.WriteLine();
            }
        }

        //

        public bool MarkNumber(int number)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (Numbers[row, col] == number)
                    {
                        Numbers[row, col] = 0; // Mark as found
                        return true;
                    }
                }
            }
            return false;
        }


    }
}




