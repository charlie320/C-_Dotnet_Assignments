using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {

    
    public class ArtistController : Controller {

        private List<Artist> allArtists;

        public ArtistController() {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [Route("")]
        [HttpGet]
        public string Index() {
            //String describing the API functionality
            string instructions = "Welcome to the Music API~~\n========================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";

            return instructions;
            }

            [Route("artists")]
            [HttpGet]
            public List<Artist> GetArtists() {
                // return "Artists will go here";
                return allArtists;
            }

            [Route("artists/name/{name}")]
            [HttpGet]
            public IActionResult GetArtistByName(string name) {
                IEnumerable<object> artistByName = allArtists.Where(artist => artist.ArtistName == name);
                return Json(artistByName);
            }

            [Route("artists/realname/{name}")]
            [HttpGet]
            public IActionResult GetArtistByRealName(string name) {
                IEnumerable<object> artistByRealName = allArtists.Where(artist => artist.RealName == name);
                return Json(artistByRealName);
            }

            [Route("artists/hometown/{town}")]
            [HttpGet]
            public IActionResult GetArtistByHometown(string town) {
                IEnumerable<object> artistByHometown = allArtists.Where(artist => artist.Hometown == town);
                return Json(artistByHometown);
            }

            [Route("artists/groupid/{id}")]
            [HttpGet]
            public IActionResult GetArtistByGroupId(int id) {
                IEnumerable<object> artistByGroupId = allArtists.Where(artist => artist.GroupId == id);
                return Json(artistByGroupId);
            }
    }
}