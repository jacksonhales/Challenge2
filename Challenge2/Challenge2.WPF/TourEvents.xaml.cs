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
    /// Interaction logic for TourEvents.xaml
    /// </summary>

    public partial class TourEvents : Page
    {

        APIClient client;
        List<Tour> allTours;
        List<TourEvent> allTourEvents;
        List<TourEventView> tourEventsView;
        List<Client> allClients;
        List<Booking> allBookings;
        TourEventView selectedTourEventView;

        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public TourEvents()
        {
            InitializeComponent();
            DataContext = this;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                client = new APIClient();

                allTours = await client.GetTours();
                allTourEvents = await client.GetTourEvents();
                allClients = await client.GetClients();
                allBookings = await client.GetBookings();

                tourEventsView = (from t in allTours
                                  join te in allTourEvents
                                  on t.TourID equals te.TourID
                                  select new TourEventView
                                  {
                                      Name = t.Name,
                                      Description = t.Description,
                                      EventDay = te.EventDay,
                                      EventMonth = te.EventMonth,
                                      EventYear = te.EventYear,
                                      Fee = te.Fee,
                                      EventID = te.EventID
                                  }).ToList();

                dgrTourEvents.ItemsSource = tourEventsView;
            }
            catch (Exception ex)
            {
                logger.Fatal("Unknown error.");
                MessageBox.Show(ex.Message);
            }
        }

        private void dgrTourEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if(dgrTourEvents.SelectedItem != null)
                {
                    selectedTourEventView = (TourEventView)dgrTourEvents.SelectedItem;
                }

                var bookingsList = from c in allClients
                                   join b in allBookings on c.ClientID equals b.ClientID
                                   where b.EventID == selectedTourEventView.EventID
                                   select new
                                   {
                                       c.FirstName,
                                       c.LastName,
                                       c.Gender,
                                       b.DateBooked,
                                       b.Payment
                                   };
                dgrTourEventBookings.ItemsSource = bookingsList;
            }
            catch (Exception ex)
            {
                logger.Fatal("Unknown error.");
                MessageBox.Show(ex.Message);
            }
        }
    }
}
