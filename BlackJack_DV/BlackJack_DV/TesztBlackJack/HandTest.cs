using BlackJack_DV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesztBlackJack
{
    [TestFixture]
    internal class HandTest
    {

            [Test]
            public void EmptyHand_ValueIsZero()
            {
                var hand = new Hand(new string[] { });
                Assert.AreEqual(0, hand.GetValue());
                Assert.IsFalse(hand.IsBlackjack());
                Assert.IsFalse(hand.IsBust());
            }

            [Test]
            public void HandWithNumberCards_SumsCorrectly()
            {
                var hand = new Hand(new[] { "2", "3", "4" });
                Assert.AreEqual(9, hand.GetValue());
                Assert.IsFalse(hand.IsBust());
            }

            [Test]
            public void HandWithSingleAce_IsElevenIfNoBust()
            {
                var hand = new Hand(new[] { "A", "8" });
                Assert.AreEqual(19, hand.GetValue());
                Assert.IsFalse(hand.IsBust());
            }

            [Test]
            public void HandWithAce_BecomesOneIfBustWouldHappen()
            {
                var hand = new Hand(new[] { "A", "9", "8" }); // 11+9+8=28 → 1+9+8=18
                Assert.AreEqual(18, hand.GetValue());
            }

            [Test]
            public void MultipleAces_OnlyOneCountsAsEleven()
            {
                var hand = new Hand(new[] { "A", "A", "8" }); // 11+1+8=20
                Assert.AreEqual(20, hand.GetValue());
            }

            [Test]
            public void IsBlackjack_TrueForAceAndTenCard()
            {
                var hand = new Hand(new[] { "A", "K" });
                Assert.IsTrue(hand.IsBlackjack());
            }

            [Test]
            public void IsBlackjack_FalseForMoreThanTwoCards()
            {
                var hand = new Hand(new[] { "A", "K", "2" });
                Assert.IsFalse(hand.IsBlackjack());
            }

            [Test]
            public void IsBlackjack_FalseIfNoAce()
            {
                var hand = new Hand(new[] { "K", "Q" });
                Assert.IsFalse(hand.IsBlackjack());
            }

            [Test]
            public void IsBust_TrueIfValueOver21()
            {
                var hand = new Hand(new[] { "K", "Q", "2" }); // 10+10+2=22
                Assert.IsTrue(hand.IsBust());
            }

            [Test]
            public void IsBust_FalseIfValueIs21()
            {
                var hand = new Hand(new[] { "7", "7", "7" });
                Assert.AreEqual(21, hand.GetValue());
                Assert.IsFalse(hand.IsBust());
            }

            [Test]
            public void FaceCardsAreTen()
            {
                var hand = new Hand(new[] { "J", "Q", "K" });
                Assert.AreEqual(30, hand.GetValue());
                Assert.IsTrue(hand.IsBust());
            }

            [Test]
            public void BlackjackRequiresExactlyTwoCards()
            {
                var hand = new Hand(new[] { "A", "10", "Q" });
                Assert.IsFalse(hand.IsBlackjack());
            }
        }
}
