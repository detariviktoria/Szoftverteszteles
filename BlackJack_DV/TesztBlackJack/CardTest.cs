using BlackJack_DV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesztBlackJack
{
    [TestFixture]
    internal class CardTest
    {
        [TestCase("A", 11)]
        [TestCase("K", 10)]
        [TestCase("Q", 10)]
        [TestCase("J", 10)]
        [TestCase("10", 10)]
        [TestCase("9", 9)]
        [TestCase("2", 2)]
        public void GetValue_ReturnsCorrectValue(string face, int expected)
        {
            var card = new Card(face);
            Assert.AreEqual(expected, card.GetValue());
        }

        [Test]
        public void FaceProperty_ReturnsCorrectFace()
        {
            var card = new Card("K");
            Assert.AreEqual("K", card.Face);
        }

        [Test]
        public void InvalidFace_ThrowsFormatException()
        {
            // Csak 2-10, J, Q, K, A a helyes input a kódban.
            // Ha pl. "B" vagy "1" kerül be, int.Parse dob hibát.
            Assert.Throws<System.FormatException>(() =>
            {
                var card = new Card("B");
                card.GetValue();
            });
        }
    }
}
