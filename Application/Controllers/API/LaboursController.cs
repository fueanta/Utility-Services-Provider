using Interfaces;
using Models;
using System;
using System.Linq;
using System.Web.Http;

namespace Application.Controllers.API
{
    public class LaboursController : ApiController
    {
        private readonly IUser _userRepo;

        public LaboursController(IUser userRepo)
        {
            _userRepo = userRepo;
        }

        // GET /api/labours/
        public IHttpActionResult GetLabours()
        {
            var laboursInDb = _userRepo.GetAll().Where(u => u.UserType == UserType.Labour);
            return Ok(laboursInDb);
        }

        // GET /api/labours/1
        public IHttpActionResult GetLabour(int id)
        {
            var labourInDb = _userRepo.Get(id);
            if (labourInDb == null || labourInDb.UserType != UserType.Labour)
                return NotFound();
            return Ok(labourInDb);
        }

        // POST /api/labours
        [HttpPost]
        public IHttpActionResult CreateLabour(User labour)
        {
            if (!ModelState.IsValid || labour.UserType != UserType.Labour)
                return BadRequest();
            _userRepo.Insert(labour);
            return Created(new Uri(Request.RequestUri + "/" + labour.Id), labour);
        }

        // PUT /api/labours/1
        [HttpPut]
        public IHttpActionResult UpdateLabour(int id, User labour)
        {
            if (!ModelState.IsValid || labour.UserType != UserType.Labour)
                return BadRequest();
            var labourInDb = _userRepo.Get(id);
            if (labourInDb == null || labourInDb.UserType != UserType.Labour)
                return NotFound();
            _userRepo.Update(labour);
            return Ok();
        }

        // DELETE /api/labours/1
        [HttpDelete]
        public IHttpActionResult DeleteLabour(int id)
        {
            var labourInDb = _userRepo.Get(id);
            if (labourInDb == null || labourInDb.UserType != UserType.Labour)
                return NotFound();
            _userRepo.Delete(labourInDb);
            return Ok();
        }
    }
}