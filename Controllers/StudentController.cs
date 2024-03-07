using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
         private readonly IStudentServices studentServices;
        public StudentController(IStudentServices studentServices) 
        {
        this.studentServices = studentServices;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public ActionResult<List<StudentMangement>>Get()
        {
            return studentServices.Get();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public ActionResult<StudentMangement> Get(string id)
        {
           var student = studentServices.Get(id);   

            if(student == null) 
            {
                return NotFound($"Student with Id = {id} not found");          
            }

            return student;
        }

        // POST api/<StudentController>
        [HttpPost]
        public ActionResult<StudentMangement> Post([FromBody] StudentMangement student)
        {
            studentServices.Create(student);

            return CreatedAtAction(nameof(Get), new {id = student.Id},student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] StudentMangement student)
        {
                var existingStudent = studentServices.Get(id);

            if(existingStudent == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }

            studentServices.Update(id, student);

            return NoContent();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var student  = studentServices.Get(id);

            if(student == null)
            {
                return NotFound($"Student with Id = {id} not found");

            }
            studentServices.Remove(student.Id);

            return Ok($"Student with Id = {id} not deleted");
        }
    }
}
