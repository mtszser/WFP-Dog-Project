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
using WPF_Projekt.Classes;

namespace WPF_Projekt
{
    /// <summary>
    /// Interaction logic for Highscore.xaml
    /// </summary>
    public partial class Highscore : Window
    {
        public Highscore()
        {
            InitializeComponent();
            DogsBaseEntities db = new DogsBaseEntities();
            dogsService = new DogsService(db);
            HighscoreGrid.ItemsSource = dogsService.GetHighscoreList();
        }
        DogsService dogsService;

        private void HighScoresReturnbtn(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void HighscoreGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
