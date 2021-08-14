using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace AplikacjaDoTranspozycji.Klasy
{
    class Combobox
    {
        public static void FillComboBoxInstrument(ComboBox comboBox, int userId)
        {
            try
            {
                using (APlikacjaDoTranspozycjiEntities db = new APlikacjaDoTranspozycjiEntities())
                {
                    comboBox.ItemsSource = db.Instruments.Where(i => i.UserID == userId || i.UserID == 36).ToList();
                    comboBox.SelectedValuePath = "InstrumentID";
                    comboBox.DisplayMemberPath = "InstrumentName";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static void FillComboboxMelody(ComboBox combobox, int userId)
        {

            try
            {
                using (APlikacjaDoTranspozycjiEntities db = new APlikacjaDoTranspozycjiEntities())
                {

                    combobox.ItemsSource = db.Songs.Where(i => i.UserID == userId || i.UserID == 36).ToList();
                    combobox.SelectedValuePath = "Notes";
                    combobox.DisplayMemberPath = "Title";
                }

                //    LocalSQLServerConnection.OpenConnection();

                //LocalSQLServerConnection.sql = "SELECT * FROM Songs Where UserID=" + User.UserID;
                //LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
                //LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
                //LocalSQLServerConnection.rd = LocalSQLServerConnection.cmd.ExecuteReader();

                //while (LocalSQLServerConnection.rd.Read())
                //{
                //    Melody melody= new Melody
                //    {
                //        ID = LocalSQLServerConnection.rd.GetInt32(0),
                //        Title = LocalSQLServerConnection.rd.GetString(2),
                //        Notes = LocalSQLServerConnection.rd.GetString(3)
                //    };
                //    combobox.Items.Add(melody);
                //}
            

                //LocalSQLServerConnection.CloseConnection();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Błąd przy dodawaniu utworu!"
                            + Environment.NewLine + "opis: " + ex.Message.ToString(), "ComboBox"
                            , MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        public static void FillComboboxChordSong(ComboBox combobox, int userId)
        {

            try
            {
                using (APlikacjaDoTranspozycjiEntities db = new APlikacjaDoTranspozycjiEntities())
                {
                    combobox.ItemsSource = db.ChordSongs.Where(i => i.UserID == userId || i.UserID == 36).ToList();
                    combobox.SelectedValuePath = "Chord";
                    combobox.DisplayMemberPath = "Title";
                }

                //LocalSQLServerConnection.OpenConnection();

                //LocalSQLServerConnection.sql = "SELECT * FROM ChordSongs Where UserID=" + User.UserID;
                //LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
                //LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
                //LocalSQLServerConnection.rd = LocalSQLServerConnection.cmd.ExecuteReader();

                //while (LocalSQLServerConnection.rd.Read())
                //{
                //    ChordSong chord = new ChordSong
                //    {
                //        ID = LocalSQLServerConnection.rd.GetInt32(0),
                //        Title = LocalSQLServerConnection.rd.GetString(2),
                //        Chord = LocalSQLServerConnection.rd.GetString(3)
                //    };
                //    combobox.Items.Add(chord);
                //}


                //LocalSQLServerConnection.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd przy dodawaniu utworu!"
                            + Environment.NewLine + "opis: " + ex.Message.ToString(), "ComboBox"
                            , MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        //public static void FillComboboxInstrument(ComboBox combobox)
        //{

        //    try
        //    {
        //        LocalSQLServerConnection.OpenConnection();

        //        LocalSQLServerConnection.sql = "SELECT * FROM Instruments Where UserID=" + User.UserID;
        //        LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
        //        LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
        //        LocalSQLServerConnection.rd = LocalSQLServerConnection.cmd.ExecuteReader();

        //        while (LocalSQLServerConnection.rd.Read())
        //        {
        //            Instrument instrument = new Instrument
        //            {
        //                ID = LocalSQLServerConnection.rd.GetInt32(0),
        //                Name = LocalSQLServerConnection.rd.GetString(2),
        //                Key = LocalSQLServerConnection.rd.GetString(3)
        //            };
        //            combobox.Items.Add(instrument);
        //        }


        //        LocalSQLServerConnection.CloseConnection();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Błąd przy dodawaniu utworu!"
        //                    + Environment.NewLine + "opis: " + ex.Message.ToString(), "ComboBox"
        //                    , MessageBoxButton.OK, MessageBoxImage.Error);
        //    }

        //}
    }
}
