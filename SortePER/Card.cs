using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortePER
{
    public enum CardValue
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace,
        SortePer
    }

    public class Card
    {
        private string cardName;

        public string CardName
        {
            get { return cardName; }
            set { cardName = value; }
        }
        private CardValue cardValue;

        public CardValue CardValue
        {
            get { return cardValue; }
            set { cardValue = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Card(string name, CardValue value, int cardID)
        {
            Id = cardID;
            CardName = name;
            CardValue = value;
        }
    }
}
