using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TopLearn.Core.Services;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayeer.Entities.Course;

namespace TopLearn.Wab.Pages.Admin.Courses
{
    public class CreateCourseModel : PageModel
    {
        ICourseService _courseService;
        public CreateCourseModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [BindProperty]
        public Course Course { get; set; }

      
        public void OnGet()
        {
            var groups = _courseService.GetGroupForManageCourse();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text");
             
            var subGroups = _courseService.GetSubGroupForManageCourse(int.Parse
                (groups.First().Value));
            ViewData["SubGroups"] = new SelectList(subGroups, "Value", "Text");

            var teachers = _courseService.GetTeachers();
            ViewData["Teachers"] = new SelectList (teachers, "Value", "Text");

            var levels = _courseService.GetLevels();
            ViewData["levels"] = new SelectList(levels, "Value", "Text");

            var statues = _courseService.GetStatues();
            ViewData["statues"] = new SelectList(statues, "Value", "Text");

        }
        public IActionResult OnPost(IFormFile imgCourseUp , IFormFile demoUp)
        {
            if (!ModelState.IsValid)
                return Page();
            
          _courseService.AddCourse(Course ,imgCourseUp , demoUp);

            return RedirectToPage("Index");

        }
    }
}
