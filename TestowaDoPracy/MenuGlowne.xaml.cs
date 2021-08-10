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
using System.Windows.Shapes;
using AplikacjaDoTranspozycji.Klasy;

namespace AplikacjaDoTranspozycji
{
    /// <summary>
    /// Logika interakcji dla klasy MenuGlowne.xaml
    /// </summary>
    public partial class MenuGlowne : Window
    {
        readonly UserControl chord = new UserControls.TranspozycjaAkordowUC();
        readonly UserControl songList = new UserControls.ListaUtworowUC();
        readonly UserControl sound = new UserControls.TranspozycjaDzwiekowUserControl();
        readonly UserControl profil = new UserControls.ProfilUserControl();
        readonly UserControl instrument = new UserControls.InstrumentListUserControl();
        readonly UserControl test = new UserControls.Test();


        public MenuGlowne()
        {
            InitializeComponent();

            PreviewKeyDown += (s, e) => { if (e.Key == Key.Escape) Close(); }; //Wyłącza program
            GridControls.Children.Add(sound);

            UserIdLabel.Text += User.Login;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GridControls.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "TranspozycjaAkordow":
                    GridControls.Children.Add(chord);
                    break;
                case "DodajUtwor":
                    GridControls.Children.Add(songList);
                    break;
                case "DodajInstrument":
                    GridControls.Children.Add(instrument);
                    break;
                case "TranspozycjaDzwiekow":
                    GridControls.Children.Add(sound);
                        break;
                case "Test":
                    GridControls.Children.Add(test);
                    break;
                default:
                    GridControls.Children.Add(sound);
                    break;
            }
        }

        private void WylogujButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();

            //User.ClearTempData();
        }

        private void ProfilButton_Click(object sender, RoutedEventArgs e)
        {
            GridControls.Children.Clear();
            GridControls.Children.Add(profil);
            
        }
    }
}
