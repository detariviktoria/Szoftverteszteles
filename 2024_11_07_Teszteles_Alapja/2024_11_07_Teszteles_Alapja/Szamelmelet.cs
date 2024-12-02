using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_11_07_Teszteles_Alapja
{
    /// <summary>
    /// Számlelméleti algoritmusok használata.
    /// </summary>
    internal class Szamelmelet
    {
        int a;

        public Szamelmelet(int uja) {
            a = uja;
        }

        /// <summary>
        /// A fv megduplázza az osztályban használt "a" változó értékét!
        /// </summary>
        /// <returns>Megduplázott érték.</returns>
        public int Duplazas()
        {
            return a * 2;
        }



        public double Hatvanyozas(int kitevo)
        {
            double hatvany = 1;
            for (int i = 0; i < Math.Abs(kitevo); i++)
            {
                if (kitevo < 0)
                    hatvany /= a;
                else
                    hatvany *= a;
            }
            return hatvany;
        }

        public double Osztas(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException();
            return a / b;
        }

    }
}
