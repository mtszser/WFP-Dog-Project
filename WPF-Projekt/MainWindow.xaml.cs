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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

       public MainWindow()
       {
            
            InitializeComponent();
            DataContext = this;

            
       }
        private void Login_btn_Click(object sender, RoutedEventArgs e)
        {

            string error = "Login or username are incorrect!";
            string error2 = "Error";

            // Proste logowanie bez użycia profilu w bazie danych.

            if (Username_txt.Text == "Mateusz" && Password_txt.Password == "Serafin")
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Show();
                Close();

            }
            else if (Username_txt.Text == "Juror1" && Password_txt.Password == "123")
            {
                JuniorWindow juniorWindow = new JuniorWindow();
                juniorWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show(error, error2);
            }
        }
    }
}
