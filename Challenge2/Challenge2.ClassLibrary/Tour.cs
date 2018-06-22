using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2.ClassLibrary
{
    public class Tour
    {
        private int tourID;
        private string name;
        private string description;

        public int TourID
        {
            get { return tourID; }
            set { tourID = value; }
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
