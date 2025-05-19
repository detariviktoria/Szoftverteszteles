using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesztBlackJack
{
        [TestFixture]
        internal class TestWithFilePath
        {
            List<string> paths;

            [SetUp]
            public void Setup()
            {
                // Igazítsd az elérési utat a saját projektedhez!
                paths = Directory.GetFiles("../../../../Fajlok", "*.txt").ToList();
            }

            [TestCase(0, "Blackjack!")]
            [TestCase(1, "Bank")]
            [TestCase(2, "Player")]
            [TestCase(3, "Draw")]
            [TestCase(4, "Bank")]
            [TestCase(5, "Player")]
            [TestCase(6, "Draw")]
            [TestCase(7, "Player")]
            [TestCase(8, "Bank")]

        public void Test(int index, string expected)
        {
            // fajlbeolvasas
            string[] lines = File.ReadAllLines(paths[index]);

            // A játékos és a bank lapjainak feldarabolása 
            string[] playerCards = lines[0].Split(' ');
            string[] bankCards = lines[1].Split(' ');

            var player = new Hand(playerCards);
            var bank = new Hand(bankCards);
            var game = new BlackjackGame(player, bank);

            string actual = game.GetWinner();

            Assert.AreEqual(expected, actual, $"Teszt: {Path.GetFileName(paths[index])}");
        }
        [TearDown]
            public void TearDown()
            {
                paths = null;
            }
        }
}
