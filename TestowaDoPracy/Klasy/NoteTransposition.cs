using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Runtime;

namespace TestowaDoPracy.Klasy
{
    class NoteTransposition
    {
        static string[] notes = new string[] { "c","d","e","f","g","a","h"};

        public static string TranspositionFromNote(string textToSplit, int key)
        {
            string wynik = "";

            
            string[] separator = { ", ", " " };
            string[] splitList = textToSplit.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] splitListResult = new string[splitList.Length];

            for (int i = 0; i < splitList.Length; i++)
            {
                splitListResult[i] = " ";
            }

            for (int i = 0; i < splitList.Length; i++)
            {
                for (int j = 0; j < notes.Length; j++)
                {
                    if (splitList[i] == notes[j] && j + key < notes.Length)
                    {
                        splitListResult[i] = notes[j + key];
                        wynik += splitListResult[i] + " ";
                    }
                    else if(splitList[i] == notes[j] && j + key >= notes.Length)
                    {
                        int suma = j + key;
                        splitListResult[i] = notes[suma - notes.Length];
                        wynik += splitListResult[i] + " ";
                    }
                }           
            }

            return wynik;
        }
    }
}
