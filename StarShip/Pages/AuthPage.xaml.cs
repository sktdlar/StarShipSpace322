using StarShip.Components;
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

namespace StarShip.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        List<Passenger> passes;
        public AuthPage()
        {
            InitializeComponent();
            GetUsers();
        }

        private void PassportTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public async Task GetUsers()
        {
            passes = await Task.Run(() =>  App.db.Passenger.ToList());
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach(var item in passes)
            {
                if (item.Pasport_Number == int.Parse(PassportTB.Text))
                {
                    NavigationService.Navigate(new ListSpaceship(item));
                }
            }
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegPage(new Passenger()));
        }

        private void GuestBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ViewFlightDGPage());
        }
    }
}
