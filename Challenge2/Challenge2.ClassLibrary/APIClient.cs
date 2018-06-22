using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2.ClassLibrary
{
    public class APIClient
    {
        public async Task<List<TourEvent>> GetTourEvents()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://challenge2.azurewebsites.net/api/");

            HttpResponseMessage response = await client.GetAsync("toureventsonly");

            var content = await response.Content.ReadAsStringAsync();

            List<TourEvent> tourEvents = JsonConvert.DeserializeObject<List<TourEvent>>(content);

            return tourEvents;
        }

        public async Task<List<Tour>> GetTours()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://challenge2.azurewebsites.net/api/");

            HttpResponseMessage response = await client.GetAsync("toursonly");

            var content = await response.Content.ReadAsStringAsync();

            List<Tour> tourEvents = JsonConvert.DeserializeObject<List<Tour>>(content);

            return tourEvents;
        }

        public async Task<List<Booking>> GetBookings()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://challenge2.azurewebsites.net/api/");

            HttpResponseMessage response = await client.GetAsync("bookingsonly");

            var content = await response.Content.ReadAsStringAsync();

            List<Booking> tourBookings = JsonConvert.DeserializeObject<List<Booking>>(content);

            return tourBookings;
        }

        public async Task<List<Client>> GetClients()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://challenge2.azurewebsites.net/api/");

            HttpResponseMessage response = await client.GetAsync("clientsonly");

            var content = await response.Content.ReadAsStringAsync();

            List<Client> tourClients = JsonConvert.DeserializeObject<List<Client>>(content);

            return tourClients;
        }
    }
}
