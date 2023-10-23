using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayeer.Entities.Course;

namespace TopLearn.Wab.Pages.Admin.Courses
{
    public class IndexEpisodeModel : PageModel
    {
       private ICourseService _courseService;
        public IndexEpisodeModel(ICourseService courseService)
        {
                _courseService = courseService;
        }
        public List<CourseEpisode> CourseEpisode { get; set; }

        public void OnGet(int id)
        {
            ViewData["Courseid"] = id;
            CourseEpisode = _courseService.GetListEpisodeCourse(id);
        }
    }
}
