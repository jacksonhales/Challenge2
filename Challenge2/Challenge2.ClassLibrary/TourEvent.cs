using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2.ClassLibrary
{
    public class TourEvent
    {
        private int eventID;
        private int eventDay;
        private string eventMonth;
        private int eventYear;
        private decimal fee;
        private int tourID;

        public int TourID
        {
            get { return tourID; }
            set { tourID = value; }
        }
        public int EventID
        {
            get { return eventID; }
            set { eventID = value; }
        }

        public decimal Fee
        {
            get { return fee; }
            set { fee = value; }
        }


        public int EventYear
        {
            get { return eventYear; }
            set { eventYear = value; }
        }


        public string EventMonth
        {
            get { return eventMonth; }
            set { eventMonth = value; }
        }


        public int EventDay
        {
            get { return eventDay; }
            set { eventDay = value; }
        }

    }
}
