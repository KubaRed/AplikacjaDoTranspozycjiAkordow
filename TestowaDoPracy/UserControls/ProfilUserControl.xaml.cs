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
using System.Diagnostics;
using AplikacjaDoTranspozycji.UserControls;

namespace AplikacjaDoTranspozycji.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy ProfilUserControl.xaml
    /// </summary>
    public partial class ProfilUserControl : UserControl
    {
        public ProfilUserControl()
        {
            InitializeComponent();
            MainGrid.Background.Opacity = 0;
        }

        private void TextBoxTitle_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PasswordChangeButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateInDataBase.UpdatePasswordInDataBase(TextBoxOldPass.Text, TextBoxNewPass.Text);

            //try
            //{
            //    LocalSQLServerConnection.OpenConnection();

            //    LocalSQLServerConnection.sql = ("UPDATE Users SET Password = '" + TextBoxNewPass.Text + "' " + " Where Login = '" + TextBoxUser.Text + "' AND Password = '" + TextBoxOldPass.Text + "'"); ;
            //    LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
            //    LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
            //    LocalSQLServerConnection.rd = LocalSQLServerConnection.cmd.ExecuteReader();

            //    if (LocalSQLServerConnection.rd.Read())
            //    {
            //        User.UserID = LocalSQLServerConnection.rd["UserID"].ToString();
            //        User.Login = LocalSQLServerConnection.rd["Login"].ToString();
            //        User.Password = LocalSQLServerConnection.rd["Password"].ToString();
            //        User.Email = LocalSQLServerConnection.rd["email"].ToString();

            //    }

            //    LocalSQLServerConnection.CloseConnection();


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Hasło nie zostało zmienione. Sprawdź poprawność wpisanego starego hasła."
            //                      + Environment.NewLine + "opis: " + ex.Message.ToString(), "Profil"
            //                      , MessageBoxButton.OK, MessageBoxImage.Error);
            //}

            //if (User.Password == TextBoxNewPass.Text)
            //{
            //    MessageBox.Show("Hasło zostało Zmienione.", "Profil", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //else
            //{
            //    MessageBox.Show("Hasło nie zostało zmienione. Sprawdź poprawność wpisanego starego hasła.", "Profil"
            //                      , MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Users user = new Users()
            {
                Login = TemporaryData.Login,
            };

            var menu = Window.GetWindow(this);

            var checkbox = checkBoxRemoveUser;
            if (checkbox.IsVisible == false && checkbox.IsChecked == false)
            {
                checkbox.Visibility = Visibility.Visible;
                VioletBackground.Visibility = Visibility.Visible;

                MessageBox.Show("Czy na pewno chcesz usunąć zalogowanego użytkownika? Jeśli tak to zaznacz 'Tak, chce usunąc użytkownika'.  ", "Usuń użytkownika", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else { DeleteFromDataBase.DeleteUserFromDb(user.Login, menu); }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TextBoxUser.Text = TemporaryData.Login;
            VioletBackground.Visibility = Visibility.Hidden;
            checkBoxRemoveUser.Visibility = Visibility.Hidden;
        }
    }
}
