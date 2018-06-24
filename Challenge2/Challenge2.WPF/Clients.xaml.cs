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
        Client selectedClient;

        public Clients()
        {
            InitializeComponent();
        }

        private void dgrClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedClient = (Client)dgrClients.SelectedItem;

            txtFirstName.Text = selectedClient.FirstName;
            txtLastName.Text = selectedClient.LastName;
            txtGender.Text = selectedClient.Gender;

            btnCreate.IsEnabled = false;
            btnUpdate.IsEnabled = true;
            btnDelete.IsEnabled = true;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;

            await LoadClientGrid();
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            client = new APIClient();

            Client newClient = new Client()
            {
                ClientID = await client.GetNextClientID(),
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Gender = txtGender.Text
            };

            await client.CreateClient(newClient);

            txtFirstName.Text = null;
            txtLastName.Text = null;
            txtGender.Text = null;

            LoadClientGrid();
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            client = new APIClient();

            Client updatedClient = new Client()
            {
                ClientID = selectedClient.ClientID,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Gender = txtGender.Text
            };

            await client.UpdateClient(updatedClient);

            txtFirstName.Text = null;
            txtLastName.Text = null;
            txtGender.Text = null;

            LoadClientGrid();
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            client = new APIClient();


            await client.DeleteClientBookings(selectedClient.ClientID);
            await client.DeleteClient(selectedClient);

            txtFirstName.Text = null;
            txtLastName.Text = null;
            txtGender.Text = null;

            LoadClientGrid();

        }

        private async Task LoadClientGrid()
        {
            
            client = new APIClient();

            clientList = await client.GetClients();
            dgrClients.ItemsSource = clientList;
            
        }

        private void btnRefreshGrid_Click(object sender, RoutedEventArgs e)
        {
            dgrClients.Items.Refresh();
        }
    }
}
