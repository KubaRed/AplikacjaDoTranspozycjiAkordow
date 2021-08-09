using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestowaDoPracy.Klasy
{
    class AddToDataBase
    {
        public static void AddInstrumentToDb(string name, string key)
        {
            string[] InstrumentKeys = { "C", "Bb", "Es", "F" };

            LocalSQLServerConnection.OpenConnection();

            LocalSQLServerConnection.sql = "SELECT top 1 InstrumentID FROM Instruments WHERE InstrumentName='" + name + "' AND UserID= " + User.UserID;
            LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
            LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
            LocalSQLServerConnection.da = new SqlDataAdapter(LocalSQLServerConnection.cmd);
            LocalSQLServerConnection.dt = new DataTable();
            LocalSQLServerConnection.da.Fill(LocalSQLServerConnection.dt);

            if (LocalSQLServerConnection.dt.Rows.Count == 0 && InstrumentKeys.Contains(key))
            {
                try
                {
                    LocalSQLServerConnection.sql = "INSERT INTO Instruments (InstrumentName, InstrumentKey, UserID) VALUES ( '" + name + "', '" + key + "', '" + User.UserID + "'  )";
                    LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
                    LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
                    LocalSQLServerConnection.cmd.ExecuteNonQuery(); //INSERT
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("Błąd przy dodawaniu instrumentu!"
                           + Environment.NewLine + "opis: " + sqlex.Message.ToString(), "Dodaj Instrument"
                           , MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd przy dodawaniu utworu!"
                           + Environment.NewLine + "opis: " + ex.Message.ToString(), "Dodaj Instrument"
                           , MessageBoxButton.OK, MessageBoxImage.Error);
                }

                MessageBox.Show(name + " został dodany.", "Dodaj Instrument", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(name + " nie został dodany. Sprawdź poprawność podanego stroju, np. C, Es, Bb, F.", "Dodaj", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            LocalSQLServerConnection.CloseConnection();
        }

        public static void AddSongIntoDb(string title, string chord)
        {

            LocalSQLServerConnection.OpenConnection();

            LocalSQLServerConnection.sql = "SELECT top 1 SongID FROM Songs WHERE Title='" + title + "' AND UserID= " + User.UserID;
            LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
            LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
            LocalSQLServerConnection.da = new SqlDataAdapter(LocalSQLServerConnection.cmd);
            LocalSQLServerConnection.dt = new DataTable();
            LocalSQLServerConnection.da.Fill(LocalSQLServerConnection.dt);

            if (LocalSQLServerConnection.dt.Rows.Count == 0)
            {
                try
                {
                    LocalSQLServerConnection.sql = "INSERT INTO Songs ( UserID, Title, Notes) VALUES ( '" + User.UserID + "', '" + title + "', '" + chord + "'  )";
                    LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
                    LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
                    LocalSQLServerConnection.cmd.ExecuteNonQuery(); //INSERT
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("Błąd przy dodawaniu utworu!"
                           + Environment.NewLine + "opis: " + sqlex.Message.ToString(), "Lista utworów"
                           , MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd przy dodawaniu utworu!"
                           + Environment.NewLine + "opis: " + ex.Message.ToString(), "Lista utworów"
                           , MessageBoxButton.OK, MessageBoxImage.Error);
                }

                MessageBox.Show("Utwór " + title + " został Dodany.", "Lista utworów", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Utwór " + title + " nie został dodany. Wypełnij wszystkie pola, lub podany tutył już istnieje", "Lista utworów", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            LocalSQLServerConnection.CloseConnection();
        }
    }
}

