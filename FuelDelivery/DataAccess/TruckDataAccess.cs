using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using FuelDelivery.Models;
using Dapper;

namespace FuelDelivery.DataAccess
{

    public class TruckDataAccess
    {
        public List<Truck> GetAllTrucks()
        {
            using ( var Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["FuelDelivery"].ConnectionString))
            {
                Connection.Open();
                var result = Connection.Query <Truck>("Select * from dbo.Truck");
                return result.ToList();
            }
        }
    }
}