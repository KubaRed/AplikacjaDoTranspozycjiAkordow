using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestowaDoPracy.Klasy
{
    class SaveToFile
    {
        public static void SaveLoginToFile(string login)
        {
            File.WriteAllText(@"C:\Users\Public\TranspozycjaApp\Login.txt", login);
        }

        public static void DeletLoginFile()
        {
            File.Delete(@"C:\Users\Public\TranspozycjaApp\Login.txt");
        }
    }
}
