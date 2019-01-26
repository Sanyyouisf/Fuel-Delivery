using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FuelDelivery.Models
{
    public class DeliveryStop
    {
        public int deliveryStopId { get; set; }

        public int customerId { get; set; }

        public int deliveryEventId { get; set; }

        public double noOfGallons { get; set; }
    }
}