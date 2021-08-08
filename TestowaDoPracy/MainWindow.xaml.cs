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
using TestowaDoPracy.Klasy;
using System.IO;
using System.Data;

namespace TestowaDoPracy
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

            if (File.Exists(@"C:\Users\Public\TranspozycjaApp\Login.txt"))
            {
                string loginR = ReadFromFile.ReadLoginFromFile();
                LoginUser.Text = loginR;
                RememberCheckBox.IsChecked = true;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            DragMove();
        }

        private void LogZalogujButton_Click(object sender, RoutedEventArgs e)
        {
            bool param = false;

            if (LoginUser.Text == "admin" && LoginPass.Password.ToString() == "admin")
            {
                MenuGlowne menuGlowne = new MenuGlowne();
                menuGlowne.Show();
                this.Close();
            }
            else
            {
                try
                {
                    LocalSQLServerConnection.OpenConnection();

                    LocalSQLServerConnection.sql = ("SELECT top 1 * From Users Where Login = '" + LoginUser.Text + "' AND Password = '" + LoginPass.Password + "'");
                    LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
                    LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
                    LocalSQLServerConnection.rd = LocalSQLServerConnection.cmd.ExecuteReader();

                    if (LocalSQLServerConnection.rd.Read())
                    {
                        User.UserID = LocalSQLServerConnection.rd["UserID"].ToString();
                        User.Login = LocalSQLServerConnection.rd["Login"].ToString();
                        User.Password = LocalSQLServerConnection.rd["Password"].ToString();
                        User.Email = LocalSQLServerConnection.rd["email"].ToString();
                        param = true;
                    }
                    
                    LocalSQLServerConnection.CloseConnection();
                }
                finally { if (param == false) { LogowanieExceptionText.Opacity = 100; }
                    else
                    {
                        if (RememberCheckBox.IsChecked == true)
                        {
                            string loginS = Convert.ToString(LoginUser.Text);
                            SaveToFile.SaveLoginToFile(loginS);
                        }
                        else { SaveToFile.DeletLoginFile(); }

                        MenuGlowne menuGlowne = new MenuGlowne();
                        menuGlowne.Show();
                        this.Close();
                    }
                }
            }
            //else { LogowanieExceptionText.Opacity = 100; }

            //TemporaryData.Login = LogowanieUser.Text;
            //TemporaryData.Password = LogowaniePass.Password.ToString();

        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RegistrationPage registrationPage = new RegistrationPage();
            registrationPage.Show();
            this.Close();
        }


        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    RegistrationPage rp = new RegistrationPage();
        //    this.Close();
        //    rp.Show();
        //}


    }
}
