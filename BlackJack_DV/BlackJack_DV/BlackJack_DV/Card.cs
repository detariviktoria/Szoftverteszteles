using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_DV
{
    public class Card
    {
        public string Face { get; }

        public Card(string face)
        {
            Face = face;
        }

        public int GetValue()
        {
            if (Face == "A")
                return 11; // Az Ász értékét a Hand-ben fogjuk igazítani!
            if (Face == "K" || Face == "Q" || Face == "J" || Face == "10")
                return 10;
            return int.Parse(Face); // 2–9
        }
    }
}
