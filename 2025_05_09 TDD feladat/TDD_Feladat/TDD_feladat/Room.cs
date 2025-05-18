using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_feladat
{
    public class Room
    {
        public char[,] Grid { get; }
        public List<Candle> Candles { get; }

        //Konstruktor
        public Room(int n, string[] input) 
        {
            Grid = new char[n, n];
            Candles = new List<Candle>();
            AdatokFeldolgozasa(input);
        }

        private void AdatokFeldolgozasa(string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                string[] st = input[i].Split(' ');
                Feldolgoz(st, input, i);
            }
        }

        private void Feldolgoz(string[] st, string[] input, int i)
        {
            for (int j = 0; j < st.Length; j++)
            {
                Grid[i, j] = st[j][0];
                if (input[i][j] == 'C')
                {
                    Candles.Add(new Candle(i, j));
                }
            }
        }

        //Metódusok
        public bool IsInside(int x, int y)
        {
            return x >= 0 && y >= 0 && y < Grid.GetLength(0) && x < Grid.GetLength(1);
        }

    }
}
