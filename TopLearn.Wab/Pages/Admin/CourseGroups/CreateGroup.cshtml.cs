using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayeer.Entities.Course;

namespace TopLearn.Wab.Pages.Admin.CourseGroups
{
    public class CreateGroupModel : PageModel
    {
        private ICourseService _courseService;
        public CreateGroupModel(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [BindProperty]
        public CourseGroup CourseGroups { get; set; }
        public void OnGet(int? id)
        {
            CourseGroups = new CourseGroup()
            {
                ParentId = id,

            };
        }
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            _courseService.AddGroup(CourseGroups);
            return RedirectToPage("Index");
        }
    }
}
