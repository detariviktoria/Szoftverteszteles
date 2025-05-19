using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesztBlackJack
{
    [TestFixture]
    internal class BlackJackGameTest
    {

        [Test]
        public void PlayerBlackjack_BankNoBlackjack_PlayerWinsWithBlackjack()
        {
            var player = new Hand(new[] { "A", "K" });
            var bank = new Hand(new[] { "10", "8" });
            var game = new BlackjackGame(player, bank);

            Assert.AreEqual("Blackjack!", game.GetWinner());
        }

        [Test]
        public void BankBlackjack_PlayerNoBlackjack_BankWinsWithBlackjack()
        {
            var player = new Hand(new[] { "10", "8" });
            var bank = new Hand(new[] { "A", "K" });
            var game = new BlackjackGame(player, bank);

            Assert.AreEqual("Bank", game.GetWinner());
        }

        [Test]
        public void BothHaveBlackjack_Draw()
        {
            var player = new Hand(new[] { "A", "K" });
            var bank = new Hand(new[] { "A", "K" });
            var game = new BlackjackGame(player, bank);

            Assert.AreEqual("Draw", game.GetWinner());
        }

        [Test]
        public void PlayerBeatsBank()
        {
            var player = new Hand(new[] { "10", "9" });
            var bank = new Hand(new[] { "8", "7" });
            var game = new BlackjackGame(player, bank);

            Assert.AreEqual("Player", game.GetWinner());
        }

        [Test]
        public void BankBeatsPlayer()
        {
            var player = new Hand(new[] { "8", "7" });
            var bank = new Hand(new[] { "10", "9" });
            var game = new BlackjackGame(player, bank);

            Assert.AreEqual("Bank", game.GetWinner());
        }

        [Test]
        public void Draw_SameScore()
        {
            var player = new Hand(new[] { "10", "8" });
            var bank = new Hand(new[] { "9", "9" });
            var game = new BlackjackGame(player, bank);

            Assert.AreEqual("Draw", game.GetWinner());
        }

        [Test]
        public void PlayerBusts_BankWins()
        {
            var player = new Hand(new[] { "10", "9", "5" }); // 24
            var bank = new Hand(new[] { "10", "6" }); // 16
            var game = new BlackjackGame(player, bank);

            Assert.AreEqual("Bank", game.GetWinner());
        }

        [Test]
        public void BankBusts_PlayerWins()
        {
            var player = new Hand(new[] { "10", "6" }); // 16
            var bank = new Hand(new[] { "10", "9", "5" }); // 24
            var game = new BlackjackGame(player, bank);

            Assert.AreEqual("Player", game.GetWinner());
        }

        [Test]
        public void BothBust_Draw()
        {
            var player = new Hand(new[] { "10", "9", "5" }); // 24
            var bank = new Hand(new[] { "10", "8", "7" }); // 25
            var game = new BlackjackGame(player, bank);

            Assert.AreEqual("Draw", game.GetWinner());
        }

        [Test]
        public void AceAsEleven_NotOver21()
        {
            var player = new Hand(new[] { "A", "7" }); // 18
            var bank = new Hand(new[] { "10", "7" }); // 17
            var game = new BlackjackGame(player, bank);

            Assert.AreEqual("Player", game.GetWinner());
        }

        [Test]
        public void MultipleAces_HandleCorrectly()
        {
            var player = new Hand(new[] { "A", "A", "9" }); // 21
            var bank = new Hand(new[] { "10", "7" }); // 17
            var game = new BlackjackGame(player, bank);

            Assert.AreEqual("Player", game.GetWinner());
        }

        [Test]
        public void MinimumHand_PlayerWins()
        {
            var player = new Hand(new[] { "2", "2" });
            var bank = new Hand(new[] { "2", "3" });
            var game = new BlackjackGame(player, bank);

            Assert.AreEqual("Bank", game.GetWinner());
        }
    }
}
