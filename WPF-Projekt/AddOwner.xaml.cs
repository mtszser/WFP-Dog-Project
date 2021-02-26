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
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class AddOwner : Window
    {
        string errorbox = "Error";
        string newowner = "New Owner";
        public AddOwner()
        {
            InitializeComponent();
            DogsBaseEntities db = new DogsBaseEntities();
            dogsService = new DogsService(db);
            OwnerProfile.ItemsSource = dogsService.GetOwnerList();
        }
        DogsService dogsService;
        DogsBaseEntities db = new DogsBaseEntities();


        private void AddOwner_Click(object sender, RoutedEventArgs e)
        {
            int age;
            if (OwnerName_txt.Text == "")
            {
                MessageBox.Show("Please enter new owner name", errorbox);
            }
            else if (OwnerSurname_txt.Text == "")
            {
                MessageBox.Show("Please enter new owner surname", errorbox);
            }
            else if (OwnerCity_txt.Text == "")
            {
                MessageBox.Show("Please enter new owner city", errorbox);
            }
            else if (OwnerPhone_txt.Text == "")
            {
                MessageBox.Show("Please enter new owner PhoneNumber", errorbox);
            }
            else if (OwnerPhone_txt.Text.Length >=10)
            {
                MessageBox.Show("Phone number can not be longer than 9 digits!");
            }
            
            else if (!int.TryParse(OwnerAge_txt.Text, out age))
            {
                MessageBox.Show("Owner Age must be numeric", errorbox);
                return;
            }
            else
            {
                int parsedAge = int.Parse(OwnerAge_txt.Text);



                DogsBaseEntities db = new DogsBaseEntities();
                DogsOwner dogsOwner = new DogsOwner();
                dogsOwner.Name = OwnerName_txt.Text;
                dogsOwner.Surname = OwnerSurname_txt.Text;
                dogsOwner.Age = parsedAge;
                dogsOwner.City = OwnerCity_txt.Text;
                dogsOwner.PhoneNumber = OwnerPhone_txt.Text;
                dogsService.AddOwner(dogsOwner);
                MessageBox.Show("New Owner added successfully!", newowner);
                OwnerProfile.ItemsSource = dogsService.GetOwnerList();



                //DogsOwner dogsOwner = new DogsOwner();
                //{
                //    dogsOwner.Name = OwnerName_txt.Text;
                //    dogsOwner.Surname = OwnerSurname_txt.Text;
                //    dogsOwner.Age = parsedAge;
                //    dogsOwner.City = OwnerCity_txt.Text;
                //    dogsOwner.PhoneNumber = OwnerPhone_txt.Text;
                //}
                //db.DogsOwners.Add(dogsOwner);
                //db.SaveChanges();
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ReturnOwnerBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OwnerDelete(object sender, RoutedEventArgs e)
        {
            Dog dogs = new Dog();
            DogsBaseEntities db = new DogsBaseEntities();
            int ownerID;
            if (!int.TryParse(delOwnerID.Text, out ownerID))
            {
                MessageBox.Show("Owner ID must be numeric!");
                return;
            }
            else if (delOwnerID.Text == "")
            {
                MessageBox.Show("Please enter Owner ID!");
            }
            else if (ownerID <= 0)
            {
                MessageBox.Show("There is no owner with that ID");
            }
            else
            {
                DogsOwner dogsOwner = new DogsOwner();
                var deleteOwner =
                    from DogsOwner in db.DogsOwners
                    where DogsOwner.Owner_id == ownerID
                    select DogsOwner;


                foreach (var DogsOwner in deleteOwner)
                {
                    db.DogsOwners.Remove(DogsOwner);
                }
                MessageBox.Show("Owner deleted successfully");
                db.SaveChanges();
                OwnerProfile.ItemsSource = dogsService.GetOwnerList();
                delOwnerID.Text = String.Empty;

            }
            

        }
            
        
    }
}

