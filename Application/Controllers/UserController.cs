using Interfaces;
using Models;
using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ViewModels;

namespace Application.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _userRepo;
        private readonly ICity _cityRepo;
        private readonly IArea _areaRepo;

        public UserController(IUser userRepo, ICity cityRepo, IArea areaRepo)
        {
            _userRepo = userRepo;
            _cityRepo = cityRepo;
            _areaRepo = areaRepo;
        }

        // GET: User
        public ActionResult Index(User loggedUser)
        {
            return View(loggedUser);
        }

        public ActionResult Employees()
        {
            var user = HomeController.LoggedUser;

            if (user == null || !(user.UserType == UserType.Admin))
            {
                return RedirectToAction("index", "home");
            }

            return View();
        }

        public ActionResult Add(UserType userType)
        {
            var user = new User { DateOfBirth = DateTime.Today.AddYears(-18), JoiningDateTime = DateTime.Now, UserType = userType };
            var cities = _cityRepo.GetAll().OrderBy(c => c.Name);
            var viewModel = new UserFormViewModel
            {
                User = user,
                Cities = cities,
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(UserFormViewModel formViewModel)
        {
            // if given data is not valid, send back the object with error message
            if (!ModelState.IsValid)
            {
                var cities = _cityRepo.GetAll().OrderBy(c => c.Name);
                var areas = _areaRepo.GetAreasByCityId(formViewModel.User.CityId).OrderBy(a => a.Name);

                formViewModel.Cities = cities;
                formViewModel.Areas = areas;

                return View("Add", formViewModel);
            }

            // first letter of every word is capital
            formViewModel.User.FirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(formViewModel.User.FirstName.ToLower());
            formViewModel.User.LastName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(formViewModel.User.LastName.ToLower());

            // update in db
            _userRepo.Insert(formViewModel.User);

            // if consumer
            if (formViewModel.User.UserType == UserType.Consumer)
            {
                HomeController.LoggedUser = formViewModel.User;
                return RedirectToAction("index", "user");
            }
            // if employee
            else if (formViewModel.User.UserType == UserType.Employee)
                return RedirectToAction("employees", "user");
            // if labour
            else
                return RedirectToAction("labours", "user");
        }

        public ActionResult Edit(int id)
        {
            if (id == -1)
            {
                id = HomeController.LoggedUser.Id;
            }

            var user = _userRepo.Get(id);
            var cities = _cityRepo.GetAll().OrderBy(c => c.Name);
            var areas = _areaRepo.GetAreasByCityId(user.CityId).OrderBy(a => a.Name);

            var viewModel = new UserFormViewModel
            {
                User = user,
                Cities = cities,
                Areas = areas
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UserFormViewModel formViewModel)
        {
            // if given data is not valid, send back the object with error message
            if (!ModelState.IsValid)
            {
                var cities = _cityRepo.GetAll().OrderBy(c => c.Name);
                var areas = _areaRepo.GetAreasByCityId(formViewModel.User.CityId).OrderBy(a => a.Name);

                formViewModel.Cities = cities;
                formViewModel.Areas = areas;

                return View("Edit", formViewModel);
            }

            // first letter of every word is capital
            formViewModel.User.FirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(formViewModel.User.FirstName.ToLower());
            formViewModel.User.LastName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(formViewModel.User.LastName.ToLower());

            // update in db
            _userRepo.Update(formViewModel.User);

            // update in local object if updated own account
            if (HomeController.LoggedUser.Id == formViewModel.User.Id)
            {
                HomeController.LoggedUser = formViewModel.User;
                return RedirectToAction("index", "user");
            }
            // if not but employee
            else if (formViewModel.User.UserType == UserType.Employee)
                return RedirectToAction("employees", "user");
            // if not but labour
            else
                return RedirectToAction("labours", "user");
        }
    }
}