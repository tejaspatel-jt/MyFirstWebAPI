using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPI.Data;
using MyFirstWebAPI.Modal;

namespace MyFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private ApplicationDbContext _db;

        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ApplicationDbContext context, ILogger<StudentsController> logger)
        {
            _db = context;
            _logger = logger;
        }

        [HttpGet]
        public List<StudentEntity> GetAllStudents() {

            _logger.LogInformation("tj_ Fetching All Students Data");
            return _db.StudentRegister.ToList();
        }

        [HttpGet("GetStudentsById")]
        public ActionResult<StudentEntity> GetStudentsById(Int32 Id)
        {

            if (Id == 0) {
                _logger.LogError("tj_ GetStudentsById Student Id was not passed");
                return BadRequest();
            }

            var StudentDetails = _db.StudentRegister.FirstOrDefault(x => x.Id == Id);

            if (StudentDetails == null) return NotFound();

            return StudentDetails;
        }

        [HttpPost("AddStudent")]
        public ActionResult<StudentEntity> AddStudent([FromBody] StudentEntity studentDetails) {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            _db.StudentRegister.Add(studentDetails);
            _db.SaveChanges();

            return Ok(studentDetails);
   
        }

        [HttpPost("UpdateStudentDetails")]
        public ActionResult<StudentEntity> UpdateStudentDetails(Int32 Id,  [FromBody] StudentEntity studentDetails)
        {

            if (studentDetails == null) return BadRequest(ModelState);

            var StudentDetails = _db.StudentRegister.FirstOrDefault(x => x.Id == Id);

            if (StudentDetails == null) return NotFound();

            StudentDetails.Name = studentDetails.Name;
            StudentDetails.Age= studentDetails.Age;
            StudentDetails.Standard = studentDetails.Standard;
            StudentDetails.EmailAddress = studentDetails.EmailAddress;

            _db.SaveChanges();

            return Ok(studentDetails);

        }

        [HttpPut("DeleteStudent")]
        public ActionResult<StudentEntity> DeleteStudent(Int32 Id)
        {

            var StudentDetails = _db.StudentRegister.FirstOrDefault(x => x.Id == Id);

            if (StudentDetails == null) return NotFound();

            _db.Remove(StudentDetails);
            _db.SaveChanges();

            return NoContent();

        }

        [HttpGet("GetAllStudentsName")]
        public string GetAllStudentsName() {
            return "Hello Get All Students name";
        }
    }
}
