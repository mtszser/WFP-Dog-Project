using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
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
    /// Interaction logic for AddDog1.xaml
    /// </summary>
    public partial class AddDog : Window
    {
        string errorbox = "Error";
        string newdog = "New Dog";


        public AddDog()
        {
            InitializeComponent();
            DogsBaseEntities db = new DogsBaseEntities();
            dogsService = new DogsService(db);
            AddDogDG.ItemsSource = dogsService.GetDogList();

        }
        DogsBaseEntities db = new DogsBaseEntities();
        DogsService dogsService;

        private void AddNewDog(object sender, RoutedEventArgs e)
        {
            int parsedInput;
            if (DogName_txt.Text == "")
            {
                MessageBox.Show("Please enter the dog's name", errorbox);
            }
            else if (DogBreed_txt.Text == "")
            {
                MessageBox.Show("Please enter the dog's breed", errorbox);
            }
            else if (DogOwner_txt.Text == "")
            {
                MessageBox.Show("Please enter  the dog's owner id", errorbox);
            }
            else if (!int.TryParse(DogOwner_txt.Text, out parsedInput))
            {
                MessageBox.Show("Dogs owner ID must be numeric", errorbox);
                return;
            }
            else
            {

                int ownerinput = int.Parse(DogOwner_txt.Text);
                DogsBaseEntities db = new DogsBaseEntities();
                //DogsOwner dogsOwner = new DogsOwner();
                //var ownerid = db.DogsOwners.Single(o => ownerinput == o.Owner_id);

                Dog dogs = new Dog()
                {

                    Name = DogName_txt.Text,
                    Breed = DogBreed_txt.Text,
                    Owner_id = ownerinput,
                    
                };
                
                db.Dogs.Add(dogs);
                db.SaveChanges();
                MessageBox.Show("Dog added successfully!", newdog);
                AddDogDG.ItemsSource = dogsService.GetDogList();
                DogName_txt.Text = String.Empty;
                DogBreed_txt.Text = String.Empty;
                DogOwner_txt.Text = String.Empty;
            }

        }



        private void ReturnBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddDogDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void DogName_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void DogBreed_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void DogOwner_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
