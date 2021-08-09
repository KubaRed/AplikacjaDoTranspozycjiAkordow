using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace TestowaDoPracy.Klasy
{
    class Combobox
    {
        public static void FillComboboxMelody(ComboBox combobox)
        {

            try
            {
                LocalSQLServerConnection.OpenConnection();

                LocalSQLServerConnection.sql = "SELECT * FROM Songs";
                LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
                LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
                LocalSQLServerConnection.rd = LocalSQLServerConnection.cmd.ExecuteReader();

                while (LocalSQLServerConnection.rd.Read())
                {
                    string title = LocalSQLServerConnection.rd.GetString(2);
                    combobox.Items.Add(title);
                }
            

                LocalSQLServerConnection.CloseConnection();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Błąd przy dodawaniu utworu!"
                            + Environment.NewLine + "opis: " + ex.Message.ToString(), "ComboBox"
                            , MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
