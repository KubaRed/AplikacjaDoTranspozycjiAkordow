using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Data.Entity.Core.Metadata.Edm;

namespace TestowaDoPracy.Klasy
{
    class SongListDb
    {
        public static void InsertSongIntoDb(string title, string chord)
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

        }
    }
}
