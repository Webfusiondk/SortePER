using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePER
{
    class Game
    {
        List<Player> players;
        public List<Card> cards = new List<Card>();
        public void AddCardsToList()
        {
            int cardID = 0;
            bool SortPerExists = false;
            foreach (CardValue cardValue in Enum.GetValues(typeof(CardValue)))
            {
                for (int i = 0; i < 2; i++)
                {
                    if (SortPerExists == false)
                    {
                        if (cardValue == CardValue.SortePer)
                        {
                            SortPerExists = true;
                            cards.Add(new Card(cardValue.ToString(), CardValue.SortePer, cardID));
                        }
                        else
                        cards.Add(new Card(cardValue.ToString(), cardValue, cardID));
                    }
                cardID++;
                }
            }
        }

        public void ShuffelCards()
        {
            //Shuffling the list of cards with the Fisher-Yates method.
            Random r = new Random(DateTime.Now.Millisecond);
            for (int n = cards.Count - 1; n > 0; --n)
            {
                //Random picks a card that has not been suffeld
                int k = r.Next(n + 1);

                //Swap the selected card with the last "Unselected" Card in the list
                Card temp = cards[n];
                cards[n] = cards[k];
                cards[k] = temp;
            }
            
        }

        public void AmountOfPlayers(List<Player> players)
        {
            this.players = players;
        }

        public void AddNewPlayer(Player player)
        {
            players.Add(player);
        }

        public string CheckForPariAfterCardDeal()
        {
            string temp = "";
            foreach (Player player in players)
            {
                foreach (Card card in player.Hand.ToList())
                {
                    foreach (Card cards in player.Hand.ToList())
                    {
                        if (card.CardValue == cards.CardValue && card.Id != cards.Id)
                        {
                            temp += "Pair of " + cards.CardName + " Was removed from the game\n";
                            player.Hand.Remove(card);
                            player.Hand.Remove(cards);
                        }
                    }
                }
            }
            return temp;

        }

        public string CheckForPari(Player curentPlayer)
        {
            string temp = "";
            foreach (Card card in curentPlayer.Hand.ToList())
            {
                foreach (Card cards in curentPlayer.Hand.ToList())
                {
                    if (card.CardValue == cards.CardValue && card.Id != cards.Id)
                    {
                        temp += "Pair of " + card.CardName + " Was removed from the game";
                        curentPlayer.Hand.Remove(card);
                        curentPlayer.Hand.Remove(cards);

                    }
                }
            }
                return temp;
        }

        public bool Win(List<Player> playersList)
        {
            for (int i = 0; i < playersList.Count; i++)
            {
                if (playersList[i].Hand.Count == 0)
                    playersList.Remove(playersList[i]);
            }

            if (playersList.Count == 1)
                return true;
            return false;
        }

        public void GiveCardsToPlayers()
        {
            int playercount = players.Count;
            foreach (var card in cards)
            {
                if (playercount == players.Count)
                    playercount = 0;

                players[playercount].Hand.Add(card);
                playercount++;
            }
        }


        public void TakeCardFromPlayer(Player curentPlayer, Player nextPlayer, int userinput)
        {
            
            if (curentPlayer.GetType() == typeof(Computer))
            {
                curentPlayer.TakeCard(curentPlayer, nextPlayer, userinput);
            }
            else
            {
                curentPlayer.TakeCard(curentPlayer, nextPlayer, userinput);

            }
        }
    }
}
