using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2.ClassLibrary
{
    public class Client
    {
        private int clientID;
        private string firstName;
        private string lastName;
        private string gender;

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public int ClientID
        {
            get { return clientID; }
            set { clientID = value; }
        }

    }
}
