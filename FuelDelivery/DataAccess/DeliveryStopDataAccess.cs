using FuelDelivery.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Web.Http;

namespace FuelDelivery.DataAccess
{
    public class DeliveryStopDataAccess
    {
        public List<DeliveryStop> GetAllDeliveryStops()
        {
            using (var Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FuelDelivery"].ConnectionString))
            {
                Connection.Open();
                var result = Connection.Query<DeliveryStop>("Select * from dbo.DeliveryStop");
                return result.ToList();
            }
        }

//-------------------------------------------------------
        public IEnumerable<dynamic> GetAvgfuelconsumptionPerCustomer()
        {
            using (var Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FuelDelivery"].ConnectionString))
            {
                Connection.Open();
                var result = Connection.Query("Select C.customerName as 'Customer Name'," +
                                              "AVG(DS.noOfGallons) as 'Average Fuel Consumption'" +
                                              "from FuelDelivery.dbo.DeliveryStop DS " +
                                              "left Join FuelDelivery.dbo.customer C " +
                                              "ON DS.CustomerID = C.customerId " +
                                              "left join FuelDelivery.dbo.DeliveryEvent DE " +
                                              "ON DS.deliveryEventId = DE.deliveryEventId " +
                                              "WHERE MONTH(DE.eventDate) = Month(GETDATE()) AND YEAR(DE.eventDate) = YEAR(GETDATE()) " +
                                              "GROUP BY C.CustomerName " +
                                              "ORDER BY 'Customer Name'");
                return result.ToList();
            }
        }
//-------------------------------------------------------
        // add new stop data 
        public int AddNewStopSata(DeliveryStop deliveryStop)
        {
            using (var Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FuelDelivery"].ConnectionString))
            {
                Connection.Open();
                var result = Connection.ExecuteScalar<int>(@"INSERT INTO [dbo].[DeliveryStop]([customerId],[deliveryEventId],[noOfGallons])
                                                             VALUES (@customerId, @deliveryEventId, @noOfGallons)"
                                                            , deliveryStop);
                return result;
            }
        }

//--------------------------------------------------------
        // check the current fuel level for today
        public string CurrentFuelLevel()
        {
            using (var Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FuelDelivery"].ConnectionString))
            {
                var sql = "Select Sum(DS.noOfGallons) " +
                                                  "from dbo.DeliveryStop DS " +
                                                  "Left Join dbo.DeliveryEvent DE " +
                                                  "on DS.DeliveryEventId = DE.DeliveryEventId " +
                                                  "WHERE DAY(DE.eventDate) = DAY(GETDATE())AND " +
                                                  "MONTH(DE.eventDate) = Month(GETDATE()) AND " +
                                                  "YEAR(DE.eventDate) = YEAR(GETDATE()) AND " +
                                                  "DE.truckId = 1";
                SqlCommand cmd = new SqlCommand(sql, Connection);
                Connection.Open();
                int current = Convert.ToInt32(cmd.ExecuteScalar());
                Connection.Close();
                int TotalCapacity = 40000;
                int Percetage = (current * 100) / TotalCapacity;
                return Percetage.ToString();
            }
        }



    }
}