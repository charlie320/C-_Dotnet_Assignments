using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
        }

            [Route("groups")]
            [HttpGet]
            public IActionResult GetGroups() {
                return Json(allGroups);
            }

            [Route("groups/name/{name}")]
            [HttpGet]
            public IActionResult GetGroupsByName(string name) {
                IEnumerable<object> allGroupsByName = allGroups.Where(group => group.GroupName == name);
                return Json(allGroupsByName);
            }

            [Route("groups/id/{id}")]
            [HttpGet]
            public IActionResult GetGroupsById(int id) {
                IEnumerable<object> allGroupsById = allGroups.Where(group => group.Id == id);
                return Json(allGroupsById);
            }
    }
}