using System;
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

        public Dojo FindByID(int Id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Dojo>("SELECT * FROM dojos WHERE dojo_id = @Id", new { dojo_id = Id }).FirstOrDefault();
            }
        }

        public Dojo FindByIdWithNinjas(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var query =
                @"
                SELECT * FROM dojos WHERE dojo_id = @id;
                SELECT * FROM ninjas WHERE dojos_id = @id;
                ";
        
                using (var multi = dbConnection.QueryMultiple(query, new {Id = id}))
                {
                    var dojo = multi.Read<Dojo>().Single();
                    dojo.ninjas = multi.Read<Ninja>().ToList();
                    return dojo;
                }
            }
        }

        public IEnumerable<Ninja> GetRogueNinjas() {
            using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    return dbConnection.Query<Ninja>("SELECT * FROM ninjas WHERE dojos_id = 0");
                }
        }

        public void BanishNinja(int id){
            using (IDbConnection dbConnection = Connection){
                // var query = $"UPDATE ninjas SET dojos_id = NULL WHERE ninjas.ninja_id = {id}";
                var query = $"UPDATE ninjas SET dojos_id = 0 WHERE ninjas.ninja_id = {id}";                
                dbConnection.Open();
                dbConnection.Execute(query);
            }
        }

        public void RecruitNinja(int dojo_id, int ninja_id){
            using (IDbConnection dbConnection = Connection){
                var query = $"UPDATE ninjas SET dojos_id = {dojo_id} WHERE ninjas.ninja_id = {ninja_id}";
                dbConnection.Open();
                dbConnection.Execute(query);
            }
        }
    }
}
