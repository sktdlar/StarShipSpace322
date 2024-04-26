using StarShip.Pages;
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

namespace StarShip.Components
{
    /// <summary>
    /// Логика взаимодействия для SpaceshipUC.xaml
    /// </summary>
    public partial class SpaceshipUC : UserControl
    {
        Flight flight;
        public SpaceshipUC(Flight _flight)
        {
            InitializeComponent();
            flight = _flight;
            DataContext = flight;
        }

        private void MarshrutBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new RouteInfoPage(flight.Route));
        }
    }
}
