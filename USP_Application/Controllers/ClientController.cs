using Interfaces;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;
using USP_Application.Models;
using USP_Application.ViewModels;

namespace USP_Application.Controllers
{
    public class ClientController : Controller
    {
        IClient clientRepository;
        IUserLogin userLoginRepository;
        ICity cityRepository;
        IArea areaRepository;

        public ClientController(IClient clRepo, IUserLogin ulRepo, ICity ctRepo, IArea arRepo)
        {
            clientRepository = clRepo;
            userLoginRepository = ulRepo;
            cityRepository = ctRepo;
            areaRepository = arRepo;
        }

        // GET: Client
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CLientList(int? page, int? rows)
        {
            var pageNo = page ?? 1;
            var numOfRows = rows ?? 5;

            var clients = clientRepository.GetAll();
            var userLogins = userLoginRepository.GetAll();

            var query =
                from userLogin in userLogins
                join client in clients on userLogin.Id equals client.Id
                select new ClientUserLoginModel
                {
                    Id = client.Id,
                    Name = client.Name,
                    Phone = userLogin.Phone,
                    Email = userLogin.Email,
                    City = client.City.Name,
                    Area = client.Area.Name
                };
            return View(query.ToList().ToPagedList(pageNo, numOfRows));
        }

        public ActionResult Details(int id)
        {
            var client = clientRepository.Get(id);
            var userLogin = userLoginRepository.Get(id);
            var viewModel = new ClientFormViewModel
            {
                Client = client,
                UserLogin = userLogin
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateOrUpdate(ClientFormViewModel viewModel) // model binding
        {
            viewModel.Client.Name = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(viewModel.Client.Name.ToLower());
            if (viewModel.UserLogin.Id == 0) // Create
            {
                viewModel.Client.JoiningDate = DateTime.Now;
                viewModel.Client.Id = userLoginRepository.GetAll().Count() + 1;
                viewModel.UserLogin.UserType = Entities.UserType.Client;

                clientRepository.Insert(viewModel.Client);
                userLoginRepository.Insert(viewModel.UserLogin);
                return RedirectToAction("ClientList", "Client");
            }
            else // Update
            {
                var client = clientRepository.Update(viewModel.Client);
                var userLogin = userLoginRepository.Update(viewModel.UserLogin);
                return RedirectToAction("Details", "Client", new { id = viewModel.Client.Id });
            }
        }

        public ActionResult Edit(int id)
        {
            var client = clientRepository.Get(id);
            var userLogin = userLoginRepository.Get(id);
            var cities = cityRepository.GetAll().OrderBy(c => c.Name);
            var areas = areaRepository.GetAreasByCityId(client.CityId).OrderBy(a => a.Name);

            if (client == null)
            {
                return HttpNotFound();
            }
            var viewModel = new ClientFormViewModel
            {
                Client = client,
                UserLogin = userLogin,
                Cities = cities,
                Areas = areas
            };
            return View(viewModel);
        }

        public ActionResult Remove(int id)
        {
            clientRepository.Delete(clientRepository.Get(id));
            userLoginRepository.Delete(userLoginRepository.Get(id));
            return RedirectToAction("ClientList", "Client");
        }
    }
}