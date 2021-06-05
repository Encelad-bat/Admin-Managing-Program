using Admin_Managing_Program.Model;
using Admin_Managing_Program.ViewModel;
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

namespace Admin_Managing_Program.View
{
    /// <summary>
    /// Логика взаимодействия для Admin_Panel.xaml
    /// </summary>
    public partial class Admin_Panel : UserControl
    {
        public Admin_Panel()
        {
            InitializeComponent();
            Model.Model.connection = "Data Source = SQL5097.site4now.net; Initial Catalog = db_a7538c_main; User Id = db_a7538c_main_admin; Password = Gorb_bc24";
            this.DataContext = new Car_ViewModel();
        }

        private void add_Button_Click(object sender, RoutedEventArgs e)
        {
            bool correct_data = true;
            Car car = new Car();
            car.Name = name_TextBox.Text;
            car.Color = color_TextBox.Text;
            if(int.TryParse(year_TextBox.Text,out int year))
            {
                car.Year = year;
            }
            else
            {
                correct_data = false;
                MessageBox.Show("Was inputed incorrect data!", "Incorrect year!", MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            if (correct_data)
            {
                Model.Model.Create_Object((object)car, typeof(Car));
            }
            Car_ViewModel.Cars.Add(car);
        }

        private void edit_Button_Click(object sender, RoutedEventArgs e)
        {
            if(cars_ListView.SelectedItem != null)
            {
                bool correct_data = true;
                Car car = new Car();
                car.Id = (cars_ListView.SelectedItem as Car).Id;
                car.Name = name_TextBox.Text;
                car.Color = color_TextBox.Text;
                if (int.TryParse(year_TextBox.Text, out int year))
                {
                    car.Year = year;
                }
                else
                {
                    correct_data = false;
                    MessageBox.Show("Was inputed incorrect data!", "Incorrect year!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                if (correct_data)
                {
                    Model.Model.Update_Objects((object)car, typeof(Car));
                }
                Car_ViewModel.Cars[Car_ViewModel.Cars.IndexOf(cars_ListView.SelectedItem as Car)] = car;
            }
        }

        private void delete_Button_Click(object sender, RoutedEventArgs e)
        {
            Model.Model.Delete_Objects(cars_ListView.SelectedItem, typeof(Car));
            Car_ViewModel.Cars.Remove(cars_ListView.SelectedItem as Car);
        }
    }
}
