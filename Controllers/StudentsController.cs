using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingManagement.Data;
using TrainingManagement.Models;
using TrainingManagement.Services;

namespace TrainingManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly TrainingDbContext _context;
        private readonly JwtService _jwtService;
        public class EnrollRequest
        {
            public string CourseCode { get; set; }
        }

        public StudentsController(TrainingDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        // POST: api/Students/Enroll
        // POST: api/Students/Enroll
        [HttpPost("Enroll")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Enroll([FromBody] EnrollRequest request)
        {
            // Retrieve StudentID from claims
            var studentId = User.Claims.FirstOrDefault(c => c.Type == "StudentID")?.Value;

            if (string.IsNullOrEmpty(studentId))
            {
                return BadRequest("Student ID is missing in the token.");
            }

            // Verify student exists
            var student = _context.Students.Find(studentId);
            if (student == null)
            {
                return BadRequest("Invalid student.");
            }

            // Verify course exists
            var course = _context.Courses.Find(request.CourseCode);
            if (course == null)
            {
                return BadRequest("Invalid course.");
            }

            // Check if the student is already enrolled in this course
            if (_context.StudentCourses.Any(sc => sc.StudentID == studentId && sc.CourseCode == request.CourseCode))
            {
                return BadRequest("Already enrolled in this course.");
            }

            // Enroll student in the course
            _context.StudentCourses.Add(new StudentCourse { StudentID = studentId, CourseCode = request.CourseCode });
            await _context.SaveChangesAsync();
            return Ok("Enrollment successful");
        }

    }
}
