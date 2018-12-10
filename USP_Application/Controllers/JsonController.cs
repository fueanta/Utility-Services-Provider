using Entities;
using Interfaces;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using USP_Application.Models;

namespace USP_Application.Controllers
{
    public class JsonController : Controller
    {
        IClient clientRepository;
        IUserLogin userLoginRepository;
        ICity cityRepository;
        IArea areaRepository;

        public JsonController(IClient clRepo, IUserLogin ulRepo, ICity ctRepo, IArea arRepo)
        {
            clientRepository = clRepo;
            userLoginRepository = ulRepo;
            cityRepository = ctRepo;
            areaRepository = arRepo;
        }

        /*City-Area*/
        public JsonResult AreaList(int id)
        {
            var area = areaRepository.GetAreasByCityId(id).OrderBy(a => a.Name).ToList();
            return Json(new SelectList(area.ToArray(), "Id", "Name"), JsonRequestBehavior.AllowGet);
        }
        public IEnumerable<Area> GetArea(int CityId)
        {
            return areaRepository.GetAreasByCityId(CityId).OrderBy(a => a.Name).ToList();
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LoadClassesByCityId(string Name)
        {
            var areaList = this.GetArea(Convert.ToInt32(Name));
            var areaData = areaList.Select(m => new SelectListItem()
            {
                Text = m.Name,
                Value = m.Id.ToString(),
            });
            return Json(areaData, JsonRequestBehavior.AllowGet);
        }
        /*City-Area*/

        /*Area-List Search*/

        public JsonResult SearchAreaList(string searchBy, string searchValue, int? page, int? rows)
        {
            var pageNo = page ?? 1;
            var numOfRows = rows ?? 5;
            List<Area> areaList;

            switch (searchBy)
            {
                case "id":
                    //search by id
                    areaList = areaRepository.GetAll().Where(c => c.Id.ToString().Contains(searchValue) || searchValue == null).ToList();
                    break;
                case "city":
                    //search by city
                    areaList = areaRepository.GetAll().Where(c => c.City.Name.ToLower().Contains(searchValue.ToLower()) || searchValue == null).ToList();
                    break;
                default:
                    //by default, search by name
                    areaList = areaRepository.GetAll().Where(c => c.Name.ToLower().Contains(searchValue.ToLower()) || searchValue == null).ToList();
                    break;
            }
            return Json(areaList, JsonRequestBehavior.AllowGet);
        }
        /*Area-List Search*/

        /*Client-List Search*/

        public JsonResult SearchClientList(string searchBy, string searchValue, int? page, int? rows)
        {
            var pageNo = page ?? 1;
            var numOfRows = rows ?? 5;

            List<Client> clientList = clientRepository.GetAll().ToList();
            List<UserLogin> userLogins = userLoginRepository.GetAll().ToList();

            switch (searchBy)
            {
                case "phone":
                    //search by phone
                    userLogins = userLogins.Where(u => u.Phone.ToLower().Contains(searchValue.ToLower()) || searchValue == null).ToList();
                    break;
                case "email":
                    //search by email
                    userLogins = userLogins.Where(u => u.Email.ToLower().Contains(searchValue.ToLower()) || searchValue == null).ToList();
                    break;
                case "city":
                    //search by city
                    clientList = clientList.Where(c => c.City.Name.ToLower().Contains(searchValue.ToLower()) || searchValue == null).ToList();
                    break;
                case "area":
                    //search by area
                    clientList = clientList.Where(c => c.Area.Name.ToLower().Contains(searchValue.ToLower()) || searchValue == null).ToList();
                    break;
                case "id":
                    //search by id
                    clientList = clientList.Where(c => c.Id.ToString().ToLower().Contains(searchValue.ToLower()) || searchValue == null).ToList();
                    break;
                default:
                    //by default, search by name
                    clientList = clientList.Where(c => c.Name.ToLower().Contains(searchValue.ToLower()) || searchValue == null).ToList();
                    break;
            }

            IEnumerable< ClientUserLoginModel> clientUserLoginModel;

            if (searchBy.Equals("phone") | searchBy.Equals("email"))
            {
                clientUserLoginModel =
                   from userLogin in userLogins
                   join client in clientList on userLogin.Id equals client.Id
                   select new ClientUserLoginModel { Id = client.Id, Name = client.Name, City = client.City.Name, Area = client.Area.Name, Phone = userLogin.Phone, Email = userLogin.Email };
            }
            else
            {
                clientUserLoginModel =
                   from client in clientList
                   join userLogin in userLogins on client.Id equals userLogin.Id
                   select new ClientUserLoginModel { Id = client.Id, Name = client.Name, City = client.City.Name, Area = client.Area.Name, Phone = userLogin.Phone, Email = userLogin.Email };
            }

            return Json(clientUserLoginModel, JsonRequestBehavior.AllowGet);
        }
        /*Client-List Search*/
    }
}