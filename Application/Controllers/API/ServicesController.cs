using Interfaces;
using Models;
using System;
using System.Web.Http;

namespace Application.Controllers.API
{
    public class ServicesController : ApiController
    {
        private readonly IService _serviceRepo;

        public ServicesController(IService serviceRepo)
        {
            _serviceRepo = serviceRepo;
        }

        // GET /api/services/
        public IHttpActionResult GetServices()
        {
            var servicesInDb = _serviceRepo.GetAll();
            return Ok(servicesInDb);
        }

        // GET /api/services/1
        public IHttpActionResult GetService(int id)
        {
            var serviceInDb = _serviceRepo.Get(id);
            if (serviceInDb == null)
                return NotFound();
            return Ok(serviceInDb);
        }

        // POST /api/services
        [HttpPost]
        public IHttpActionResult CreateService(Service service)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _serviceRepo.Insert(service);
            return Created(new Uri(Request.RequestUri + "/" + service.Id), service);
        }

        // PUT /api/services/1
        [HttpPut]
        public IHttpActionResult UpdateService(int id, Service service)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var serviceInDb = _serviceRepo.Get(id);
            if (serviceInDb == null)
                return NotFound();
            _serviceRepo.Update(service);
            return Ok();
        }

        // DELETE /api/services/1
        [HttpDelete]
        public IHttpActionResult DeleteService(int id)
        {
            var serviceInDb = _serviceRepo.Get(id);
            if (serviceInDb == null)
                return NotFound();
            _serviceRepo.Delete(serviceInDb);
            return Ok();
        }
    }
}
