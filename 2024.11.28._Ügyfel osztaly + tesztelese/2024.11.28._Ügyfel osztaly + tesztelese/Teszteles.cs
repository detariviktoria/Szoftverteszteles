using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace _2024._11._28._Ügyfel_osztaly___tesztelese
{
    internal class Teszteles
    {
        Customer sz;
        [SetUp]
        public void Setup()
        {
            sz = new Customer("John", "Doe", "1990.05.15", "johndoe@email.com");
        }
    }
}
