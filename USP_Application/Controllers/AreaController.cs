using Interfaces;
using System.Web.Mvc;
using System.Linq;
using PagedList;
using System;
using System.Collections.Generic;
using Entities;

namespace USP_Application.Controllers
{
    public class AreaController : Controller
    {
        IArea areaRepository;
        public AreaController(IArea arRepo)
        {
            areaRepository = arRepo;
        }

        // GET: Area
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AreaList(int? page, int? rows)
        {
            var pageNo = page ?? 1;
            var numOfRows = rows ?? 5;

            var areas = areaRepository.GetAll().OrderBy(a => a.City.Name).ToList().ToPagedList(pageNo, numOfRows);
            return View(areas);
        }
    }
}