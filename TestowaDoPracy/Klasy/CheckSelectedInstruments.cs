using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplikacjaDoTranspozycji.Klasy
{
    class CheckSelectedInstruments
    {
        public static int CheckKeyOfSelectedInstruments(string firstKey, string secondKey)
        {
            int key = 0;


            //Stroj C na kolejne
            if (firstKey == "C" && secondKey == "C")
            {
                key = 0;
            }
            else if (firstKey == "C" && secondKey == "Bb")
            {
                key = 1;
            }
            else if (firstKey == "C" && secondKey == "Es")
            {
                key = 5;
            }
            else if (firstKey == "C" && secondKey == "F")
            {
                key = 4;
            }

            // Stroj Bb na kolejne
            if (firstKey == "Bb" && secondKey == "C")
            {
                key = 6;
            }
            else if (firstKey == "Bb" && secondKey == "Bb")
            {
                key = 0;
            }
            else if (firstKey == "Bb" && secondKey == "Es")
            {
                key = 4;
            }
            else if (firstKey == "Bb" && secondKey == "F")
            {
                key = 3;
            }

            //Stroj Es na kolejne
            if (firstKey == "Es" && secondKey == "C")
            {
                key = 2;
            }
            else if (firstKey == "Es" && secondKey == "Bb")
            {
                key = 3;
            }
            else if (firstKey == "Es" && secondKey == "Es")
            {
                key = 0;
            }
            else if (firstKey == "Es" && secondKey == "F")
            {
                key = 6;
            }

            //Stroj F na kolejne
            if (firstKey == "F" && secondKey == "C")
            {
                key = 3;
            }
            else if (firstKey == "F" && secondKey == "Bb")
            {
                key = 4;
            }
            else if (firstKey == "F" && secondKey == "Es")
            {
                key = 1;
            }
            else if (firstKey == "F" && secondKey == "F")
            {
                key = 0;
            }

            return key;
        }
    }
}
