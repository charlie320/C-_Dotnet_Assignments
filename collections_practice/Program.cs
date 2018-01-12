using System;
using System.Collections.Generic;

namespace collections_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // int [] intArr = new int[10];
            // Boolean truth = false;
            // foreach (int num in intArr) {
            //     if (truth == true) {
            //         truth = false;
            //         Console.WriteLine(truth);
            //     } else {
            //         truth = true;
            //         Console.WriteLine(truth);
            //     }
            // }

            string [] stringArr = new string[4] {"Tim", "Martin", "Nikki", "Sara"};
            // foreach (string name in stringArr) {
            //     Console.WriteLine(name);
            // }

            // int[,] multArr = new int[10,10];
            // for (int i = 1; i <= 10; i++) {
            //     for (int j = 1; j <= 10; j++) {
            //         multArr[i-1,j-1] = i * j;
            //         Console.Write("{0,3}  ", multArr[i-1,j-1]);
            //     }
            //     Console.WriteLine("\n");
            // }

            List<string> flavors = new List<string>();
            flavors.Add("Vanilla");
            flavors.Add("Chocolate");
            flavors.Add("Butter Pecan");
            flavors.Add("Sea Salt Caramel");
            flavors.Add("Dulce de Leche");

            // Console.WriteLine("Count = " + flavors.Count);
            // Console.WriteLine("Flavor at index of 2:  " + flavors[2]);
            // flavors.RemoveAt(2);
            // Console.WriteLine("\nList after removing Butter Pecan:");
            // foreach (string flavor in flavors) {
            //     Console.WriteLine(flavor);
            // }

            Dictionary<string,string> names = new Dictionary<string,string>();
            foreach (string name in stringArr) {
                names.Add(name, null);
            }

            Random randomFlavor = new Random();
            string r_flavor = "";
            r_flavor = flavors[(randomFlavor.Next(0,6)) - 1];
            names["Tim"] = r_flavor;
            r_flavor = flavors[(randomFlavor.Next(0,6)) - 1];
            names["Martin"] = r_flavor;
            r_flavor = flavors[(randomFlavor.Next(0,6)) - 1];
            names["Nikki"] = r_flavor;
            r_flavor = flavors[(randomFlavor.Next(0,6)) - 1];
            names["Sara"] = r_flavor;

            foreach (KeyValuePair<string,string> entry in names) {
                Console.WriteLine(entry.Key + " " + entry.Value);
            }
        }
    }
}
