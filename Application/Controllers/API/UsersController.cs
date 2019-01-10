using Interfaces;
using Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace Application.Controllers.API
{
    public class UsersController : ApiController
    {
        private readonly IUser _userRepo;

        public UsersController(IUser userRepo)
        {
            _userRepo = userRepo;
        }

        // GET /api/users/
        public IEnumerable<User> GetUsers()
        {
            var usersInDb = _userRepo.GetAll();
            return usersInDb;
        }

        // GET /api/users/1
        public User GetUser(int id)
        {
            var userInDb = _userRepo.Get(id);
            if (userInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return userInDb;
        }

        // POST /api/users
        [HttpPost]
        public User CreateUser(User user)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _userRepo.Insert(user);
            return user;
        }

        // PUT /api/users/1
        [HttpPut]
        public void UpdateUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var userInDb = _userRepo.Get(id);
            if (userInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _userRepo.Update(user);
        }

        // DELETE /api/users/1
        [HttpDelete]
        public void DeleteUser(int id)
        {
            var userInDb = _userRepo.Get(id);
            if (userInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _userRepo.Delete(userInDb);
        }
    }
}
