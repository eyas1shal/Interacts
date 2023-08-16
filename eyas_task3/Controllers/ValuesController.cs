using eyas_task3.Models;
using eyas_task3.Services;
using eyas_task3.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eyas_task3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly studentsService studentsServices;
        private readonly coursesService coursesService;
        private readonly stcServices stcService;

        public ValuesController(ApplicationDbContext context, studentsService istudentServices, 
            coursesService icoursesServices, stcServices istcServices)
        {
            _context = context;
            studentsServices = istudentServices;
            coursesService = icoursesServices;
            stcService = istcServices;
        }

        [HttpGet("GetStudents")]

         public async Task<IActionResult> GetStudents()
        {
            return Ok(await studentsServices.GetAll());
        }

        [HttpGet("Student{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var obj = await _context.Students.FirstOrDefaultAsync(c => c.Id == id);
            if (obj == null)
            {
                return NotFound("the Student is not found");
            }

            return Ok(obj);

        }


        [HttpGet("GetCourses")]

        public async Task<IActionResult> GetCourses()
        {
            return Ok(await coursesService.GetAll());
        
        }
        [HttpGet("Courses{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var obj = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (obj == null)
            {
                return NotFound("the Course is not found");
            }

            return Ok(obj);

        }

        [HttpGet("GetStCs")]

        public async Task<IActionResult> GetStC()
        {
            return Ok(await stcService.GetAll());
        }

        [HttpGet("Relationstudent{id}")]
        public async Task<IActionResult> GetStcById(int id)
        {
            var obj = await _context.StCs.FirstOrDefaultAsync(c => c.StId == id);
            if (obj == null)
            {
                return NotFound("the Relation is not found");
            }

            return Ok(obj);

        }


        ////////////////post/////////////
        [HttpPost("Add{Students}")]
        public async Task<IActionResult> AddStudent(StudentModel model)
        {
            var obj = new Student()
            {
                Name = model.Name,
            };
            await _context.Students.AddAsync(obj);
            await _context.SaveChangesAsync();
            return Ok(obj);

        }
        [HttpPost("Add/{Courses}")]
        public async Task<IActionResult> AddCourse(CourseModel model)
        {
            var obj = new Courses()
            {
                Name = model.Name,
            };
            await _context.Courses.AddAsync(obj);
            await _context.SaveChangesAsync();
            return Ok(obj);

        }
        [HttpPost("Relations/{add}")]
        public async Task<IActionResult> AddRelation(StCModel model)
        {
            var obj = new StC()
            {
                StId=model.stId,
                CId=model.CId,
                Date=DateTime.Now
            };
            await _context.StCs.AddAsync(obj);
            await _context.SaveChangesAsync();
            return Ok(obj);

        }
        /////////////////put///////
        [HttpPut("Edit{Student}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentModel model)
        {

            var obj = await _context.Students.FirstOrDefaultAsync(c => c.Id == id);
            if (obj == null)
            {
                return NotFound("the Student is not found");
            }
            obj.Name = model.Name;
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("Edit/{Course}")]
        public async Task<IActionResult> UpdateCourse(int id, CourseModel model)
        {

            var obj = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (obj == null)
            {
                return NotFound("the Course is not found");
            }
            obj.Name = model.Name;
            await _context.SaveChangesAsync();
            return Ok();
        }
        ///////Delete
        [HttpDelete("Delete{Student}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {

            var obj = await _context.Students.FirstOrDefaultAsync(c => c.Id == id);
            if (obj == null)
            {
                return NotFound("the student is not found");
            }

            _context.Students.Remove(obj);
            await _context.SaveChangesAsync();

            return Ok();

        }
        [HttpDelete("Delete/{Course}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {

            var obj = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (obj == null)
            {
                return NotFound("the course is not found");
            }

            _context.Courses.Remove(obj);
            await _context.SaveChangesAsync();

            return Ok();

        }

        [HttpDelete("Relation/{Delete}")]
        public async Task<IActionResult> Deletestc(int stid,int cid)
        {

            var obj = await _context.StCs.FirstOrDefaultAsync(c => c.StId == stid && c.CId==cid);
            if (obj == null)
            {
                return NotFound("the Relation is not found");
            }

            _context.StCs.Remove(obj);
            await _context.SaveChangesAsync();

            return Ok();

        }

    }
}
