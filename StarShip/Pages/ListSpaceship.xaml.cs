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
    /// Логика взаимодействия для ListSpaceship.xaml
    /// </summary>
    public partial class ListSpaceship : Page
    {

        private Passenger passenger;

        public ListSpaceship(Passenger _passenger)
        {
            InitializeComponent();
            passenger = _passenger;
            planetCb.Items.Add("По умолчанию");
            foreach(var item in App.db.Planet.ToList())
            {
                planetCb.Items.Add(item);
            }
            planetCb.DisplayMemberPath = "Name";
            Refresh();
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
        }

        private void TroublesBtns_Click(object sender, RoutedEventArgs e)
        {
/*            NavigationService.Navigate(new TroublesPage());*/
        }

        void Refresh()
        {
            WP.Children.Clear();
            if (planetCb.SelectedIndex <= 0)
            {
                foreach (var item in App.db.Flight.ToList())
                {
                    WP.Children.Add(new SpaceshipUC(item));
                }
            }
            else
            {
                var selplanet = planetCb.SelectedItem as Planet;
                foreach(var item in App.db.Route.Where(x => x.Planet1Id == ((Planet)planetCb.SelectedItem).id)){
                    foreach (var item1 in App.db.Flight.Where(x => x.RouteId == item.id))
                    {
                        WP.Children.Add(new SpaceshipUC(item1));
                    }

                }
            }
        }

        private void planetCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void FindBestRoute_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FIndBestRoutePage());
        }
    }
}
