using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_DV
{
    public class BlackjackGame
    {
        public Hand Player { get; }
        public Hand Bank { get; }

        public BlackjackGame(Hand player, Hand bank)
        {
            Player = player;
            Bank = bank;
        }

        public string GetWinner()
        {
            bool playerHasBlackjack = Player.IsBlackjack();
            bool bankHasBlackjack = Bank.IsBlackjack();

            int playerValue = Player.GetValue();
            int bankValue = Bank.GetValue();

            // 1. Ha a játékosnak BlackJack-je van, és a banknak nincs
            if (playerHasBlackjack && !bankHasBlackjack)
                return "Blackjack!";

            // 2. Ha a játékos túlmegy 21-en (bukik)
            if (playerValue > 21)
                return "Bank";

            // 3. Ha a bank túlmegy 21-en (bukik)
            if (bankValue > 21)
                return "Player";

            // 4. Ha a banknak BlackJack-je van (és a játékosnak nincs), vagy a bank erősebb
            if ((bankHasBlackjack && !playerHasBlackjack) || (playerValue < bankValue))
                return "Bank";

            // 5. Ha a játékos erősebb
            if (playerValue > bankValue)
                return "Player";

            // 6. Döntetlen
            return "Draw";
        }
    }
}
