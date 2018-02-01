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
    public class NinjaFactory : IFactory<Ninja>
    {
        private IOptions<MySqlOptions> MySqlConfig;
        public NinjaFactory(IOptions<MySqlOptions> config)
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

        public void Add(Ninja item)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO ninjas (Name, Level, AssignedDojo, Description, created_at, updated_at) VALUES (@Name, @Level, @AssignedDojo, @Description, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Ninja> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT * FROM ninjas");
            }
        }
        public Ninja FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT * FROM ninjas WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
    }
}