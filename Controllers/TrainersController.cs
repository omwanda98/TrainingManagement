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
    public class TrainersController : ControllerBase
    {
        private readonly TrainingDbContext _context;
        private readonly JwtService _jwtService;

        public TrainersController(TrainingDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        // POST: api/Trainers/AddCourse
        [HttpPost("AddCourse")]
        [Authorize(Roles = "Trainer")]
        public async Task<IActionResult> AddCourse([FromBody] Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return Ok(course);
        }

        // GET: api/Trainers/Courses
        [HttpGet("Courses")]
        [Authorize(Roles = "Trainer")]
        public IActionResult GetCourses()
        {
            var courses = _context.Courses.ToList();
            return Ok(courses);
        }
    }
}
