using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2.ClassLibrary
{
    public class Booking
    {
        private int bookingID;
        private decimal payment;
        private DateTime dateBooked;
        private int clientID;
        private int eventID;

        public int EventID
        {
            get { return eventID; }
            set { eventID = value; }
        }

        public int ClientID
        {
            get { return clientID; }
            set { clientID = value; }
        }

        public DateTime DateBooked
        {
            get { return dateBooked; }
            set { dateBooked = value; }
        }

        public decimal Payment
        {
            get { return payment; }
            set { payment = value; }
        }

        public int BookingID
        {
            get { return bookingID; }
            set { bookingID = value; }
        }

    }
}
