using FuelDelivery.DataAccess;
using FuelDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Dapper;

namespace FuelDelivery.Controllers
{
    //[RoutePrefix("api/DeliveryStop")]
    public class DeliveryStopController : ApiController
    {
        [HttpGet, Route("api/DeliveryStop")]
        [ResponseType(typeof(DeliveryStop))]
        public HttpResponseMessage Get()
        {
            try
            {
                var stopData = new DeliveryStopDataAccess();
                var AllDeliveryStopList = stopData.GetAllDeliveryStops();
                return Request.CreateResponse(HttpStatusCode.OK, AllDeliveryStopList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

//---------------------------------------------------------------------------
        [HttpGet, Route("api/DeliveryStop/Total")]
        [ResponseType(typeof(DeliveryStop))]
        public HttpResponseMessage GetGallonNumberForCustomer()
        {
            try
            {
                var stop = new DeliveryStopDataAccess();
                var AvgConsumption = stop.GetAvgfuelconsumptionPerCustomer();
                return Request.CreateResponse(HttpStatusCode.OK, AvgConsumption);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

        }
//------------------------------------------------------------------------------
        //save each stop data
        [HttpPost, Route("api/DeliveryStop/new")]
        public HttpResponseMessage AddNewStop(DeliveryStop deliveryStop)
        {
            try
            {
                var newStop = new DeliveryStopDataAccess();
                var newRow = newStop.AddNewStopSata(deliveryStop);
                return Request.CreateResponse(HttpStatusCode.OK, "New stop added ");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

//--------------------------------------------------------------------------------
        // get the current fuel level 

        [HttpGet, Route("api/DeliveryStop/CurrentLevel")]
        [ResponseType(typeof(DeliveryStop))]
        public HttpResponseMessage CurrentFuelLevel()
        {
            try
            {
                var stop = new DeliveryStopDataAccess();
                var percentage = stop.CurrentFuelLevel();
                return Request.CreateResponse(HttpStatusCode.OK, "%"+percentage);
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
