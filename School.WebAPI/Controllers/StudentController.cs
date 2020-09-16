using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.WebAPI.Logic;
using School.WebAPI.Data;
using School.WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace School.WebAPI.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private StudentLogic _studentLogic;

        public StudentController()
        {
            EFGenericRepository<StudentPoco> eFGenericRepository = new EFGenericRepository<StudentPoco>();
            _studentLogic = new StudentLogic(eFGenericRepository);
        }
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<StudentPoco> Get()
        {
            return _studentLogic.GetAll();
        }

   

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public StudentPoco Get(int id)
        {
            StudentPoco poco = _studentLogic.GetSingle(id);
            return poco;
        }


        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post([FromBody] StudentPoco student)
        {
            _studentLogic.Add(student);
            return Ok();
        }


         //DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _studentLogic.Remove(id);
            return Ok();

        }
    }
}
