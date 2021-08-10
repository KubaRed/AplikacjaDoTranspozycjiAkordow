using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace AplikacjaDoTranspozycji.Klasy
{
    class CheckRadioButton
    {
        public static int CheckRadioButtons(string firstName, string secondName)
        {
            int key = 0;

            //Stroj C na kolejne
            if (firstName == "strojC" && secondName == "strojCWynik")
            {
                key = 0;
            }
            else if (firstName == "strojC" && secondName == "strojBbWynik")
            {
                key = 1;
            }
            else if (firstName == "strojC" && secondName == "strojEsWynik")
            {
                key = 5;
            }
            else if (firstName == "strojC" && secondName == "strojFWynik")
            {
                key = 4;
            }

            // Stroj Bb na kolejne
            if (firstName == "strojBb" && secondName == "strojCWynik")
            {
                key = 6;
            }
            else if (firstName == "strojBb" && secondName == "strojBbWynik")
            {
                key = 0;
            }
            else if (firstName == "strojBb" && secondName == "strojEsWynik")
            {
                key = 4;
            }
            else if (firstName == "strojBb" && secondName == "strojFWynik")
            {
                key = 3;
            }

            //Stroj Es na kolejne
            if (firstName == "strojEs" && secondName == "strojCWynik")
            {
                key = 2;
            }
            else if (firstName == "strojEs" && secondName == "strojBbWynik")
            {
                key = 3;
            }
            else if (firstName == "strojEs" && secondName == "strojEsWynik")
            {
                key = 0;
            }
            else if (firstName == "strojEs" && secondName == "strojFWynik")
            {
                key = 6;
            }

            //Stroj F na kolejne
            if (firstName == "strojF" && secondName == "strojCWynik")
            {
                key = 3;
            }
            else if (firstName == "strojF" && secondName == "strojBbWynik")
            {
                key = 4;
            }
            else if (firstName == "strojF" && secondName == "strojEsWynik")
            {
                key = 1;
            }
            else if (firstName == "strojF" && secondName == "strojFWynik")
            {
                key = 0;
            }
            return key;
        }
    }
}
