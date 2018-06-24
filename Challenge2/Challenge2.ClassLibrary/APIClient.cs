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

        public async Task CreateClient(Client pNewClient)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://challenge2.azurewebsites.net/api/");

            string newClientJSON = JsonConvert.SerializeObject(pNewClient, Formatting.None);

            var content = new StringContent(newClientJSON, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("clients", content);

        }

        public async Task<int> GetNextClientID()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://challenge2.azurewebsites.net/api/");

            HttpResponseMessage response = await client.GetAsync("clientsonly");

            var content = await response.Content.ReadAsStringAsync();

            List<Client> tourClients = JsonConvert.DeserializeObject<List<Client>>(content);

            return tourClients.Max(c => c.ClientID) + 1;
        }

        public async Task DeleteClient(Client pClientToDelete)
        {

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://challenge2.azurewebsites.net/api/");

            string clientToDeleteJSON = JsonConvert.SerializeObject(pClientToDelete, Formatting.None);

            var content = new StringContent(clientToDeleteJSON, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.DeleteAsync("clients/" + pClientToDelete.ClientID);

        }

        public async Task DeleteClientBookings(int pClientID)
        {

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://challenge2.azurewebsites.net/api/");

            List<Booking> bookingsToDelete = await GetBookingsByClientID(pClientID);

            foreach (Booking b in bookingsToDelete)
            {
                string bookingToDeleteJSON = JsonConvert.SerializeObject(b, Formatting.None);
                var content = new StringContent(bookingToDeleteJSON, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.DeleteAsync("bookings/" + b.BookingID);
            }
        }

        public async Task<List<Booking>> GetBookingsByClientID(int pClientID)
        {
            List<Booking> allBookings = await GetBookings();

            List<Booking> clientBookings = new List<Booking>();

            return clientBookings = allBookings.Where(b => b.ClientID == pClientID).ToList();
        }

        public async Task UpdateClient(Client pClientToUpdate)
        {

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://challenge2.azurewebsites.net/api/");

            string clientToUpdateJSON = JsonConvert.SerializeObject(pClientToUpdate, Formatting.None);

            var content = new StringContent(clientToUpdateJSON, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync("clients/" + pClientToUpdate.ClientID, content);

        }

    }
}
