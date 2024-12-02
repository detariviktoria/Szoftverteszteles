using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _2024._11._28._Ügyfel_osztaly___tesztelese
{
    internal class Customer
    {
        static string firstName, lastName, birthDate, email;


        /// <summary>
        /// Nem feltételezzük, hogy a dátum ponttal vagy vesszővel van elválasztva, ezért a szöveg ötödik elemével szeleteljük a dátumot, ha esetleg egyik helyen vessző másikon pont van, akkor mindig tudjunk dolgozni
        /// </summary>
        /// <param name="birthDate"></param>
        public int GetAge()
        {
            string date = "2024.11.28.";
            string[] d = date.Split('.');

            

            string[] sz = birthDate.Split(birthDate[4]); //2024.02.05.
            int ev = Convert.ToInt32(sz[0]);
            int honap = Convert.ToInt32(sz[1]);
            int nap = Convert.ToInt32(sz[2]);

            if(Convert.ToInt16(d[0]) > ev &&  Convert.ToInt32(d[1]) >= honap && Convert.ToInt32(d[2]) >= nap)
            {
                return Convert.ToInt32(d[1]) - ev;
            }
            else
            {
                return Convert.ToInt32(d[1]) - ev - 1;
            }
        }

        public bool IsEmailValid()
        {
            string[] e = email.Split('@');
            string[] s = e[1].Split('.');
            // detari.viktoria@ckik.hu
            if (e.Length == 2 && s.Length == 2)
                { return true; }
            else
                { return false; }
        }

        public string GetFullName()
        {
            return firstName+" "+lastName;
        }
    }
}
