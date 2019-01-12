using Interfaces;
using Models;
using System.Web.Mvc;

namespace Application.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IService _serviceRepo;

        public ServiceController(IService serviceRepo)
        {
            _serviceRepo = serviceRepo;
        }

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
        public ActionResult Add()
        {
            return View(new Service());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var service = _serviceRepo.Get(id);
            return View(service);
        }
    }
}