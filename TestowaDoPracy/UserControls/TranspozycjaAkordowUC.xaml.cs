﻿using System;
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

namespace TestowaDoPracy.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy TranspozycjaAkordowUC.xaml
    /// </summary>
    public partial class TranspozycjaAkordowUC : UserControl
    {
        public TranspozycjaAkordowUC()
        {
            InitializeComponent();

            comboBoxAkordy.Visibility = Visibility.Hidden;
            comboBoxAkordyWynik.Visibility = Visibility.Hidden;
            stackPanelStrojPoczatkowy.Visibility = Visibility.Hidden;
            stackPanelStrojWynik.Visibility = Visibility.Hidden;
            MainGrid.Background.Opacity = 0;
        }

        private void CheckBoxInstrument_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxStroj.IsChecked = false;

            comboBoxAkordy.Visibility = Visibility.Visible;
            comboBoxAkordyWynik.Visibility = Visibility.Visible;

        }

        private void CheckBoxInstrument_Unchecked(object sender, RoutedEventArgs e)
        {
            comboBoxAkordy.Visibility = Visibility.Hidden;
            comboBoxAkordyWynik.Visibility = Visibility.Hidden;
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
    }
}
