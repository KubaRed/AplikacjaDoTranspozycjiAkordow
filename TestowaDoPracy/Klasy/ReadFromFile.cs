using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestowaDoPracy.Klasy
{
    class ReadFromFile
    {
        public static string ReadLoginFromFile()
        {
            string loginRead = File.ReadAllText(@"C:\Users\Public\TranspozycjaApp\Login.txt");

            return loginRead;
        }

    }
}
