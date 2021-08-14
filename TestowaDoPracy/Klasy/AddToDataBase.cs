﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace AplikacjaDoTranspozycji.Klasy
{
    class AddToDataBase
    {
        public static void AddInstrumentToDb(string name, string key, int userId)
        {
            string[] InstrumentKeys = { "C", "Bb", "Es", "F" };

            try
            {
                using (APlikacjaDoTranspozycjiEntities db = new APlikacjaDoTranspozycjiEntities())
                {
                    if (db.Instruments.Any(o => o.InstrumentName== name && o.UserID == userId) && InstrumentKeys.Contains(key))
                    {

                        MessageBox.Show("Instrument " + name + " nie został dodany. Sprawdź poprawność podanego stroju, np. C, Es, Bb, F.", "Dodaj", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        Instruments instrument = new Instruments()
                        {
                            InstrumentName = name,
                            InstrumentKey = key,
                            UserID = userId,

                        };
                        db.Instruments.Add(instrument);
                        db.SaveChanges();

                        MessageBox.Show("Instrument " + name + " został dodany.", "Dodaj Instrument", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
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

            //if (LocalSQLServerConnection.dt.Rows.Count == 0 && InstrumentKeys.Contains(key))
            //{
            //    try
            //    {
            //        LocalSQLServerConnection.sql = "INSERT INTO Instruments (InstrumentName, InstrumentKey, UserID) VALUES ( '" + name + "', '" + key + "', '" + User.UserID + "'  )";
            //        LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
            //        LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
            //        LocalSQLServerConnection.cmd.ExecuteNonQuery(); //INSERT
            //    }
            //    catch (SqlException sqlex)
            //    {
            //        MessageBox.Show("Błąd przy dodawaniu instrumentu!"
            //               + Environment.NewLine + "opis: " + sqlex.Message.ToString(), "Dodaj Instrument"
            //               , MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Błąd przy dodawaniu instrumentu!"
            //               + Environment.NewLine + "opis: " + ex.Message.ToString(), "Dodaj Instrument"
            //               , MessageBoxButton.OK, MessageBoxImage.Error);
            //    }

            //    MessageBox.Show(name + " został dodany.", "Dodaj Instrument", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //else
            //{
            //    MessageBox.Show(name + " nie został dodany. Sprawdź poprawność podanego stroju, np. C, Es, Bb, F.", "Dodaj", MessageBoxButton.OK, MessageBoxImage.Information);
            //}

            //LocalSQLServerConnection.CloseConnection();
        }

        public static void AddMelodyIntoDb(string title, string chord, int userId)
        {

            try
            {
                using (APlikacjaDoTranspozycjiEntities db = new APlikacjaDoTranspozycjiEntities())
                {
                    if (db.Songs.Any(o => o.Title== title && o.UserID == userId))
                    {

                        MessageBox.Show("Utwór " + title + " nie został dodany. Wypełnij wszystkie pola, lub podany tutył już istnieje", "Lista utworów", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        Songs song = new Songs()
                        {
                            Title = title,
                            Notes = chord,
                            UserID = userId,

                        };
                        db.Songs.Add(song);
                        db.SaveChanges();

                        MessageBox.Show("Utwór " + title + " został Dodany.", "Lista utworów", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //LocalSQLServerConnection.OpenConnection();

            //LocalSQLServerConnection.sql = "SELECT top 1 SongID FROM Songs WHERE Title='" + title + "' AND UserID= " + User.UserID;
            //LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
            //LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
            //LocalSQLServerConnection.da = new SqlDataAdapter(LocalSQLServerConnection.cmd);
            //LocalSQLServerConnection.dt = new DataTable();
            //LocalSQLServerConnection.da.Fill(LocalSQLServerConnection.dt);

            //if (LocalSQLServerConnection.dt.Rows.Count == 0)
            //{
            //    try
            //    {
            //        LocalSQLServerConnection.sql = "INSERT INTO Songs ( UserID, Title, Notes) VALUES ( '" + User.UserID + "', '" + title + "', '" + chord + "'  )";
            //        LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
            //        LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
            //        LocalSQLServerConnection.cmd.ExecuteNonQuery(); //INSERT
            //    }
            //    catch (SqlException sqlex)
            //    {
            //        MessageBox.Show("Błąd przy dodawaniu utworu!"
            //               + Environment.NewLine + "opis: " + sqlex.Message.ToString(), "Lista utworów"
            //               , MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Błąd przy dodawaniu utworu!"
            //               + Environment.NewLine + "opis: " + ex.Message.ToString(), "Lista utworów"
            //               , MessageBoxButton.OK, MessageBoxImage.Error);
            //    }

            //    MessageBox.Show("Utwór " + title + " został Dodany.", "Lista utworów", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //else
            //{
            //    MessageBox.Show("Utwór " + title + " nie został dodany. Wypełnij wszystkie pola, lub podany tutył już istnieje", "Lista utworów", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //LocalSQLServerConnection.CloseConnection();
        }

        public static void AddChordSongIntoDb(string title, string chord, int userId)
        {

            try
            {
                using (APlikacjaDoTranspozycjiEntities db = new APlikacjaDoTranspozycjiEntities())
                {
                    if (db.ChordSongs.Any(o => o.Title == title && o.UserID == userId))
                    {

                        MessageBox.Show("Utwór " + title + " nie został dodany. Wypełnij wszystkie pola, lub podany tutył już istnieje", "Lista utworów", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        ChordSongs song = new ChordSongs()
                        {
                            Title = title,
                            Chord = chord,
                            UserID = userId,

                        };
                        db.ChordSongs.Add(song);
                        db.SaveChanges();

                        MessageBox.Show("Utwór " + title + " został Dodany.", "Lista utworów", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
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
            //        LocalSQLServerConnection.sql = "INSERT INTO ChordSongs (UserID, Title, Chord) VALUES ( '" + User.UserID + "', '" + title + "', '" + chord + "'  )";
            //        LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
            //        LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
            //        LocalSQLServerConnection.cmd.ExecuteNonQuery(); //INSERT
            //    }
            //    catch (SqlException sqlex)
            //    {
            //        MessageBox.Show("Błąd przy dodawaniu utworu!"
            //               + Environment.NewLine + "opis: " + sqlex.Message.ToString(), "Lista utworów"
            //               , MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Błąd przy dodawaniu utworu!"
            //               + Environment.NewLine + "opis: " + ex.Message.ToString(), "Lista utworów"
            //               , MessageBoxButton.OK, MessageBoxImage.Error);
            //    }

            //    MessageBox.Show("Utwór " + title + " został Dodany.", "Lista utworów", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //else
            //{
            //    MessageBox.Show("Utwór " + title + " nie został dodany. Wypełnij wszystkie pola, lub podany tutył już istnieje", "Lista utworów", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //LocalSQLServerConnection.CloseConnection();
        }

        public static void AddUserToDataBase(string login, string pass1, string pass2, string eemail, RegistrationPage reg)
        {
            Regex regexEmail = new Regex(RegularExpresions.EmailRegex());
            Match matchEmail = regexEmail.Match(eemail);

            try
            {
                using (APlikacjaDoTranspozycjiEntities db = new APlikacjaDoTranspozycjiEntities())
                {
                    if (db.Users.Any(o => o.Login == login))
                    {
                        
                        MessageBox.Show("Podany użytkownik, lub email juz został wykorzystany!", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Error); 
                    }
                    else
                    {
                        Users user = new Users()
                        {
                            Login = login,
                            Password = pass1,
                            email = eemail,

                        };
                        db.Users.Add(user);
                        db.SaveChanges();

                        MessageBox.Show("Użytkownik " + login + " został poprawnie utworzony.", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Information);

                        MainWindow menu = new MainWindow();
                        menu.Show();
                        reg.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            //LocalSQLServerConnection.OpenConnection();
            //LocalSQLServerConnection.sql = "select Top 1 * From Users Where Login='" + login + "' OR email ='" + email + "' ";
            //LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
            //LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
            //LocalSQLServerConnection.da = new SqlDataAdapter(LocalSQLServerConnection.cmd);
            //LocalSQLServerConnection.dt = new DataTable();
            //LocalSQLServerConnection.da.Fill(LocalSQLServerConnection.dt);

            //if (LocalSQLServerConnection.dt.Rows.Count == 0)
            //{
            //    if (pass1 == pass2 && pass1.Length > 7)
            //    {
            //        if (matchEmail.Success)
            //        {
            //            try
            //            {
            //                LocalSQLServerConnection.OpenConnection();
            //                LocalSQLServerConnection.sql = "INSERT INTO Users (Login, Password, email) VALUES ('" + login + "', '" + pass1 + "', '" + email + "')";
            //                LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
            //                LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
            //                LocalSQLServerConnection.cmd.ExecuteNonQuery(); //INSERT
            //                LocalSQLServerConnection.CloseConnection();


            //                LocalSQLServerConnection.OpenConnection();
            //                LocalSQLServerConnection.sql = "SELECT top 1 * FROM Users WHERE Login='" + login + "' AND Password='" + pass1 + "'";
            //                LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
            //                LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
            //                LocalSQLServerConnection.rd = LocalSQLServerConnection.cmd.ExecuteReader();

            //                if (LocalSQLServerConnection.rd.Read())
            //                {
            //                    User.UserID = LocalSQLServerConnection.rd["UserID"].ToString();
            //                    User.Login = LocalSQLServerConnection.rd["Login"].ToString();
            //                    User.Password = LocalSQLServerConnection.rd["Password"].ToString();
            //                    User.Email = LocalSQLServerConnection.rd["email"].ToString();
            //                }
            //                LocalSQLServerConnection.CloseConnection();


            //                MessageBox.Show("Użytkownik " + login + " został poprawnie utworzony.", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Information);

            //                MenuGlowne menu = new MenuGlowne();
            //                menu.Show();
            //                reg.Close();

            //            }
            //            catch (SqlException sqlex)
            //            {
            //                MessageBox.Show("Błąd przy rejestracji!"
            //                       + Environment.NewLine + "opis: " + sqlex.Message.ToString(), "Rejestracja"
            //                       , MessageBoxButton.OK, MessageBoxImage.Error);
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show("Błąd przy rejestracji"
            //                       + Environment.NewLine + "opis: " + ex.Message.ToString(), "Rejestracja"
            //                       , MessageBoxButton.OK, MessageBoxImage.Error);
            //            }


            //        }
            //        else { MessageBox.Show("Niepoprawny adres E-mail!", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Error); }
            //    }
            //    else { MessageBox.Show("Podane hasła nie pasują do siebie, lub są zbyt krótkie (min. 8 znaków)!", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Error); }
            //}
            //else { MessageBox.Show("Podany użytkownik, lub email juz został wykorzystany!", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Error); }

            //LocalSQLServerConnection.CloseConnection();
        }
    }
}

