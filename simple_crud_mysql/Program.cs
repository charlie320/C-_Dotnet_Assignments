using System;
using System.Collections.Generic;
using DbConnection;
using System.Json;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace simple_crud_mysql
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<Dictionary<string,object>> allUsers = DbConnector.Read();
            string output = JsonConvert.SerializeObject(allUsers);
            // Console.WriteLine(output);

            DbConnector.Create();

            // List<Dictionary<string, object>> myQuery = DbConnector.Query("SELECT first_name, favorite_number FROM users");
            // foreach (Dictionary<string,object> dict in myQuery) {
            //     foreach (KeyValuePair<string,object> entry in dict) {
            //         Console.WriteLine(entry.Key + " " + entry.Value);
            //     }
            // }

        }
    }
}
