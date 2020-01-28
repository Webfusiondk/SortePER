using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePER
{
    class Program
    {
        static List<Player> players = new List<Player>()
        {
        };

        static Game game = new Game();
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Sorteper");
                Console.WriteLine("If you would like to add players to the game type P " + "\n" +
                                  "IF you would like to see current players type c" + "\n" +
                                  "If you would like to start the game type S");
                string userinput;
                switch (userinput = Console.ReadLine().ToLower())
                {
                    case "p":
                        Console.Clear();
                        AddMorePlayers();
                        break;
                    case "c":
                        Console.Clear();
                        CurrentPlayers();
                        break;
                    case "s":
                        Console.Clear();
                        StartGame();
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        Console.Clear();
                        Menu();
                        break;
                }
            }
        }

        public static void StartGame()
        {
            game.AmountOfPlayers(players);
            game.AddCardsToList();
            game.ShuffelCards();
            game.GiveCardsToPlayers();
            Console.WriteLine(game.CheckForPariAfterCardDeal());
            LoopAllPlayers();

        }

        public static void CurrentPlayers()
        {
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine(players[i].Name);
            }
            Console.ReadKey(true);
        }

        public static void AddMorePlayers()
        {
            int i = 0;
            while (true)
            {
                Console.WriteLine("Would you like to add player or computer" + "\n" + "Type p for player" + "\n" + "Type c for computer" + "\n" + "Type b to get back to menu");
                string userinput;
                switch (userinput = Console.ReadLine().ToLower())
                {
                    case "p":
                        Console.Clear();
                        Console.WriteLine("Insert name: ");
                        userinput = Console.ReadLine();
                        players.Add(new Human(userinput));
                        break;

                    case "c":
                        Console.Clear();
                        players.Add(new Computer("Computer" + i));
                        Console.WriteLine("Computer addet");
                        i++;
                        break;

                    case "b":
                        Console.Clear();
                        Menu();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong input");
                        AddMorePlayers();
                        break;
                }
            }
        }

        public static void LoopAllPlayers()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int nextPlayer = 1;
            bool isDone = false;
            while (isDone == false)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    if (nextPlayer == players.Count)
                    {
                        nextPlayer = 0;
                    }
                    if (players[i].GetType() == typeof(Human))
                    {
                        Console.WriteLine("Take card from 1 to " + players[nextPlayer].Hand.Count);
                        int userinput = Convert.ToInt32(Console.ReadLine());
                        game.TakeCardFromPlayer(players[i], players[nextPlayer], userinput);
                    }
                    else
                        game.TakeCardFromPlayer(players[i], players[nextPlayer], r.Next(0, players[nextPlayer].Hand.Count - 1));


                    string temp = game.CheckForPari(players[i]);

                    if (string.IsNullOrEmpty(temp))
                        Console.WriteLine(players[i].Name + " Has no match");
                    else
                        Console.WriteLine(temp);
                    if (game.Win(players) == true)
                    {
                        isDone = true;
                        Console.WriteLine("Loser " + players[0].Name);
                        Console.ReadKey();
                    }
                }
            }

            nextPlayer++;

        }
    }
}
