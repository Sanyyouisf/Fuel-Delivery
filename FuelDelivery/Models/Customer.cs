using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FuelDelivery.Models
{
    public class Customer
    {
        public int customerId { get; set; }

        public int regionId { get; set; }

        public string customreName { get; set; }

        public string customreAddress { get; set; }

        public double maxNoOfGallons { get; set; }
    }
}