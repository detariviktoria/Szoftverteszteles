using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024._12._16._DatumIdo
{
    internal class DatumIdo
    {
        private int ev, honap, nap, ora,perc, mp;

        public DatumIdo(string evhonapnap)
        {
            string[] strings = evhonapnap.Split(evhonapnap[3]);
            ev = int.Parse(strings[0]);
            honap = int.Parse(strings[1]);
            nap = int.Parse(strings[2]);
        }
    }
}
