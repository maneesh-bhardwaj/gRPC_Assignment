using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.WebAPI.Data;
using School.WebAPI.Logic;
using School.WebAPI.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private EnrollmentLogic _enrollmentLogic;

        public EnrollmentController()
        {
            EFGenericRepository<EnrollmentPoco> eFGenericRepository = new EFGenericRepository<EnrollmentPoco>();
            _enrollmentLogic = new EnrollmentLogic(eFGenericRepository);
        }

        // GET: api/<StudentCourseController>
        [HttpGet]
        public IEnumerable<EnrollmentPoco> Get()
        {
            return _enrollmentLogic.GetAll();
        }

        // GET api/<StudentCourseController>/5
        [HttpGet("{id}")]
        public EnrollmentPoco Get(int id)
        {
            return _enrollmentLogic.GetSingle(id);
        }

        // POST api/<StudentCourseController>
        [HttpPost]
        public IActionResult Post([FromBody] EnrollmentPoco studentCourse)
        {
            _enrollmentLogic.Add(studentCourse);
            return Ok();
        }

        // DELETE api/<StudentCourseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _enrollmentLogic.Remove(id);
            return Ok();
        }
    }
}
