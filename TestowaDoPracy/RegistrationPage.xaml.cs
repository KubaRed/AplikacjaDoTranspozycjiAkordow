using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AplikacjaDoTranspozycji.Klasy;
using System.Data.SqlClient;

namespace AplikacjaDoTranspozycji
{
    /// <summary>
    /// Logika interakcji dla klasy RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Window
    {
        public RegistrationPage()
        {
            InitializeComponent();

            PreviewKeyDown += (s, e) =>
            {
                if (e.Key == Key.Escape)
                {
                    MainWindow main = new MainWindow();
                    main.Show();
                    Close();
                }; 
            };

            PreviewKeyDown += (s, e) => { if (e.Key == Key.Enter) RegistrationButton_Click(s, e); }; //Potwierdzenie enterem
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            string password = PasswordBoxReg.Password.ToString();
            string password2 = PasswordBoxReg2.Password.ToString();
            string login = TextBoxUserReg.Text;
            string email = TextBoxEmailReg.Text;
            RegistrationPage registration = new RegistrationPage();
            registration = this;

            AddToDataBase.AddUserToDataBase(login, password, password2, email, registration);
            
        }


        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
