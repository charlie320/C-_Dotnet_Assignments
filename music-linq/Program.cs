using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            // foreach (Artist artist in Artists) {
            //     Console.WriteLine(artist.Hometown);
            // }

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            IEnumerable<Artist> ArtistList = Artists.Where(artist => artist.Hometown == "Mount Vernon");

            Console.Write("Artists from Mount Vernon include ");
            foreach (Artist ind in ArtistList) {
                Console.WriteLine("{0} who is {1} years old.", ind.RealName, ind.Age);
            }

            //Who is the youngest artist in our collection of artists?
            int youngestAge = Artists.Select(artist => artist.Age).Min();
            IEnumerable<Artist> ArtistListAge = Artists.Where(artist => artist.Age == youngestAge);
            foreach (Artist young in ArtistListAge) {
            Console.WriteLine("The artist with the youngest age is {0}", young.RealName);
            }
            // another way to retrieve the youngest artists
            IEnumerable<Artist> ArtistAgeSort = Artists.OrderBy(artist => artist.Age);
            Console.WriteLine("The artist with the youngest age is {0}", ArtistAgeSort.First().RealName);

            //Display all artists with 'William' somewhere in their real name
            IEnumerable<Artist> WilliamName = Artists.Where(artist => artist.RealName.Contains("William"));
            foreach (Artist william in WilliamName) {
                Console.WriteLine("An artist with {0} in his/her name: {1}.", "\"William\"", william.RealName);
            }
            //Display the 3 oldest artist from Atlanta
            IEnumerable<Artist> ArtistAgeSortDesc = Artists.Where(artist => artist.Hometown == "Atlanta").OrderByDescending(artist => artist.Age).Take(3);
            Console.WriteLine("The 3 oldest artists from Atlanta are:");
            foreach (Artist elder in ArtistAgeSortDesc) {
                Console.WriteLine("{0}", elder.RealName );
            }
            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
        }
    }
}
