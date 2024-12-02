using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_11_07_Teszteles_Alapja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Szamelmelet sz = new Szamelmelet(0);
            Console.WriteLine(sz.Osztas(0,-2));
            Console.ReadLine();
        }
    }
}
