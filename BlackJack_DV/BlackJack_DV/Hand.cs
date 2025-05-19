using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_DV
{
    public class Hand
    {
        public List<Card> Cards { get; }

        public Hand(IEnumerable<string> faces)
        {
            Cards = new List<Card>();
            foreach (var face in faces)
                Cards.Add(new Card(face));
        }

        public int GetValue()
        {
            int totalValue = Cards.Sum(card => card.GetValue());
            int aceCount = Cards.Count(card => card.Face == "A");

            // 1-nek vesszuk az aszokat ha tullepi a 21-et
            while (totalValue > 21 && aceCount > 0)
            {
                totalValue -= 10; 
                aceCount--;
            }
            return totalValue;
        }

        public bool IsBlackjack()
        {
            // Pontosan 2 lap, egyik Ász, másik 10/J/Q/K
            var cards = this.Cards;
            if (cards.Count != 2) return false;
            bool hasAce = cards.Any(c => c.Face == "A");
            bool hasTenCard = cards.Any(c => c.GetValue() == 10);
            return hasAce && hasTenCard;
        }
        

        public bool IsBust()
        {
            return GetValue() > 21;
        }
    }
}
