using Challenge2.ClassLibrary;
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

namespace Challenge2.WPF
{
    /// <summary>
    /// Interaction logic for Clients.xaml
    /// </summary>
    public partial class Clients : Page
    {
        APIClient client;
        List<Client> clientList;

        public Clients()
        {
            InitializeComponent();
        }

        private void dgrClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            client = new APIClient();

            List<Client> allClients = await client.GetClients();

            dgrClients.ItemsSource = allClients;
        }
    }
}
