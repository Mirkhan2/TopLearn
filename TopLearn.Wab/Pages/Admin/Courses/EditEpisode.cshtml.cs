using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayeer.Entities.Course;

namespace TopLearn.Wab.Pages.Admin.Courses
{
    public class EditEpisodeModel : PageModel
    {
       private ICourseService _courseService;
        public EditEpisodeModel(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [BindProperty]
        public CourseEpisode CourseEpisode{ get; set; }
        public void OnGet(int id)
        {
            CourseEpisode = _courseService.GetEpisodeById(id);
        }
        public IActionResult OnPost(IFormFile fileEpisode) 
        {
            if(!ModelState.IsValid)
          
            if (_courseService.CheckExistFile(fileEpisode.FileName))
            {
                ViewData["IsExistFile"] = true;
                return Page();
            }
            _courseService.EditEpisode(CourseEpisode, fileEpisode);

            return Redirect("/Admin/Courses/IndexEpisode/" + CourseEpisode.CourseId);
        }
    }
}
