using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace _2024_11_07_Teszteles_Alapja
{
    [TestFixture]
    internal class Szamelmelet_teszt
    {
        Szamelmelet sz;
        [SetUp]
        public void Setup()
        {
            sz = new Szamelmelet(0 );
        }

        [Test] // annotáció
        public void Duplaz_a12()
        {
            //Arrange (Előkészítjük a teszt környezetét és az összes szükséges előfeltételt.)
            int a = 12;
            sz = new Szamelmelet(a);

            //Act (Ebben a lépésben végrehajtjuk a tesztelendő műveletet vagy műveleteket.)
            int eredmeny = sz.Duplazas();

            //Assert
            ClassicAssert.AreEqual(24, eredmeny);            
        }
        [Test]
        public void Duplaz_a0()
        {
            //int a = 0;
            //Szamelmelet sz = new Szamelmelet(a);

            int eredmeny = sz.Duplazas();

            ClassicAssert.AreEqual(0, eredmeny);
        }

        [Test]
        public void Hatvanyozas_a2b10() {
            int a = 2;
            int b = 10;
            sz = new Szamelmelet(a);

            double eredmeny = sz.Hatvanyozas(b);

            ClassicAssert.AreEqual(Math.Pow(2,10), eredmeny);
        }

        [Test]
        public void Hatvanyozas_a20b10()
        {
            int a = 20;
            int b = 10;
            sz = new Szamelmelet(a);

            double eredmeny = sz.Hatvanyozas(b);

            ClassicAssert.AreEqual(Math.Pow(20, 10), eredmeny);
        }

        [Test]
        public void Hatvanyozas([Values(0, 2, 20)] int a, [Values(-2, 10, 15)] int b)
        {
            sz = new Szamelmelet(a);
            double eredmeny = sz.Hatvanyozas(b);
            ClassicAssert.AreEqual(Math.Pow(a, b), eredmeny);
        }

        [Test]
        public void Osztas([Values(-2)] double a, [Values(0)] double b)
        {
            sz = new Szamelmelet((int)a);
            //double eredmeny = sz.Osztas(a, b);
            //ClassicAssert.AreEqual(0, eredmeny);
            Assert.Throws<DivideByZeroException>(() =>
            {
                
                sz.Osztas(a, b);
            });
        }

        [TestCase(2, 10, 1024)]
        [TestCase(2, -2, 0.25)]
        [TestCase(0, 3, 0)]
        public void HatvanyTesztesetei(int a, int b, double varteredmeny)
        {
            sz = new Szamelmelet(a);
            double eredmeny = sz.Hatvanyozas(b);
            ClassicAssert.AreEqual(varteredmeny,eredmeny);
        }

        [TearDown]
        public void Teardown()
        {
            sz = null;
        }
    }
}
