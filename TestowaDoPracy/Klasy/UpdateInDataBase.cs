using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AplikacjaDoTranspozycji.Klasy
{
    class UpdateInDataBase
    {
        public static void UpdatePasswordInDataBase(string pass, string newPass)
        {
            try
            {
                using (APlikacjaDoTranspozycjiEntities db = new APlikacjaDoTranspozycjiEntities())
                {
                    var result = db.Users.SingleOrDefault(r => r.Password == pass);
                    if (result != null && pass != newPass && newPass.Length > 7)
                    {
                        result.Password = newPass;
                        db.SaveChanges();

                        MessageBox.Show("Hasło dla użytkownika " + result.Login + " zostało zmienione.", "Zmiana hasła", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else { MessageBox.Show("Podane hasła są takie same lub nowe jest zbyt krótkie (min. 8 znaków).", "Zmiana hasła", MessageBoxButton.OK, MessageBoxImage.Information); }


                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        
        }
    }
}
