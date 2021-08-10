using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
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
    /// Logika interakcji dla klasy InstrumentListUserControl.xaml
    /// </summary>
    public partial class InstrumentListUserControl : UserControl
    {
        private InstrumentContext instrumentContext = new InstrumentContext();
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

            // Nie ładuj danych w czasie projektowania.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Tu załaduj swoje dane i przypisz wynik do CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }

            CollectionViewSource instrumentsViewSource = (CollectionViewSource)(this.FindResource("instrumentsViewSource"));
            instrumentContext.Instrument.Load();
            instrumentsViewSource.Source = instrumentContext.Instrument.Local;
        }
    }
}
