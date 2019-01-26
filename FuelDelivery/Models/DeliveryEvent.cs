using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FuelDelivery.Models
{
    public class DeliveryEvent
    {
        public int deliveryEventId { get; set; }

        public int truckId { get; set; }

        public DateTime eventDate { get; set; }
    }
}