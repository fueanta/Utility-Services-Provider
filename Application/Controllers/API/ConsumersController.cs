using Interfaces;
using Models;
using System;
using System.Linq;
using System.Web.Http;

namespace Application.Controllers.API
{
    public class ConsumersController : ApiController
    {
        private readonly IUser _userRepo;

        public ConsumersController(IUser userRepo)
        {
            _userRepo = userRepo;
        }

        // GET /api/consumers/
        public IHttpActionResult GetConsumers()
        {
            var consumersInDb = _userRepo.GetAll().Where(u => u.UserType == UserType.Consumer);
            return Ok(consumersInDb);
        }

        // GET /api/consumers/1
        public IHttpActionResult GetConsumer(int id)
        {
            var consumerInDb = _userRepo.Get(id);
            if (consumerInDb == null || consumerInDb.UserType != UserType.Consumer)
                return NotFound();
            return Ok(consumerInDb);
        }

        // POST /api/consumers
        [HttpPost]
        public IHttpActionResult CreateConsumer(User consumer)
        {
            if (!ModelState.IsValid || consumer.UserType != UserType.Consumer)
                return BadRequest();
            _userRepo.Insert(consumer);
            return Created(new Uri(Request.RequestUri + "/" + consumer.Id), consumer);
        }

        // PUT /api/consumers/1
        [HttpPut]
        public IHttpActionResult UpdateConsumer(int id, User consumer)
        {
            if (!ModelState.IsValid || consumer.UserType != UserType.Consumer)
                return BadRequest();
            var consumerInDb = _userRepo.Get(id);
            if (consumerInDb == null || consumerInDb.UserType != UserType.Consumer)
                return NotFound();
            _userRepo.Update(consumer);
            return Ok();
        }

        // DELETE /api/consumers/1
        [HttpDelete]
        public IHttpActionResult DeleteConsumer(int id)
        {
            var consumerInDb = _userRepo.Get(id);
            if (consumerInDb == null || consumerInDb.UserType != UserType.Consumer)
                return NotFound();
            _userRepo.Delete(consumerInDb);
            return Ok();
        }
    }
}