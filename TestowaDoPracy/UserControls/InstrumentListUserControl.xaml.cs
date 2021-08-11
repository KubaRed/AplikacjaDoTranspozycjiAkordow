using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
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
    /// Logika interakcji dla klasy InstrumentListUserControl.xaml
    /// </summary>
    public partial class InstrumentListUserControl : UserControl
    {
        public InstrumentListUserControl()
        {
            InitializeComponent();
            MainGrid.Background.Opacity = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddToDataBase.AddInstrumentToDb(TextBoxInstrumentName.Text, TextBoxKey.Text);
        }

        private void Button_Click_Usun(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBoxAddMelody_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBoxAddChordSong_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            Combobox.FillComboBoxInstrument(comboBoxInstrument);
        
        }

    } 
}
