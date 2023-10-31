using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayeer.Entities.Course;

namespace TopLearn.Wab.Pages.Admin.CourseGroups
{
    public class EditGroupModel : PageModel
    {
        private ICourseService _courseService;

        public EditGroupModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [BindProperty]
        public CourseGroup CourseGroups { get; set; }

        public void OnGet(int id)
        {
            CourseGroups = _courseService.GetById(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _courseService.UpdateGroup(CourseGroups);

            return RedirectToPage("Index");
        }
    }
}
