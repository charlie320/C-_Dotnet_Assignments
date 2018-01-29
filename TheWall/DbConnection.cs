// DbConnector without static
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using MySqlOpt;
using TheWall.Models;

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

        public List<Dictionary<string,object>> Create(string first_name, string last_name, string email, string password) {
            string queryString = "INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) VALUES (\"" + first_name + "\", \"" + last_name + "\", \"" + email + "\", \"" + password + "\", NOW(), NOW())";
            
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

                    return result;                    
                    }
                }
            }
        }

        public List<Dictionary<string,object>> CreateMessage(string messageText, int userId) {
            string queryString = $"INSERT INTO messages (message, created_at, updated_at, users_id) VALUES (\"{messageText}\", NOW(), NOW(), {userId})";            
            
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

                    return result;                    
                    }
                }
            }
        }

        // public string DeleteMessage(int messageId) {
        //     string queryString = $"DELETE FROM messages WHERE (\"id\" = {messageId})";
        //     Console.WriteLine($"Inside the DeleteMessage method and messageId = {messageId}");
        //     using(IDbConnection dbConnection = Connection)
        //     {
        //             IDbCommand command = dbConnection.CreateCommand();
        //             command.CommandText = queryString;
        //             dbConnection.Open();
        //             Console.WriteLine($"CommandText = {command.CommandText}");
        //             command.ExecuteNonQuery();
        //     }
        //     return $"Successfully deleted message {messageId}";
        // }

        public List<Dictionary<string,object>> CreateComment(string commentText, int userId, int messageId) {
            string queryString = $"INSERT INTO comments (comment, created_at, updated_at, messages_id, users_id) VALUES (\"{commentText}\", NOW(), NOW(), {messageId}, {userId})";            
            
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