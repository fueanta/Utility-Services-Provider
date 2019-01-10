using Interfaces;
using Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        public static User LoggedUser { get; set; }

        private readonly IUser _userRepo;
        private readonly ICity _cityRepo;

        public HomeController(IUser userRepo, ICity cityRepo)
        {
            _userRepo = userRepo;
            _cityRepo = cityRepo;
        }

        public ActionResult Index()
        {
            // if cookie is available
            HttpCookie loginIdCookie = Request.Cookies["LoginId"];
            if (loginIdCookie != null)
            {
                var id = int.Parse(loginIdCookie.Value);
                LoggedUser = _userRepo.Get(id);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            return RedirectToAction("register", "consumer");
        }

        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            // delete stored cookie
            HttpCookie loginIdCookie = Request.Cookies["LoginId"];
            if (loginIdCookie != null)
            {
                loginIdCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(loginIdCookie);
            }

            LoggedUser = null;
            return RedirectToAction("index", "home");
        }

        public ActionResult LogInSubmission(LoginFormViewModel formViewModel)
        {
            User user = _userRepo.GetAll().FirstOrDefault(u => (u.Email.Equals(formViewModel.UserLogin.EmailOrPhone) || u.Phone.Equals(formViewModel.UserLogin.EmailOrPhone)) && u.Password.Equals(formViewModel.UserLogin.Password));

            if (user != null)
            {
                if (formViewModel.DoRememberMe)
                {
                    // store cookie for 1 week
                    HttpCookie loginIdCookie = new HttpCookie("LoginId")
                    {
                        Expires = DateTime.Now.AddDays(7d),
                        Value = user.Id.ToString()
                    };
                    Response.Cookies.Add(loginIdCookie);
                }

                LoggedUser = user;
                return RedirectToAction("index", "home");
            }

            return View("login", formViewModel);
        }
    }
}