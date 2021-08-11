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
        public static void UpdatePasswordInDataBase(string pass)
        {
            try
            {
                using (APlikacjaDoTranspozycjiEntities db = new APlikacjaDoTranspozycjiEntities())
                {
                    Users user = new Users()
                    {
                        Password = pass,
                    };

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        
        }
    }
}
