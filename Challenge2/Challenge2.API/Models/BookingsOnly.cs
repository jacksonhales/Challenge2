//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Challenge2.API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookingsOnly
    {
        public int bookingID { get; set; }
        public decimal payment { get; set; }
        public System.DateTime dateBooked { get; set; }
        public int clientID { get; set; }
        public int eventID { get; set; }
    }
}