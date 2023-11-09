using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopLearn.DataLayeer.Context;

namespace TopLearn.Wab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseApiController : ControllerBase
    {
         private TopLearnContext _context;

        public CourseApiController(TopLearnContext context)
        {
            _context = context;
        }
        [Produces("application/json")]
        [HttpGet("search")]
        public async Task<IActionResult> Search(string filter = "")
        {
            try
            {
                string term = HttpContext.Request.Query["filter"].ToString(); 
                var courseTitle = _context.Courses
                    .Where(c => c.CourseTitle.Contains(filter))
                    .Select(c => c.CourseTitle)
                    .ToList();
                return Ok(courseTitle);
            }
            catch 
            {

                return BadRequest();
            }
        }
    }
    
}
