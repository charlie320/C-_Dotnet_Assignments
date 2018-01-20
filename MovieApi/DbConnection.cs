
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using MySqlOpt;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
 
namespace DbConnection
{

    public class DbConnector
    {

        private readonly IOptions<MySqlOptions> MySqlConfig;
 
        public DbConnector(IOptions<MySqlOptions> config)
        {
            MySqlConfig = config;
        }
        internal IDbConnection Connection {
            get {
                return new MySqlConnection(MySqlConfig.Value.ConnectionString);
            }
        }
        
        //This method runs a query and stores the response in a list of dictionary records
        public List<Dictionary<string, object>> Query(string queryString)
        {
            using(IDbConnection dbConnection = Connection)
            {
                using(IDbCommand command = dbConnection.CreateCommand())
                {
                   command.CommandText = queryString;
                   dbConnection.Open();
                   var result = new List<Dictionary<string, object>>();
                   using(IDataReader rdr = command.ExecuteReader())
                   {
                      while(rdr.Read())
                      {
                          var dict = new Dictionary<string, object>();
                          for( int i = 0; i < rdr.FieldCount; i++ ) {
                              dict.Add(rdr.GetName(i), rdr.GetValue(i));
                          }
                          result.Add(dict);
                      }
                   }
                   return result;
                }
            }
        }

        public List<Dictionary<string,object>> Create(string title, double vote_avg, string rel_date) {
            // string queryString = "INSERT INTO movies (title, vote_average, release_date, created_at, updated_at) VALUES (\"" + title + "\", \"" + vote_avg + "\", " + rel_date + ", NOW(), NOW())";
            string queryString = "INSERT INTO movies (title, vote_average, release_date, created_at, updated_at) VALUES (\"" + title + "\", \"" + vote_avg + "\", \"" + rel_date + "\", NOW(), NOW())";
            
            Console.WriteLine(queryString);
            using(IDbConnection dbConnection = Connection)
            {
                using(IDbCommand command = dbConnection.CreateCommand())
                {
                   command.CommandText = queryString;
                   dbConnection.Open();
                   var result = new List<Dictionary<string, object>>();
                   using(IDataReader rdr = command.ExecuteReader())
                   {
                      while(rdr.Read())
                      {
                          var dict = new Dictionary<string, object>();
                          for( int i = 0; i < rdr.FieldCount; i++ ) {
                              dict.Add(rdr.GetName(i), rdr.GetValue(i));
                          }
                          result.Add(dict);
                      }

                      
                    //   Console.WriteLine(Read());
                    //   return result;
                    return result;                    
                    }
                }
            }        
        }


        //This method run a query and returns no values
        public void Execute(string queryString)
        {
            using (IDbConnection dbConnection = Connection)
            {
                using(IDbCommand command = dbConnection.CreateCommand())
                {
                    command.CommandText = queryString;
                    dbConnection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}