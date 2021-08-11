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
using AplikacjaDoTranspozycji.Klasy;
using System.Data;
using System.Data.SqlClient;




namespace AplikacjaDoTranspozycji.UserControls
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

           
            

            this.comboBoxMelodie.SelectionChanged += new SelectionChangedEventHandler(OnMyComboBoxChanged);
        }

        private void OnMyComboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            Melody melody = comboBoxMelodie.SelectedItem as Melody;

            TextBoxBefore.Text = melody.Notes;
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

            bool cbf = stackPanelStrojPoczatkowy.Children.OfType<RadioButton>().Any(r => r.IsChecked.Value);
            bool cbs = stackPanelStrojWynik.Children.OfType<RadioButton>().Any(r => r.IsChecked.Value);

        
            Instruments instrument = comboBoxInstrument.SelectedItem as Instruments;
            Instruments instrument2 = comboBoxInstrumentWynik.SelectedItem as Instruments;

            try
            {
                if (checkBoxInstrument.IsChecked == true && instrument != null && instrument2 != null)
                {
                    TextBoxAfter.Text = NoteTransposition.TranspositionFromNote(TextBoxBefore.Text, CheckSelectedInstruments.CheckKeyOfSelectedInstruments(instrument.InstrumentKey, instrument2.InstrumentKey));

                }
                else if (checkBoxStroj.IsChecked == true && cbf == true && cbs == true)
                {
                    TextBoxAfter.Text = NoteTransposition.TranspositionFromNote(TextBoxBefore.Text, CheckRadioButton.CheckRadioButtons(checkedButtonFirst.Name, checkedButtonSecond.Name));
                }
                else { MessageBox.Show("Nie wybrano stroju lub instrumentu względem którego ma być poddana transpozycja", "Transpozycja dźwięków", MessageBoxButton.OK, MessageBoxImage.Information); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie wybrano metody lub stroju potrzebnego do przeprowadzenia transpozycji!"
                                       + Environment.NewLine + "opis: " + ex.Message.ToString(), "Transpozycja Dźwięków."
                                       , MessageBoxButton.OK, MessageBoxImage.Error);
            }
        
        }

        private void Combobox_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Melody melody = comboBoxMelodie.SelectedItem as Melody;
            TextBoxBefore.Text = melody.Notes;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Combobox.FillComboboxMelody(comboBoxMelodie);
            Combobox.FillComboBoxInstrument(comboBoxInstrument);
            Combobox.FillComboBoxInstrument(comboBoxInstrumentWynik);
        }
    }
}
