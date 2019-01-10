using Models;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class ServiceController : Controller
    {
        public ActionResult List()
        {
            var user = HomeController.LoggedUser;

            if (user == null || !(user.UserType == UserType.Admin))
            {
                return RedirectToAction("index", "home");
            }
            return View();
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            return View(new Service());
        }
    }
}