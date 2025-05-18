using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TDD_feladat
{
    public class LightCalculator
    {
        public int[,] LightMap { get; }
        private Room room;
        private int power;

        //Konstruktor
        public LightCalculator(Room room, int power)
        {
            this.room = room;
            this.power = power;
            int n = room.Grid.GetLength(0);
            LightMap = new int[n,n];
        }

        //Metódusok
        public void CalculateLight()
        {
            int s = 1;
            for (int i = 0; i < room.Candles.Count; i++)
            {
                Candle can = room.Candles[i];
                int p = power;
                for (int l = 0; l < p; l++)
                {

                    for (int j = can.X - power + 1; j <= can.X + power - 1; j++)
                    {
                        for (int k = can.Y - power + 1; k <= can.Y + power - 1; k++)
                        {
                            if (room.IsInside(j, k))
                                LightMap[j, k] = s;
                        }
                    }
                    s++;
                    power--;
                }
            }
        }

        public int CountDarkSpots()
        {
            int db = 0;
            for (int i = 0; i < LightMap.GetLength(0); i++)
            {
                for (int j = 0; j < LightMap.GetLength(1); j++)
                {
                    if (LightMap[i, j] == 0) 
                        db++;
                }
            }
            return db;
        }
    }
}
