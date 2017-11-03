using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JsonData;
using System.Collections.Generic;
using System.Linq;
using MusicApi;

namespace rapi.Controllers{
    public class rapiController : Controller{
        List<Artist> Artists = JsonToFile<Artist>.ReadJson();
        List<Group> Groups = JsonToFile<Group>.ReadJson();

        [HttpGet]
        [Route("/artists")]
        public JsonResult DisplayAll(){
            var AnonObj =  from artist in Artists select new {artist.ArtistName, artist.RealName};
            return Json(AnonObj);
        }
        [HttpGet]
        [Route("/artists/name/{n}")]
        public JsonResult DisplayName(string n){
            var AnonObject =  from artist in Artists where artist.ArtistName == n select new {artist.ArtistName};
            return Json(AnonObject);
        }
        [HttpGet]
        [Route("/artists/realname/{n}")]

        public JsonResult DisplayReal(string n){
            var Aobj = from artist in Artists where artist.RealName.Contains(n) select new{artist.RealName};
            return Json(Aobj);
        }
        [HttpGet]
        [Route("/artists/hometown/{home}")]
        public JsonResult DisplayHome(string home){
            var AnObj= from artist in Artists where artist.Hometown == home select new{artist.ArtistName};
            return Json(AnObj);
        }
        [HttpGet]
        [Route("/artists/groupid/{id}")]
        public JsonResult DisplayGId(int id){
            var Obj = from artist in Artists where artist.GroupId == id select new{artist.ArtistName};
            return Json(Obj);
        }

        [HttpGet]
        [Route("/groups")]
        public JsonResult DisplayGroup(){
            var GroupObj = from g in Groups select new {g.GroupName};
            return Json(GroupObj);
        }
        [HttpGet]
        [Route("/groups/name/{name}")]
        public JsonResult DisplayGroupName(string name){
            var GObj = from g in Groups where g.GroupName == name select new {g.GroupName};
            return Json(GObj);
        }
        [HttpGet]
        [Route("/groups/id/{id}")]
        public JsonResult DisplayGroupID(int id){
            var GROUPobj = from g in Groups where g.Id == id select new{g.GroupName};
            return Json(GROUPobj);
        }
        
    }
}
