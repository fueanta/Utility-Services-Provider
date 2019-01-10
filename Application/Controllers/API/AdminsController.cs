using Interfaces;
using Models;
using System;
using System.Linq;
using System.Web.Http;

namespace Application.Controllers.API
{
    public class AdminsController : ApiController
    {
        private readonly IUser _userRepo;

        public AdminsController(IUser userRepo)
        {
            _userRepo = userRepo;
        }

        // GET /api/admins/
        public IHttpActionResult GetAdmins()
        {
            var adminsInDb = _userRepo.GetAll().Where(u => u.UserType == UserType.Admin);
            return Ok(adminsInDb);
        }

        // GET /api/admins/1
        public IHttpActionResult GetAdmin(int id)
        {
            var adminInDb = _userRepo.Get(id);
            if (adminInDb == null || adminInDb.UserType != UserType.Admin)
                return NotFound();
            return Ok(adminInDb);
        }

        // POST /api/admins
        [HttpPost]
        public IHttpActionResult CreateAdmin(User admin)
        {
            if (!ModelState.IsValid || admin.UserType != UserType.Admin)
                return BadRequest();
            _userRepo.Insert(admin);
            return Created(new Uri(Request.RequestUri + "/" + admin.Id), admin);
        }

        // PUT /api/admins/1
        [HttpPut]
        public IHttpActionResult UpdateAdmin(int id, User admin)
        {
            if (!ModelState.IsValid || admin.UserType != UserType.Admin)
                return BadRequest();
            var adminInDb = _userRepo.Get(id);
            if (adminInDb == null || adminInDb.UserType != UserType.Admin)
                return NotFound();
            _userRepo.Update(admin);
            return Ok();
        }

        // DELETE /api/admins/1
        [HttpDelete]
        public IHttpActionResult DeleteAdmin(int id)
        {
            var adminInDb = _userRepo.Get(id);
            if (adminInDb == null || adminInDb.UserType != UserType.Admin)
                return NotFound();
            _userRepo.Delete(adminInDb);
            return Ok();
        }
    }
}