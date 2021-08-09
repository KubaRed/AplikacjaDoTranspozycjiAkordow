using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public static void AddUserToDataBase(string login, string pass1, string pass2, string email, RegistrationPage reg)
        {
            Regex regexEmail = new Regex(RegularExpresions.EmailRegex());
            Match matchEmail = regexEmail.Match(email);

            LocalSQLServerConnection.OpenConnection();
            LocalSQLServerConnection.sql = "select Top 1 * From Users Where Login='" + login + "' OR email ='" + email + "' ";
            LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
            LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
            LocalSQLServerConnection.da = new SqlDataAdapter(LocalSQLServerConnection.cmd);
            LocalSQLServerConnection.dt = new DataTable();
            LocalSQLServerConnection.da.Fill(LocalSQLServerConnection.dt);

            if (LocalSQLServerConnection.dt.Rows.Count == 0)
            {
                if (pass1 == pass2 && pass1.Length > 7)
                {
                    if (matchEmail.Success)
                    {
                        try
                        {
                            LocalSQLServerConnection.OpenConnection();
                            LocalSQLServerConnection.sql = "INSERT INTO Users (Login, Password, email) VALUES ('" + login + "', '" + pass1 + "', '" + email + "')";
                            LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
                            LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
                            LocalSQLServerConnection.cmd.ExecuteNonQuery(); //INSERT
                            LocalSQLServerConnection.CloseConnection();


                            LocalSQLServerConnection.OpenConnection();
                            LocalSQLServerConnection.sql = "SELECT top 1 * FROM Users WHERE Login='" + login + "' AND Password='" + pass1 + "'";
                            LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
                            LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
                            LocalSQLServerConnection.rd = LocalSQLServerConnection.cmd.ExecuteReader();

                            if (LocalSQLServerConnection.rd.Read())
                            {
                                User.UserID = LocalSQLServerConnection.rd["UserID"].ToString();
                                User.Login = LocalSQLServerConnection.rd["Login"].ToString();
                                User.Password = LocalSQLServerConnection.rd["Password"].ToString();
                                User.Email = LocalSQLServerConnection.rd["email"].ToString();
                            }
                            LocalSQLServerConnection.CloseConnection();


                            MessageBox.Show("Użytkownik " + login + " został poprawnie utworzony.", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Information);

                            MenuGlowne menu = new MenuGlowne();
                            menu.Show();
                            reg.Close();

                        }
                        catch (SqlException sqlex)
                        {
                            MessageBox.Show("Błąd przy rejestracji!"
                                   + Environment.NewLine + "opis: " + sqlex.Message.ToString(), "Rejestracja"
                                   , MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Błąd przy rejestracji"
                                   + Environment.NewLine + "opis: " + ex.Message.ToString(), "Rejestracja"
                                   , MessageBoxButton.OK, MessageBoxImage.Error);
                        }


                    }
                    else { MessageBox.Show("Niepoprawny adres E-mail!", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Error); }
                }
                else { MessageBox.Show("Podane hasła nie pasują do siebie, lub są zbyt krótkie (min. 8 znaków)!", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            else { MessageBox.Show("Podany użytkownik, lub email juz został wykorzystany!", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Error); }

            LocalSQLServerConnection.CloseConnection();
        }
    }
}

