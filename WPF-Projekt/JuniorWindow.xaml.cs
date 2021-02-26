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
    /// Interaction logic for JuniorWindow.xaml
    /// </summary>
    public partial class JuniorWindow : Window
    {

        public JuniorWindow()
        {
            InitializeComponent();
            DogsBaseEntities db = new DogsBaseEntities();
            dogsService = new DogsService(db);
            NewScoreGrid.ItemsSource = db.Scores.ToList();
        }
        DogsService dogsService;



        private void ReturnJunior(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void NewScore(object sender, RoutedEventArgs e)
        {
            int juroridparse;
            int jurorid;
            int dogidparse;
            int dogoutfitparse;
            int dogspeedparse;
            int dogfocusparse;

            if (!int.TryParse(JurorID_txt.Text, out juroridparse))
            {
                MessageBox.Show("Juror ID must be numeric!");
                return;
            }
            else if (JurorID_txt.Text == "")
            {
                MessageBox.Show("Please enter a juror id!");
            }

            jurorid = int.Parse(JurorID_txt.Text);
            
            if (jurorid > 3 || jurorid < 1)
            {
                MessageBox.Show("There are 3 jurors! John #1, Mateusz #2, Rick #3.");
            }
            else if (!int.TryParse(DogId_txt.Text, out dogidparse))
            {
                MessageBox.Show("Dog ID must be numeric!");
                return;
            }
            else if (DogId_txt.Text == "")
            {
                MessageBox.Show("Please enter a dog id!");
            }
            else if (!int.TryParse(DogOutfit_txt.Text, out dogoutfitparse))
            {
                MessageBox.Show("Score for OUTFIT must be numeric!");
                return;
            }
            else if (DogOutfit_txt.Text == "")
            {
                MessageBox.Show("You have to write a OUTFIT SCORE!");
            }
            else if (dogoutfitparse < 0 || dogoutfitparse > 10)
            {
                MessageBox.Show("You have to type a number between 0-10!");
            }
            else if (!int.TryParse(DogSpeed_txt.Text, out dogspeedparse))
            {
                MessageBox.Show("Score for OUTFIT must be numeric!");
                return;
            }
            else if (DogSpeed_txt.Text == "")
            {
                MessageBox.Show("You have to write a OUTFIT SCORE!");
            }
            else if (dogspeedparse < 0 || dogspeedparse > 10)
            {
                MessageBox.Show("You have to type a number between 0-10!");
            }
            else if (!int.TryParse(DogFocus_txt.Text, out dogfocusparse))
            {
                MessageBox.Show("Score for OUTFIT must be numeric!");
                return;
            }
            else if (DogFocus_txt.Text == "")
            {
                MessageBox.Show("You have to write a OUTFIT SCORE!");
            }
            else if (dogoutfitparse < 0 || dogoutfitparse > 10)
            {
                MessageBox.Show("You have to type a number between 0-10!");
            }
            else
            {
                int dogid = int.Parse(DogId_txt.Text);
                int dogoutfit = int.Parse(DogOutfit_txt.Text);
                int dogspeed = int.Parse(DogSpeed_txt.Text);
                int dogfocus = int.Parse(DogFocus_txt.Text);
                int total = 0;
                total += dogoutfit + dogspeed + dogfocus;
                DogsBaseEntities db = new DogsBaseEntities();
                Score score = new Score();
                {
                    score.Outfit = dogoutfit;
                    score.Speed = dogspeed;
                    score.Focus = dogfocus;
                    score.Total = total;
                    score.Dog_id = dogid;
                    score.Juror_id = jurorid;
                }
                db.Scores.Add(score);
                db.SaveChanges();
                MessageBox.Show("Score added succesfully");
                NewScoreGrid.ItemsSource = db.Scores.ToList();

            }


        }

        private void DogId_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DeleteScorebtn(object sender, RoutedEventArgs e)
        {
            DogsBaseEntities db = new DogsBaseEntities();
            int scoreID;

            if (!int.TryParse(DeleteScoreID.Text, out scoreID))
            {
                MessageBox.Show("Score ID must be numeric!");
                return;
            }
            else if (DeleteScoreID.Text == "")
            {
                MessageBox.Show("Please enter Score ID!");
            }
            else if (scoreID <= 0)
            {
                MessageBox.Show("There is no score with that ID");
            }
            else
            {
                Score score = new Score();
                var deletescore =
                    from Score in db.Scores
                    where Score.Score_id == scoreID
                    select Score;

                foreach (var Score in deletescore)
                {
                    db.Scores.Remove(Score);
                }
                MessageBox.Show("Score deleted successfully!");
                db.SaveChanges();
                NewScoreGrid.ItemsSource = db.Scores.ToList();
                DeleteScoreID.Text = String.Empty;
            }
        }

    }
}
