using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private List<Student> studentDb = new List<Student>()
        {
            new Student(){StudentId=1,StudentName="John",StudentEmail="john@gmail.com",Grade="A+"},
            new Student(){StudentId=2,StudentName="Ram",StudentEmail="ram@gmail.com",Grade="A+"},
            new Student(){StudentId=3,StudentName="Vikky",StudentEmail="vikky@gmail.com",Grade="A"},
            new Student(){StudentId=4,StudentName="Tamil",StudentEmail="tamil@gmail.com",Grade="A+"},
            new Student(){StudentId=5,StudentName="Peter",StudentEmail="peter@gmail.com",Grade="A"},
            new Student(){StudentId=6,StudentName="Leo",StudentEmail="leo@gmail.com",Grade="A+"},
            new Student(){StudentId=7,StudentName="Das",StudentEmail="das@gmail.com",Grade="A"},
        };

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            if (studentDb.Count == 0)
            {
                return NotFound("No Data Available");
            }
            else
            {
                return Ok(studentDb);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            Student? student = studentDb.Find(x => x.StudentId == id);
            if (student != null)
            {
                return Ok(student);
            }
            else
            {
                return NotFound("Pleae enter a valid id");
            }
        }

        [HttpPost]
        public IActionResult AddStudent(Student studentDetails)
        {
            if (studentDetails != null)
            {
                var student = studentDb.Find(x => x.StudentId == studentDetails.StudentId);
                if (student == null)
                {
                    studentDb.Add(studentDetails);
                    return Ok("Student Details Added Successfully");
                }
                else
                {
                    return BadRequest("This student details Already exists in Database");
                }

            }
            else
            {
                return BadRequest("Please Enter a Valid Data");
            }
        }
        [HttpPut]
        public IActionResult EditStudentDetails(Student studentDetails)
        {
            if (studentDetails != null)
            {
                var existingStudentDetails = studentDb.Find(x => x.StudentId == studentDetails.StudentId);
                if (existingStudentDetails != null)
                {
                    existingStudentDetails.StudentName = studentDetails.StudentName;
                    existingStudentDetails.StudentEmail = studentDetails.StudentEmail;
                    existingStudentDetails.Grade = studentDetails.Grade;
                    return Ok(studentDb);
                }
                else
                {
                    return BadRequest("Please Enter a valid Student Id");
                }
            }
            else
            {
                return BadRequest("Please Enter a valid  Student Information");
            }
        }

        [HttpDelete]
        public IActionResult DeleteStudentDetails(int id)
        {
            var existingStudentDetails = studentDb.Find(x => x.StudentId == id);
            if (existingStudentDetails != null)
            {
                studentDb.Remove(existingStudentDetails);
                return Ok(studentDb);
            }
            else
            {
                return BadRequest("Please enter valid Student Id");
            }
        }

    }
}
