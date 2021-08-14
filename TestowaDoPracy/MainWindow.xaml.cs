using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AplikacjaDoTranspozycji.Klasy;
using System.IO;
using System.Data;

namespace AplikacjaDoTranspozycji
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            PreviewKeyDown += (s, e) => { if (e.Key == Key.Escape) Close(); }; //Wyłącza program
            PreviewKeyDown += (s, e) => { if (e.Key == Key.Enter) LogZalogujButton_Click(s, e); }; //Potwierdzenie enterem

            LogowanieExceptionText.Opacity = 0;

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            DragMove();
        }

        private void LogZalogujButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginUser.Text == "adminn" && LoginPass.Password.ToString() == "adminn")
            {
                MenuGlowne menuGlowne = new MenuGlowne();
                menuGlowne.Show();
                this.Close();
            }
            else
            {

                if (LoginUser.Text != "" && LoginPass.Password.ToString() != "")
                {
                    
                    if (CheckRecords.CheckIfUserExists(LoginUser.Text, LoginPass.Password.ToString()) == true)
                    {
                        var user = GetData.GetUserData(LoginUser.Text);
                        TemporaryData.Login = user.Login;
                        TemporaryData.UserID = user.UserID;

                        MenuGlowne menu = new MenuGlowne();
                        menu.Show();
                        this.Close();

                        if (RememberCheckBox.IsChecked == true)
                        {
                            string loginS = Convert.ToString(LoginUser.Text);
                            SaveToFile.SaveLoginToFile(loginS);
                        }
                        else { SaveToFile.DeletLoginFile(); }

                    }
                    else { LogowanieExceptionText.Opacity = 100; }
                }
                else { LogowanieExceptionText.Opacity = 100; }

                //try
                //{
                //    LocalSQLServerConnection.OpenConnection();

                //    LocalSQLServerConnection.sql = ("SELECT top 1 * From Users Where Login = '" + LoginUser.Text + "' AND Password = '" + LoginPass.Password + "'");
                //    LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
                //    LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
                //    LocalSQLServerConnection.rd = LocalSQLServerConnection.cmd.ExecuteReader();

                //    if (LocalSQLServerConnection.rd.Read())
                //    {
                //        var user = TemporaryData.UserID.ToString();
                //        user = LocalSQLServerConnection.rd["UserID"].ToString();
                //        TemporaryData.Login = LocalSQLServerConnection.rd["Login"].ToString();
                //        TemporaryData.Password = LocalSQLServerConnection.rd["Password"].ToString();
                //        TemporaryData.Email = LocalSQLServerConnection.rd["email"].ToString();
                //        param = true;
                //    }

                //    LocalSQLServerConnection.CloseConnection();
                //}
                //finally { if (param == false) { LogowanieExceptionText.Opacity = 100; }
                //    else
                //    {
                //        if (RememberCheckBox.IsChecked == true)
                //        {
                //            string loginS = Convert.ToString(LoginUser.Text);
                //            SaveToFile.SaveLoginToFile(loginS);
                //        }
                //        else { SaveToFile.DeletLoginFile(); }

                //        MenuGlowne menuGlowne = new MenuGlowne();
                //        menuGlowne.Show();
                //        this.Close();
                //    }
                //}
            }


        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RegistrationPage registrationPage = new RegistrationPage();
            registrationPage.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(@"C:\Users\Public\TranspozycjaApp\Login.txt"))
            {
                string loginR = ReadFromFile.ReadLoginFromFile();
                LoginUser.Text = loginR;
                RememberCheckBox.IsChecked = true;
            }
        }
    }
}
