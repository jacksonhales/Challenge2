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

        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public Clients()
        {
            InitializeComponent();
        }

        private void dgrClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if(dgrClients.SelectedItem != null)
                {
                    selectedClient = (Client)dgrClients.SelectedItem;
                    txtFirstName.Text = selectedClient.FirstName;
                    txtLastName.Text = selectedClient.LastName;
                    txtGender.Text = selectedClient.Gender;
                }
                
            }
            catch (Exception ex)
            {
                logger.Fatal("Unknown error");
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnCreate.IsEnabled = false;
                btnUpdate.IsEnabled = true;
                btnDelete.IsEnabled = true;
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await LoadClientGrid();
            }
            catch (Exception ex)
            {
                logger.Fatal("Unknown error");
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnUpdate.IsEnabled = false;
                btnDelete.IsEnabled = false;
            }
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // First Name validation
                if (String.IsNullOrEmpty(txtFirstName.Text))
                {
                    throw new ValidationFailureException("First Name field empty, please enter a first name and retry.");
                }
                if (txtFirstName.Text.Any(t => char.IsDigit(t)))
                {
                    throw new ValidationFailureException("First Name contains numbers, please remove any numbers from the first name field and retry.");
                }
                // Last Name validation
                if (String.IsNullOrEmpty(txtLastName.Text))
                {
                    throw new ValidationFailureException("Last Name field empty, please enter a last name and retry.");
                }
                if (txtLastName.Text.Any(t => char.IsDigit(t)))
                {
                    throw new ValidationFailureException("Last Name contains numbers, please remove any numbers from the last name field and retry.");
                }
                // Gender validation
                if (String.IsNullOrEmpty(txtGender.Text))
                {
                    throw new ValidationFailureException("Gender field empty, please enter a gender and retry.");
                }
                if (txtGender.Text != "M" && txtGender.Text != "F")
                {
                    throw new ValidationFailureException("There are only two genders, please input M or F and retry.");
                }

                client = new APIClient();

                Client newClient = new Client()
                {
                    ClientID = await client.GetNextClientID(),
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Gender = txtGender.Text
                };
                await client.CreateClient(newClient);

            }
            catch (ValidationFailureException ex)
            {
                logger.Debug("ValidationFailureException");
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                logger.Fatal("Unknown error");
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dgrClients.UnselectAll();

                txtFirstName.Text = null;
                txtLastName.Text = null;
                txtGender.Text = null;

                await LoadClientGrid();
            }
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                // First Name validation
                if (String.IsNullOrEmpty(txtFirstName.Text))
                {
                    throw new ValidationFailureException("First Name field empty, please enter a first name and retry.");
                }
                if (txtFirstName.Text.Any(t => char.IsDigit(t)))
                {
                    throw new ValidationFailureException("First Name contains numbers, please remove any numbers from the first name field and retry.");
                }
                // Last Name validation
                if (String.IsNullOrEmpty(txtLastName.Text))
                {
                    throw new ValidationFailureException("Last Name field empty, please enter a last name and retry.");
                }
                if (txtLastName.Text.Any(t => char.IsDigit(t)))
                {
                    throw new ValidationFailureException("Last Name contains numbers, please remove any numbers from the last name field and retry.");
                }
                // Gender validation
                if (String.IsNullOrEmpty(txtGender.Text))
                {
                    throw new ValidationFailureException("Gender field empty, please enter a gender and retry.");
                }
                if (txtGender.Text != "M" && txtGender.Text != "F")
                {
                    throw new ValidationFailureException("There are only two genders, please input M or F and retry.");
                }

                client = new APIClient();

                Client updatedClient = new Client()
                {
                    ClientID = selectedClient.ClientID,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Gender = txtGender.Text
                };
                await client.UpdateClient(updatedClient);
                await LoadClientGrid();
            }
            catch (ValidationFailureException ex)
            {
                logger.Debug("ValidationFailureException");
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                logger.Fatal("Unknown error");
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dgrClients.UnselectAll();

                btnCreate.IsEnabled = true;
                btnUpdate.IsEnabled = false;
                btnDelete.IsEnabled = false;

                txtFirstName.Text = null;
                txtLastName.Text = null;
                txtGender.Text = null;
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                client = new APIClient();
                await client.DeleteClientBookings(selectedClient.ClientID);
                await client.DeleteClient(selectedClient);
            }
            catch (Exception ex)
            {
                logger.Fatal("Unknown error");
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dgrClients.UnselectAll();

                txtFirstName.Text = null;
                txtLastName.Text = null;
                txtGender.Text = null;

                btnCreate.IsEnabled = true;
                btnUpdate.IsEnabled = false;
                btnDelete.IsEnabled = false;

                await LoadClientGrid();
            }

        }

        private async Task LoadClientGrid()
        {
            try
            {
                client = new APIClient();
                clientList = await client.GetClients();
                dgrClients.ItemsSource = clientList;
            }
            catch (Exception ex)
            {
                logger.Fatal("Unknown error");
                MessageBox.Show(ex.Message);
            }
        }
    }
}
