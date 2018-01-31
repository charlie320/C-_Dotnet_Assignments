using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using LostInWoods.Models;
using Microsoft.Extensions.Options;
using MySqlOpt;
using DbConnection;
 
namespace LostInWoods.Factory
{
    public class TrailFactory : IFactory<Trail>
    {

        private IOptions<MySqlOptions> MySqlConfig;
 
        public TrailFactory(IOptions<MySqlOptions> config)
        {
            MySqlConfig = config;
        }

        internal IDbConnection Connection {
            get {
                return new MySqlConnection(MySqlConfig.Value.ConnectionString);
            }
        }

        // private string connectionString;
        // public TrailFactory()
        // {
        //     connectionString = "server=localhost;userid=root;password=root;port=8889;database=LostWoodsDB;SslMode=None";
        // }
        // internal IDbConnection Connection
        // {
        //     get {
        //         return new MySqlConnection(connectionString);
        //     }
        // }

        //USERFACTORY CLASS DEFINITION
 
        public void Add(Trail item)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO trails (TrailName, Description, TrailLength, ElevationChange, Longitude, LongitudeHemisphere, Latitude, LatitudeHemisphere, created_at, updated_at) VALUES (@TrailName, @Description, @TrailLength, @ElevationChange, @Longitude, @LongitudeHemisphere, @Latitude, @LatitudeHemisphere, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Trail> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT* FROM trails");
            }
        }
        public Trail FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM trails WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
    }
}