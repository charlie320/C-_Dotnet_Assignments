using System;
using System.Collections.Generic;
using DbConnection;

namespace simple_crud_mysql
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // List<Dictionary<string, object>> myQuery = DbConnector.Query("SELECT first_name, favorite_number FROM users");
            // foreach (Dictionary<string,object> dict in myQuery) {
            //     foreach (KeyValuePair<string,object> entry in dict) {
            //         Console.WriteLine(entry.Key + " " + entry.Value);
            //     }
            // }


            Console.WriteLine("Please provide some input.");
            string InputLine = Console.ReadLine();
            Console.WriteLine("Here is the input you provided:  {0}", InputLine);
        }
    }
}
