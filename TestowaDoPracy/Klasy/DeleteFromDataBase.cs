using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AplikacjaDoTranspozycji.Klasy
{
    class DeleteFromDataBase
    {
        public static void DeleteInstrumenFromDb(string name)
        {
            LocalSQLServerConnection.OpenConnection();

            LocalSQLServerConnection.sql = "SELECT top 1 InstrumentID FROM Instruments WHERE InstrumentName='" + name + "' AND UserID= " + User.UserID;
            LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
            LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
            LocalSQLServerConnection.da = new SqlDataAdapter(LocalSQLServerConnection.cmd);
            LocalSQLServerConnection.dt = new DataTable();
            LocalSQLServerConnection.da.Fill(LocalSQLServerConnection.dt);

            if (LocalSQLServerConnection.dt.Rows.Count == 0)
            {
                try
                {
                    LocalSQLServerConnection.sql = "DELETE FROM Instruments Where InstrumentName='" + name + "' ";
                    LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
                    LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
                    LocalSQLServerConnection.cmd.ExecuteNonQuery(); //INSERT
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("Błąd przy usuwaniu instrumentu!"
                           + Environment.NewLine + "opis: " + sqlex.Message.ToString(), "Usuń instriument"
                           , MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd przy usuwaniu instrumentu!"
                           + Environment.NewLine + "opis: " + ex.Message.ToString(), "Usuń instriument"
                           , MessageBoxButton.OK, MessageBoxImage.Error);
                }

                MessageBox.Show("Instrument " + name + " został dodany.", "Usuń instriument", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Instrument " + name + " nie został dodany.", "Usuń instriument", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public static void DeleteChordSongFromDb(string title)
        {
 

            LocalSQLServerConnection.OpenConnection();

            LocalSQLServerConnection.sql = "SELECT top 1 ChordID FROM ChordSongs WHERE Title='" + title + "' AND UserID= " + User.UserID;
            LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
            LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
            LocalSQLServerConnection.da = new SqlDataAdapter(LocalSQLServerConnection.cmd);
            LocalSQLServerConnection.dt = new DataTable();
            LocalSQLServerConnection.da.Fill(LocalSQLServerConnection.dt);

            if (LocalSQLServerConnection.dt.Rows.Count == 0)
            {
                try
                {
                    LocalSQLServerConnection.sql = "DELETE FROM ChordSongs Where Title='" + title + "' ";
                    LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
                    LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
                    LocalSQLServerConnection.cmd.ExecuteNonQuery(); //INSERT
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("Błąd przy usuwaniu utowru!"
                           + Environment.NewLine + "opis: " + sqlex.Message.ToString(), "Usuń utwór"
                           , MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd przy usuwaniu utworu!"
                           + Environment.NewLine + "opis: " + ex.Message.ToString(), "Usuń utwór"
                           , MessageBoxButton.OK, MessageBoxImage.Error);
                }

                MessageBox.Show("Utwór o tytule " + title + " został usunięty.", "Usuń utwór", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Utwór o tytule " + title + " nie został dodany.", "Usuń utwór", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
