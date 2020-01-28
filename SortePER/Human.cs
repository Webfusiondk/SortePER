using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePER
{
    class Human : Player
    {
        public Human(string name) : base(name)
        {
        }

        public override void TakeCard(Player CurentPlayer, Player NextPlayer, int userInput)
        {
            Card tempCard = NextPlayer.Hand[userInput - 1];
            CurentPlayer.Hand.Add(tempCard);
            NextPlayer.Hand.Remove(tempCard);
        }
    }
}
