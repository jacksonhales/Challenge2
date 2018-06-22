using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2.ClassLibrary
{
    public class TourEventView
    {
        private string name;
        private string description;
        private int eventDay;
        private string eventMonth;
        private int eventYear;
        private decimal fee;
        private int eventID;

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


        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
