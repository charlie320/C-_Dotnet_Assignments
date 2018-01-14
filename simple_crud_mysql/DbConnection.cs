using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
 
namespace DbConnection
{
    public class DbConnector
    {
        static string server = "localhost";
        static string db = "consoleDB"; //Change to your schema name
        static string port = "3306"; //Potentially 8889
        static string user = "root";
        static string pass = "root";
        internal static IDbConnection Connection {
            get {
                return new MySqlConnection($"Server={server};Port={port};Database={db};UserID={user};Password={pass};SslMode=None");
            }
        }
        
        //This method runs a query and stores the response in a list of dictionary records
        public static List<Dictionary<string, object>> Query(string queryString)
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
                      return result;
                                      }
                }
            }
        }

        // Read function that displays all current users when app starts and after every insert
        //This method runs a query and stores the response in a list of dictionary records

        
        public static List<Dictionary<string, object>> Read()
        {
            string readString = "SELECT * FROM users";
            using(IDbConnection dbConnection = Connection)
            {
                using(IDbCommand command = dbConnection.CreateCommand())
                {
                   command.CommandText = readString;
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
                      Console.WriteLine(JsonConvert.SerializeObject(result));
                      return result;                
                    }
                }
            }
        }

        // This method accepts input and creates a new user
        public static List<Dictionary<string, object>> Create()
        {
            string first_name;
            string last_name;
            string num_string;
            int fav_number;

            Console.WriteLine("Please enter the user's first name:  ");
            first_name = Console.ReadLine();
            Console.WriteLine("Please enter the user's last name:  ");
            last_name = Console.ReadLine();
            Console.WriteLine("Please enter the user's favorite number:  ");
            num_string = (Console.ReadLine());
            fav_number = Convert.ToInt32(num_string);

            // string queryString = "INSERT INTO users (first_name, last_name, favorite_number, created_at, updated_at) VALUES ('Joan', 'Doe', 5, NOW(), NOW())";
            string queryString = "INSERT INTO users (first_name, last_name, favorite_number, created_at, updated_at) VALUES (\"" + first_name + "\", \"" + last_name + "\", " + fav_number + ", NOW(), NOW())";
            // Console.WriteLine(queryString);

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
                      Console.WriteLine(Read());
                      return result;                    
                    }
                }
            }
        }
        
        //This method run a query and returns no values
        public static void Execute(string queryString)
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
