using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AplikacjaDoTranspozycji.Klasy
{
    class DeleteFromDataBase
    {
        public static void DeleteInstrumenFromDb(string name, int userID)
        {
            try
            {
                using (APlikacjaDoTranspozycjiEntities db = new APlikacjaDoTranspozycjiEntities())
                {
                    var result = db.Instruments.FirstOrDefault(r => r.InstrumentName == name && r.UserID == userID);
                    if (result != null)
                        db.Instruments.Remove(result);
                    db.SaveChanges();

                    MessageBox.Show("Instrument " + name + " został usunięty pomyślnie.", "Usuń instrument", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //LocalSQLServerConnection.OpenConnection();

            //LocalSQLServerConnection.sql = "SELECT top 1 InstrumentID FROM Instruments WHERE InstrumentName='" + name + "' AND UserID= " + User.UserID;
            //LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
            //LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
            //LocalSQLServerConnection.da = new SqlDataAdapter(LocalSQLServerConnection.cmd);
            //LocalSQLServerConnection.dt = new DataTable();
            //LocalSQLServerConnection.da.Fill(LocalSQLServerConnection.dt);

            //if (LocalSQLServerConnection.dt.Rows.Count == 0)
            //{
            //    try
            //    {
            //        LocalSQLServerConnection.sql = "DELETE FROM Instruments Where InstrumentName='" + name + "' ";
            //        LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
            //        LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
            //        LocalSQLServerConnection.cmd.ExecuteNonQuery(); //INSERT
            //    }
            //    catch (SqlException sqlex)
            //    {
            //        MessageBox.Show("Błąd przy usuwaniu instrumentu!"
            //               + Environment.NewLine + "opis: " + sqlex.Message.ToString(), "Usuń instriument"
            //               , MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Błąd przy usuwaniu instrumentu!"
            //               + Environment.NewLine + "opis: " + ex.Message.ToString(), "Usuń instriument"
            //               , MessageBoxButton.OK, MessageBoxImage.Error);
            //    }

            //    MessageBox.Show("Instrument " + name + " został dodany.", "Usuń instriument", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //else
            //{
            //    MessageBox.Show("Instrument " + name + " nie został dodany.", "Usuń instriument", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
        }

        public static void DeleteChordSongFromDb(string title, int userID)
        {
            try
            {
                using (APlikacjaDoTranspozycjiEntities db = new APlikacjaDoTranspozycjiEntities())
                {
                    var result = db.ChordSongs.FirstOrDefault(r => r.Title == title && r.UserID == userID);
                    if (result != null)
                        db.ChordSongs.Remove(result);
                    db.SaveChanges();

                    MessageBox.Show("Utwór o tytule " + title + " został usunięty.", "Usuń utwór", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //LocalSQLServerConnection.OpenConnection();

            //LocalSQLServerConnection.sql = "SELECT top 1 ChordID FROM ChordSongs WHERE Title='" + title + "' AND UserID= " + User.UserID;
            //LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
            //LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
            //LocalSQLServerConnection.da = new SqlDataAdapter(LocalSQLServerConnection.cmd);
            //LocalSQLServerConnection.dt = new DataTable();
            //LocalSQLServerConnection.da.Fill(LocalSQLServerConnection.dt);

            //if (LocalSQLServerConnection.dt.Rows.Count == 0)
            //{
            //    try
            //    {
            //        LocalSQLServerConnection.sql = "DELETE FROM ChordSongs Where Title='" + title + "' ";
            //        LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
            //        LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
            //        LocalSQLServerConnection.cmd.ExecuteNonQuery(); //INSERT
            //    }
            //    catch (SqlException sqlex)
            //    {
            //        MessageBox.Show("Błąd przy usuwaniu utowru!"
            //               + Environment.NewLine + "opis: " + sqlex.Message.ToString(), "Usuń utwór"
            //               , MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Błąd przy usuwaniu utworu!"
            //               + Environment.NewLine + "opis: " + ex.Message.ToString(), "Usuń utwór"
            //               , MessageBoxButton.OK, MessageBoxImage.Error);
            //    }

            //    MessageBox.Show("Utwór o tytule " + title + " został usunięty.", "Usuń utwór", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //else
            //{
            //    MessageBox.Show("Utwór o tytule " + title + " nie został dodany.", "Usuń utwór", MessageBoxButton.OK, MessageBoxImage.Information);
            //}

        }

        public static void DeleteSongFromDb(string title, int userID)
        {
            try
            {
                using (APlikacjaDoTranspozycjiEntities db = new APlikacjaDoTranspozycjiEntities())
                {
                    var result = db.Songs.FirstOrDefault(r => r.Title == title && r.UserID == userID);
                    if (result != null)
                        db.Songs.Remove(result);
                    db.SaveChanges();

                    MessageBox.Show("Utwór o tytule " + title + " został usunięty.", "Usuń utwór", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void DeleteUserFromDb(string login, Window menu)
        {
            try
            {
                using (APlikacjaDoTranspozycjiEntities db = new APlikacjaDoTranspozycjiEntities())
                {
                    var result = db.Users.FirstOrDefault(r => r.Login == login);
                    if (result != null)
                        db.Users.Remove(result);
                    db.SaveChanges();

                    MessageBox.Show("Konto użytkownika "+ login +" zostało pomyślnie usunięte.", "Usuń użytkownika", MessageBoxButton.OK, MessageBoxImage.Information);

                    MainWindow main = new MainWindow();
                    main.Show();
                    menu.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
