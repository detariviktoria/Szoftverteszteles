using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace _2024._11._28._Ügyfel_osztaly___tesztelese
{
    internal class Customer
    {
        public string firstName, lastName, birthDate, email;

        //public DateTime birthDate;


        public Customer(string firstName, string lastName, string birthDate, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.email = email;
        }
        
        /// <summary>
        /// Nem feltételezzük, hogy a dátum ponttal vagy vesszővel van elválasztva, ezért a szöveg ötödik elemével szeleteljük a dátumot, ha esetleg egyik helyen vessző másikon pont van, akkor mindig tudjunk dolgozni
        /// </summary>
        /// <param name="birthDate"></param>
        public int GetAge()
        {
            string date = "2024.12.06";
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

        /*public bool IsEmailValid()
        {
            string[] e = email.Split('@');
            string[] s = e[1].Split('.');
            // detariviktoria@ckik.hu
            if (e.Length == 2 && s.Length == 2)
            {
                int i = 0;
                while (i < e[0][i] && !(IsLetterOrDigit(e[0][i]) == false))
                {
                    i++;
                    if (i < e[0][i])
                    {
                        return false;
                    }
                    else
                    {
                        int j = 0;
                        while (j < s[0][j] && !(IsLetterOrDigit(s[0][j]) == false))
                        {
                            j++;
                            if (j < s[0][j])
                            {
                                return false;
                            }
                            else
                            {
                                int k = 0;
                                while (j < s[0][j] && !(IsLetterOrDigit(s[0][j]) == false))
                                {
                                    k++;
                                    if (k < s[1][j])
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
                
            }
            return false;
            
        }
        */


        public bool IsEmailValid()
        {
            return KukacESPont(email) && EmailValidalas(email) && NincsSzamjegy(email) ;
        }

        private bool IsLetterOrDigit(char c)
        {
            int ascii = Convert.ToInt32(c);
            return (ascii >= 65 && ascii <= 90) ||  // A-Z
                   (ascii >= 97 && ascii <= 122) || // a-z
                   (ascii >= 48 && ascii <= 57 ||   // 0-9
                   ascii == 46 || ascii == 64);    // . és @
        }


        public bool NincsSzamjegy(string szoveg)
        {
            string[] e = szoveg.Split('@');
            int i = 0;
            while (i < e[1].Length && szoveg[i] >= 48 && szoveg[i] <= 57) 
                i++;
            if (i < e[1].Length)
                {
                    return false;
                }
            return true;

        }

        public bool EmailValidalas(string szoveg)
        {
            int i = 0;
            while (i < szoveg.Length && IsLetterOrDigit(szoveg[i]))
                i++;
            if (i < szoveg.Length)
            {
                return false;
            }
            return true;
        }

        public bool KukacESPont(string szoveg)
        {
            string[] e = szoveg.Split('@');
            string[] s = e[1].Split('.');
            // detariviktoria@ckik.hu
            if (e.Length == 2 && s.Length == 2)
            {
                return true;
            }
            else return false;
        }
        

        public string GetFullName()
        {
            return firstName+" "+lastName;
        }
    }
}
