using Data;
using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USP_Application.ViewModels;

namespace USP_Application.Controllers
{
    public class HomeController : Controller
    {
        IUserLogin userLoginRepository;
        ICity cityRepository;
        public HomeController(IUserLogin ulRepo, ICity ctRepo)
        {
            userLoginRepository = ulRepo;
            cityRepository = ctRepo;
        }
        public ActionResult Index()
        {
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
            return RedirectToAction("Insert", "Client");
        }

        public ActionResult Login()
        {
            var viewModel = new LoginFormViewModel();
            viewModel.UserLogin = new UserLogin();

            if (Request.Cookies["LoginEmail"] != null)
            {
                // populate data from cookie
                viewModel.UserLogin.Email = Request.Cookies["LoginEmail"].Value;
                viewModel.UserLogin.Password = Request.Cookies["LoginPassword"].Value;
                viewModel.RememberMe = true;
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult LogInSubmit(LoginFormViewModel viewModel)
        {
            var user = userLoginRepository.GetAll().FirstOrDefault(u => u.Email.Equals(viewModel.UserLogin.Email) && u.Password.Equals(viewModel.UserLogin.Password));

            if (user != null)
            {
                if (viewModel.RememberMe)
                {
                    // store cookie for 1 day
                    HttpCookie loginEmailCookie = new HttpCookie("LoginEmail");
                    loginEmailCookie.Expires = DateTime.Now.AddDays(1d);
                    loginEmailCookie.Value = user.Email;
                    Response.Cookies.Add(loginEmailCookie);

                    HttpCookie loginPasswordCookie = new HttpCookie("LoginPassword");
                    loginPasswordCookie.Expires = DateTime.Now.AddDays(1d);
                    loginPasswordCookie.Value = user.Password;
                    Response.Cookies.Add(loginPasswordCookie);
                }
                else
                {
                    // delete cookie
                    if (Request.Cookies["LoginEmail"] != null)
                    {
                        HttpCookie loginEmailCookie = Request.Cookies["LoginEmail"];
                        loginEmailCookie.Expires = DateTime.Now.AddDays(-1d);
                        Response.Cookies.Add(loginEmailCookie);

                        HttpCookie loginPasswordCookie = Request.Cookies["LoginPassword"];
                        loginPasswordCookie.Expires = DateTime.Now.AddDays(-1d);
                        Response.Cookies.Add(loginPasswordCookie);
                    }
                }

                switch (user.UserType)
                {
                    case UserType.Client:
                        // logged in user is client
                        return RedirectToAction("Index", "Client");
                    case UserType.Employee:
                        // logged in user is employee
                        return RedirectToAction("Index", "Employee");
                    case UserType.Labour:
                        // logged in user is labour
                        return RedirectToAction("Index", "Labour");
                    default:
                        // logged in user is admin
                        return RedirectToAction("Index", "Admin");
                }
            }

            viewModel.Invalid = true;
            return View("Login", viewModel);
        }
    }
}