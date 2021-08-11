using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaDoTranspozycji.Klasy
{
    class CheckRecords
    {
        public static bool CheckIfUserExists(string login, string pass)
        {
            bool wynik = false;
            using (APlikacjaDoTranspozycjiEntities db = new APlikacjaDoTranspozycjiEntities())
            {
                var result = db.Users.Any(r => r.Login == login && r.Password == pass);
                wynik = result;
            }


            return wynik;
        }
    }
}
