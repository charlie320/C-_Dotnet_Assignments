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
                string query =  "INSERT INTO ninjas (Name, Level, Description, dojos_id, created_at, updated_at) VALUES (@Name, @Level, @Description, @dojos_id, NOW(), NOW())";
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

        public IEnumerable<Ninja> FindAllWithDojo()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Ninja>("SELECT * FROM ninjas JOIN dojos WHERE ninjas.dojos_id = dojos.dojo_id");
            }
        }

        public IEnumerable<Ninja> FindAllWithDojoNull()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                // return dbConnection.Query<Ninja>("SELECT * FROM ninjas WHERE ninjas.dojos_id is NULL");
                return dbConnection.Query<Ninja>("SELECT * FROM ninjas WHERE ninjas.dojos_id = 0");
            }
        }

        public Ninja FindById(int id){
            using (IDbConnection dbConnection = Connection){
                string query = $"SELECT * FROM ninjas WHERE(ninja_id={id})";
                dbConnection.Open();
                return dbConnection.Query<Ninja>(query, new{ninja_id = id}).FirstOrDefault();
            }
        }

        public Dojo FindNinjaDojo(int id) {
           using (IDbConnection dbConnection = Connection){
                string query = $"SELECT * FROM dojos WHERE(dojo_id={id})";
                dbConnection.Open();
                return dbConnection.Query<Dojo>(query, new{dojo_id = id}).FirstOrDefault();
            }
        }

        public IEnumerable<Dojo> FindAllDojos() {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Dojo>("SELECT * FROM dojos");
            }
        }

        public IEnumerable<Ninja> NinjasForDojoById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var query = $"SELECT * FROM ninjas FULL JOIN dojos ON ninjas.dojos_id WHERE dojos.dojo_id = ninjas.dojos_id AND dojos.dojo_id = {id}";
                dbConnection.Open();
        
                var myNinjas = dbConnection.Query<Ninja, Dojo, Ninja>(query, (ninja, dojo) => { ninja.dojo = dojo; return ninja; });
                return myNinjas;
            }
        }
    }
}