using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace CallingCard.Controllers{
    public class CallingCardController : Controller{
        [HttpGet]
        [Route("/{fname}/{lname}/{age}/{fcolor}")]

        public JsonResult DisplayAll(string fname, string lname, int age, string fcolor){
            var Anonobj = new {
                firstname = fname,
                lastname = lname,
                age = age,
                favoriteColor = fcolor
            };
            return Json(Anonobj);
        }
    }
}
