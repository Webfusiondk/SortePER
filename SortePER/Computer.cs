using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePER
{
    class Computer : Player
    {
        public Computer(string name) : base(name)
        {
        }
        public override void TakeCard(Player CurentPlayer, Player NextPlayer, int random)
        {

            Card tempCard = NextPlayer.Hand[random];
            CurentPlayer.Hand.Add(tempCard);
            NextPlayer.Hand.Remove(tempCard);
        }
    }
}
