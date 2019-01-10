using Interfaces;
using Models;
using System;
using System.Linq;
using System.Web.Http;

namespace Application.Controllers.API
{
    public class EmployeesController : ApiController
    {
        private readonly IUser _userRepo;

        public EmployeesController(IUser userRepo)
        {
            _userRepo = userRepo;
        }

        // GET /api/employees/
        public IHttpActionResult GetEmployees()
        {
            var employeesInDb = _userRepo.GetAll().Where(u => u.UserType == UserType.Employee);
            return Ok(employeesInDb);
        }

        // GET /api/employees/1
        public IHttpActionResult GetEmployee(int id)
        {
            var employeeInDb = _userRepo.Get(id);
            if (employeeInDb == null || employeeInDb.UserType != UserType.Employee)
                return NotFound();
            return Ok(employeeInDb);
        }

        // POST /api/employees
        [HttpPost]
        public IHttpActionResult CreateEmployee(User employee)
        {
            if (!ModelState.IsValid || employee.UserType != UserType.Employee)
                return BadRequest();
            _userRepo.Insert(employee);
            return Created(new Uri(Request.RequestUri + "/" + employee.Id), employee);
        }

        // PUT /api/employees/1
        [HttpPut]
        public IHttpActionResult UpdateEmployee(int id, User employee)
        {
            if (!ModelState.IsValid || employee.UserType != UserType.Employee)
                return BadRequest();
            var employeeInDb = _userRepo.Get(id);
            if (employeeInDb == null || employeeInDb.UserType != UserType.Employee)
                return NotFound();
            _userRepo.Update(employee);
            return Ok();
        }

        // DELETE /api/employees/1
        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var employeeInDb = _userRepo.Get(id);
            if (employeeInDb == null || employeeInDb.UserType != UserType.Employee)
                return NotFound();
            _userRepo.Delete(employeeInDb);
            return Ok();
        }
    }
}