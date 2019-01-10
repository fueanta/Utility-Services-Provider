using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Application.Controllers.AJAX_Helper
{
    public class AreaJsonByCityController : Controller
    {
        private readonly ICity _cityRepo;
        private readonly IArea _areaRepo;

        public AreaJsonByCityController(ICity cityRepo, IArea areaRepo)
        {
            _cityRepo = cityRepo;
            _areaRepo = areaRepo;
        }

        public JsonResult AreaList(int id)
        {
            var area = _areaRepo.GetAreasByCityId(id).OrderBy(a => a.Name).ToList();
            return Json(new SelectList(area.ToArray(), "Id", "Name"), JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<Area> GetArea(int CityId)
        {
            return _areaRepo.GetAreasByCityId(CityId).OrderBy(a => a.Name).ToList();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LoadClassesByCityId(string Name)
        {
            var areaList = GetArea(Convert.ToInt32(Name));
            var areaData = areaList.Select(m => new SelectListItem()
            {
                Text = m.Name,
                Value = m.Id.ToString(),
            });
            return Json(areaData, JsonRequestBehavior.AllowGet);
        }

    }
}