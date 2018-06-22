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
        List<TourEventView> tourEventsView;
        public TourEvents()
        {
            InitializeComponent();
            DataContext = this;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            client = new APIClient();

            List<Tour> allTours = await client.GetTours();
            List<TourEvent> allTourEvents = await client.GetTourEvents();

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

        private async void dgrTourEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            TourEventView selectedTourEventView = (TourEventView)dgrTourEvents.SelectedItem;

            client = new APIClient();

            List<Client> allClients = await client.GetClients();
            List<Booking> allBookings = await client.GetBookings();

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
    }
}
