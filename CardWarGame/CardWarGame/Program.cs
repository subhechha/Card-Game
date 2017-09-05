using System;

class War
{
    static int[] carddeck = new int[52]; 
    static int cardIndex = 0;
    static string[] cards = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
    static string[] suits = { "clubs", "diamonds", "hearts", "spades" };
    static Random rand = new Random();

    static void Main()
    {
        int computerScore = 0; 
        int playerScore = 0;

        FillCards();
 
        for (int i = 0; i < 26; i++)
        {
            string computerSuit;
            int computer = ChooseCard(out computerSuit) - 1;
            string playerSuit;
            int player = ChooseCard(out playerSuit) - 1;

            if (computer > player)
            {
                computerScore += 2;
            }
            else if (computer < player)
            {
                playerScore += 2;
            }
            else
            {
                computerScore += 1;
                playerScore += 1;
            }

            Console.WriteLine("Round # {0}", i + 1);
            Console.WriteLine("Computer has {0} of {1}", cards[computer], computerSuit);
            Console.WriteLine("Player has {0} of {1}", cards[player], playerSuit);
            Console.WriteLine("Computer Score: {0}", computerScore);
            Console.WriteLine("Player Score: {0}", playerScore);
            Console.WriteLine();
            Console.ReadKey();
        }
        if(computerScore>playerScore)
            Console.WriteLine("Computer has the score {0}. THE WINNER!!", computerScore);
        else
            Console.WriteLine("Player has the score {0}. THE WINNER!!", playerScore);
        Console.ReadKey();
    }

    static void FillCards()
    {
        for (int i = 0; i < 52; i++)
        {
            while (true)
            {
                int num = rand.Next(1, 53);
                if (Array.IndexOf(carddeck, num) == -1)
                {
                    carddeck[i] = num;
                    break;
                }
            }
        }
    }

    static int ChooseCard(out string suit)
    {
        int num = carddeck[cardIndex];
        cardIndex++;
        suit = suits[(num - 1) % 4];
        return (num - 1) / 4 + 1;
    }
}