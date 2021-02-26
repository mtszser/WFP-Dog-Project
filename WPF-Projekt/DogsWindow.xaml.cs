using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
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
    /// Logika interakcji dla klasy DogsWindow.xaml
    /// </summary>
    public partial class DogsWindow : Window
    {
        string errorbox = "Error";
        string done = "Success";
        

        public DogsWindow()
        {
            InitializeComponent();
            DogsBaseEntities db = new DogsBaseEntities();
            dogsService = new DogsService(db);
            dogProfileData.ItemsSource = dogsService.GetDogList();

        }
        DogsBaseEntities db = new DogsBaseEntities();
        DogsService dogsService;

        private void DeleteBtn(object sender, RoutedEventArgs e)
        {
            DogsBaseEntities db = new DogsBaseEntities();
            int dogID;

            if (!int.TryParse(ID_txt.Text, out dogID))
            {
                MessageBox.Show("Dog ID must be numeric", errorbox);
                return;
            }
            else if (dogID <= 0)
            {
                MessageBox.Show("There is no Dog with that id: " + dogID, errorbox);
            }
            else
            {
                Dog dogs = new Dog();
                var deletedog =
                    from Dog in db.Dogs
                    where Dog.Id == dogID
                    select Dog;
                //// delete dog by id in ID_txt
                foreach (var Dog in deletedog)
                {
                    db.Dogs.Remove(Dog);
                }
                MessageBox.Show("Dog deleted successfully!", done);
                db.SaveChanges();
                dogProfileData.ItemsSource = dogsService.GetDogList();
                ID_txt.Text = String.Empty;
            }

            
        }

        private void EditBtn(object sender, RoutedEventArgs e)
        {
            DogsBaseEntities db = new DogsBaseEntities();
            int editDogID;
            int parsedID;

            if (!int.TryParse(EditID_txt.Text, out editDogID))
            {
                MessageBox.Show("Dog ID must be numeric", errorbox);
                return;
            }
            else if (editDogID <= 0)
            {
                MessageBox.Show("There is no Dog with that id: " + editDogID, errorbox);
            }
            else if (EditDogName_txt.Text == "")
            {
                MessageBox.Show("Please enter the dog's name", errorbox);
            }
            else if (EditDogBreed_txt.Text == "")
            {
                MessageBox.Show("Please enter the dog's breed", errorbox);
            }
            else if (EditDogOwner_txt.Text == "")
            {
                MessageBox.Show("Please enter  the dog's owner id", errorbox);
            }
            else if (!int.TryParse(EditDogOwner_txt.Text, out parsedID))
            {
                MessageBox.Show("Dogs owner ID must be numeric", errorbox);
                return;
            }
            else
            {

                Dog dogs = new Dog();
                //var updateDog =
                //    from Dog in db.Dogs
                //    where Dog.Id == dogID
                //    select Dog;
                
                var updateDog = db.Dogs.Where(d => d.Id == editDogID).FirstOrDefault();

                updateDog.Name = EditDogName_txt.Text;
                updateDog.Breed = EditDogBreed_txt.Text;
                updateDog.Owner_id = parsedID;


                MessageBox.Show("Dog edited.", done);
                db.SaveChanges();
                Close();
                DogsWindow dogsWindow = new DogsWindow();
                dogsWindow.ShowDialog();

            }
        }

        private void ReturnBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DogProfileData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }


        private void EditID_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
