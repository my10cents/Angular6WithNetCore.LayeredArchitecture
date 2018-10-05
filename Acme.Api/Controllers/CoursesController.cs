using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Acme.Business.Entities;
using Acme.Business.Data.Contracts;
using Acme.Business.Data.BusinessContracts;
using Acme.Api.Models;
using AutoMapper;

namespace Acme.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {

        private readonly ISchoolContext _context;
        private readonly ICourseBusiness _courseBusiness;
        private readonly IMapper _mapper;


        public CoursesController(ISchoolContext context, ICourseBusiness courseBusiness, IMapper mapper)
        {
            _context = context;
            _courseBusiness = courseBusiness;
            _mapper = mapper;
        }


        [HttpGet]
        public IEnumerable<CourseOut> GetCourse()
        {
            List<Course> list = _context.Course.ToList();
            List<CourseOut> result = _mapper.Map<List<CourseOut>>(list);
            return result;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _context.Course.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse([FromRoute] int id, [FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != course.Id)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> PostCourse([FromBody] Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _courseBusiness.Add(course);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CourseExists(course.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Course.Remove(course);
            await _context.SaveChangesAsync();

            return Ok(course);
        }


        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.Id == id);
        }

    }
}