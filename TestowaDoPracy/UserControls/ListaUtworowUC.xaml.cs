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

namespace AplikacjaDoTranspozycji.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy ListaUtworowUC.xaml
    /// </summary>
    public partial class ListaUtworowUC : UserControl
    {
        public ListaUtworowUC()
        {           
            InitializeComponent();
            MainGrid.Background.Opacity = 0;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (checkBoxAddMelody.IsChecked == true)
            {
                AddToDataBase.AddMelodyIntoDb(TextBoxTitle.Text, TextBoxNotes.Text);
            }
            else if (checkBoxAddChordSong.IsChecked == true)
            {
                AddToDataBase.AddChordSongIntoDb(TextBoxTitle.Text, TextBoxNotes.Text);
            }
            else { MessageBox.Show("Wybierz czy chcesz dodać melodię lub akordy utworu!", "Dodaj utwór", MessageBoxButton.OK, MessageBoxImage.Information); }
        }

        private void CheckBoxAddMelody_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxAddChordSong.IsChecked = false;
            Combobox.FillComboboxMelody(comboBoxChordSong, TemporaryData.UserID);
        }

        private void CheckBoxAddChordSong_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxAddMelody.IsChecked = false;
            Combobox.FillComboboxChordSong(comboBoxChordSong);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
