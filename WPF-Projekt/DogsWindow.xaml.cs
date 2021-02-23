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

        public DogsWindow()
        {
            InitializeComponent();
            DataContext = this;
            dogsService = new DogsService(db);
            dogProfileData.ItemsSource = dogsService.GetList();
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
                db.SaveChanges();
                dogProfileData.ItemsSource = dogsService.GetList();
            }
        }

        private void EditBtn(object sender, RoutedEventArgs e)
        {

        }

        private void ReturnBtn(object sender, RoutedEventArgs e)
        {

        }

        private void DogProfileData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
