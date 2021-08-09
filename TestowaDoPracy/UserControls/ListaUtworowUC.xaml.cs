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

namespace TestowaDoPracy.UserControls
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
            SongListDb.InsertSongIntoDb(TextBoxTitle.Text, TextBoxNotes.Text);
        }


    }
}
