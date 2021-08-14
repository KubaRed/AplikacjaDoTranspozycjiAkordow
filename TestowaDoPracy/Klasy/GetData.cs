using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaDoTranspozycji.Klasy
{
    class GetData
    {
        public static Users GetUserData(string login) 
        {
            Users m;
            
            using (APlikacjaDoTranspozycjiEntities db = new APlikacjaDoTranspozycjiEntities())
            {
               
                    var result = db.Users.FirstOrDefault(r => r.Login == login);

                    Users user = new Users()
                    {
                        UserID = result.UserID,
                        Login = result.Login,
                        Password = result.Password,
                        email = result.email,
                    };

                    m = user;
                }
              
            
            return m;
        }
    }
}
