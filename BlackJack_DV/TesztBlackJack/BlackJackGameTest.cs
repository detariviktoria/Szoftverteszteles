using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack_DV;

namespace TesztBlackJack
{
    [TestFixture]
    internal class BlackJackGameTest
    {

        [Test]
        public void PlayerBlackjack_BankNoBlackjack_IsBlackjackTrue()
        {
            var player = new Hand(new[] { "A", "K" });
            var bank = new Hand(new[] { "10", "8" });
            var game = new BlackjackGame(player, bank);

            Assert.IsTrue(player.IsBlackjack());
            Assert.IsFalse(bank.IsBlackjack());
            Assert.AreEqual("Blackjack!", game.GetWinner());
        }

        [Test]
        public void BankBlackjack_PlayerNoBlackjack_BankWins()
        {
            var player = new Hand(new[] { "10", "9" });
            var bank = new Hand(new[] { "A", "J" });
            var game = new BlackjackGame(player, bank);

            Assert.IsTrue(bank.IsBlackjack());
            Assert.AreEqual("Bank", game.GetWinner());
        }

        [Test]
        public void BothHaveBlackjack_Draw()
        {
            var player = new Hand(new[] { "A", "K" });
            var bank = new Hand(new[] { "A", "10" });
            var game = new BlackjackGame(player, bank);

            Assert.IsTrue(player.IsBlackjack());
            Assert.IsTrue(bank.IsBlackjack());
            Assert.AreEqual("Draw", game.GetWinner());
        }

        [Test]
        public void PlayerWinsWithHigherScore()
        {
            var player = new Hand(new[] { "10", "9" });
            var bank = new Hand(new[] { "8", "7" });
            var game = new BlackjackGame(player, bank);

            Assert.Greater(player.GetValue(), bank.GetValue());
            Assert.AreEqual("Player", game.GetWinner());
        }

        [Test]
        public void BankWinsWithHigherScore()
        {
            var player = new Hand(new[] { "7", "8" });
            var bank = new Hand(new[] { "9", "9" });
            var game = new BlackjackGame(player, bank);

            Assert.Greater(bank.GetValue(), player.GetValue());
            Assert.AreEqual("Bank", game.GetWinner());
        }

        [Test]
        public void Draw_WhenScoresAreEqualAndNoBlackjack()
        {
            var player = new Hand(new[] { "10", "8" });
            var bank = new Hand(new[] { "9", "9" });
            var game = new BlackjackGame(player, bank);

            Assert.AreEqual(player.GetValue(), bank.GetValue());
            Assert.IsFalse(player.IsBlackjack());
            Assert.IsFalse(bank.IsBlackjack());
            Assert.AreEqual("Draw", game.GetWinner());
        }

        [Test]
        public void PlayerBusts_BankWins()
        {
            var player = new Hand(new[] { "10", "9", "5" });
            var bank = new Hand(new[] { "10", "6" });
            var game = new BlackjackGame(player, bank);

            Assert.IsTrue(player.IsBust());
            Assert.IsFalse(bank.IsBust());
            Assert.AreEqual("Bank", game.GetWinner());
        }

        [Test]
        public void BankBusts_PlayerWins()
        {
            var player = new Hand(new[] { "10", "6" });
            var bank = new Hand(new[] { "10", "9", "5" });
            var game = new BlackjackGame(player, bank);

            Assert.IsTrue(bank.IsBust());
            Assert.IsFalse(player.IsBust());
            Assert.AreEqual("Player", game.GetWinner());
        }

        [Test]
        public void BothBust_Draw()
        {
            var player = new Hand(new[] { "10", "9", "5" });
            var bank = new Hand(new[] { "10", "8", "7" });
            var game = new BlackjackGame(player, bank);

            Assert.IsTrue(player.IsBust());
            Assert.IsTrue(bank.IsBust());
            Assert.AreEqual("Draw", game.GetWinner());
        }

        [Test]
        public void AceAsElevenWhenNotOver21()
        {
            var hand = new Hand(new[] { "A", "9" });
            Assert.AreEqual(20, hand.GetValue());
            Assert.IsFalse(hand.IsBust());
        }

        [Test]
        public void MultipleAces_OnlyOneEleven()
        {
            var hand = new Hand(new[] { "A", "A", "9" }); // 11+1+9=21
            Assert.AreEqual(21, hand.GetValue());
            Assert.IsFalse(hand.IsBust());
        }

        [Test]
        public void EmptyHand_ValueIsZero()
        {
            var hand = new Hand(new string[] { });
            Assert.Zero(hand.GetValue());
            Assert.IsFalse(hand.IsBust());
            Assert.IsFalse(hand.IsBlackjack());
        }

        [Test]
        public void HandWithOnlyFaceCards_IsNotBlackjack()
        {
            var hand = new Hand(new[] { "Q", "J", "K" });
            Assert.IsFalse(hand.IsBlackjack());
            Assert.Greater(hand.GetValue(), 0);
        }

        [Test]
        public void PlayerHas21WithThreeCards_BankHasLess_PlayerWins()
        {
            var player = new Hand(new[] { "7", "7", "7" });
            var bank = new Hand(new[] { "10", "9" });
            var game = new BlackjackGame(player, bank);

            Assert.AreEqual(21, player.GetValue());
            Assert.IsFalse(player.IsBlackjack());
            Assert.AreEqual("Player", game.GetWinner());
        }
    }
}
