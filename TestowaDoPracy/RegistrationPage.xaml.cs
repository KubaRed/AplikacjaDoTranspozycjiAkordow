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
using TestowaDoPracy.Klasy;
using System.Data.SqlClient;

namespace TestowaDoPracy
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
            //string userID = "b";
            string Password = PasswordBoxReg.Password.ToString();
            string Login = TextBoxUserReg.Text;
            string email = TextBoxEmailReg.Text;
            
            //Sprawdzenie poprawnosci adresu Email.
            Regex regexEmail = new Regex(RegularExpresions.EmailRegex());
            Match matchEmail = regexEmail.Match(email);

            LocalSQLServerConnection.OpenConnection();
            LocalSQLServerConnection.sql = "select Top 1 * From Users Where Login='" + TextBoxUserReg.Text + "' ";
            LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
            LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
            LocalSQLServerConnection.da = new SqlDataAdapter(LocalSQLServerConnection.cmd);
            LocalSQLServerConnection.dt = new DataTable();
       
            LocalSQLServerConnection.da.Fill(LocalSQLServerConnection.dt);

            if (LocalSQLServerConnection.dt.Rows.Count == 0)
            {
                if (PasswordBoxReg.Password == PasswordBoxReg2.Password && PasswordBoxReg.Password.Length > 7)
                {
                    if (matchEmail.Success)
                    {
                        try
                        {
                            LocalSQLServerConnection.OpenConnection();
                            LocalSQLServerConnection.sql = "INSERT INTO Users (Login, Password, email) VALUES ('" + TextBoxUserReg.Text + "', '" + PasswordBoxReg.Password + "', '" + TextBoxEmailReg.Text + "')";
                            LocalSQLServerConnection.cmd.CommandType = CommandType.Text;
                            LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
                            LocalSQLServerConnection.cmd.ExecuteNonQuery(); //INSERT
                            LocalSQLServerConnection.CloseConnection();

                            //LocalSQLServerConnection.OpenConnection();
                            //LocalSQLServerConnection.sql = "SELECT top 1 UserID FROM Users WHERE Login='" + Login + "' AND Password='" + Password + "'";
                            //LocalSQLServerConnection.cmd.CommandText = LocalSQLServerConnection.sql;
                            //LocalSQLServerConnection.rd = LocalSQLServerConnection.cmd.ExecuteReader();
                            //LocalSQLServerConnection.CloseConnection();

                            MessageBox.Show("Użytkownik " + TextBoxUserReg.Text + " został poprawnie utworzony.", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Information);


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
            else { MessageBox.Show("Podany użytkownik już istnieje!", "Rejestracja", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
