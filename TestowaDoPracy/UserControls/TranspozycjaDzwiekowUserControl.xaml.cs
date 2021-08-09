using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Data;
using System.Data.SqlClient;




namespace TestowaDoPracy.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy TranspozycjaDzwiekowUserControl.xaml
    /// </summary>
    public partial class TranspozycjaDzwiekowUserControl : UserControl
    {
        public TranspozycjaDzwiekowUserControl()
        {
            InitializeComponent();

            comboBoxInstrument.Visibility = Visibility.Hidden;
            comboBoxInstrumentWynik.Visibility = Visibility.Hidden;
            stackPanelStrojPoczatkowy.Visibility = Visibility.Hidden;
            stackPanelStrojWynik.Visibility = Visibility.Hidden;
            MainGrid.Background.Opacity = 0;

            Combobox.FillComboboxMelody(comboBoxMelodie);
            Combobox.FillComboboxInstrument(comboBoxInstrument);
            Combobox.FillComboboxInstrument(comboBoxInstrumentWynik);
        }

        private void CheckBoxInstrument_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxStroj.IsChecked = false;

            comboBoxInstrument.Visibility = Visibility.Visible;
            comboBoxInstrumentWynik.Visibility = Visibility.Visible;
        }

        private void CheckBoxInstrument_Unchecked(object sender, RoutedEventArgs e)
        {
            comboBoxInstrument.Visibility = Visibility.Hidden;
            comboBoxInstrumentWynik.Visibility = Visibility.Hidden;
        }

        private void CheckBoxStroj_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxInstrument.IsChecked = false;

            stackPanelStrojPoczatkowy.Visibility = Visibility.Visible;
            stackPanelStrojWynik.Visibility = Visibility.Visible;
        }

        private void CheckBoxStroj_Unchecked(object sender, RoutedEventArgs e)
        {
            stackPanelStrojPoczatkowy.Visibility = Visibility.Hidden;
            stackPanelStrojWynik.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var checkedButtonFirst = stackPanelStrojPoczatkowy.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked.Value);
            var checkedButtonSecond = stackPanelStrojWynik.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked.Value);


            Instrument instrument = comboBoxInstrument.SelectedItem as Instrument;
            Console.WriteLine(instrument.Name);

            try
            {
                TextBoxAfter.Text = NoteTransposition.TranspositionFromNote(TextBoxBefore.Text, CheckRadioButton.CheckRadioButtons(checkedButtonFirst.Name, checkedButtonSecond.Name));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie wybrano metody lub stroju potrzebnego do przeprowadzenia transpozycji!"
                                       + Environment.NewLine + "opis: " + ex.Message.ToString(), "Transpozycja Dźwięków."
                                       , MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
