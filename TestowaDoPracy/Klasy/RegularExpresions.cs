using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestowaDoPracy.Klasy
{
    class RegularExpresions
    {
        public static string EmailRegex()
        { 
            string emailRegex = @"^([\w\.\-]{3,64})@([\w\-]{1,253})((\.(\w){2,3})+)$";
            return emailRegex;
        }
    }
}
