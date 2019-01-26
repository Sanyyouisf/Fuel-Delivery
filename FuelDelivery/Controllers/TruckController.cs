using FuelDelivery.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FuelDelivery.Controllers
{

    [RoutePrefix("api/Truck")]
    public class TruckController : ApiController
    {
        [HttpGet, Route("")]
        public HttpResponseMessage Get()
        {
            try
            {
                var TruckData = new TruckDataAccess();
                var AllTruckList = TruckData.GetAllTrucks();
                return Request.CreateResponse(HttpStatusCode.OK, AllTruckList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}
