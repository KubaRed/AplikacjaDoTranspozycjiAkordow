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

namespace TestowaDoPracy.UserControls
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
            TextBoxUser.Text = User.Login;
        }

        private void TextBoxTitle_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            MenuGlowne menu = new MenuGlowne();
            menu.Close();

            User.ClearTempData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void PasswordChangeButton_Click(object sender, RoutedEventArgs e)
        {
            bool param = false;

            try
            {
                LocalSQLServerConnection.OpenConnection();

                LocalSQLServerConnection.sql = ("SELECT top 1 * From Users Where Login = '" + TextBoxUser.Text + "' AND Password = '" + TextBoxOldPass.Text + "'");
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
            catch (Exception ex)
            {
                
            }
        }
    }
}
