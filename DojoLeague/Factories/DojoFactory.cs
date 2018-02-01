using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using DojoLeague.Models;
using Microsoft.Extensions.Options;
using DbConnection;

namespace DojoLeague.Factory
{
    public class DojoFactory : IFactory<Dojo>
    {
        private IOptions<MySqlOptions> MySqlConfig;
        public DojoFactory(IOptions<MySqlOptions> config)
        {
            MySqlConfig = config;
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(MySqlConfig.Value.ConnectionString);
            }
        }

        //USERFACTORY CLASS DEFINITION
 
        public void Add(Dojo item)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO dojos (DojoName, DojoLocation, DojoInfo, created_at, updated_at) VALUES (@DojoName, @DojoLocation, @DojoInfo, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Dojo> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Dojo>("SELECT * FROM dojos");
            }
        }
        public Dojo FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Dojo>("SELECT * FROM dojos WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
    }
}
