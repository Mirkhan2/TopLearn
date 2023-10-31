using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayeer.Entities.Course;

namespace TopLearn.Wab.Pages.Admin.CourseGroups
{
    public class IndexModel : PageModel
    {
        private ICourseService _courseService;
        public IndexModel(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public List<CourseGroup> CourseGroups { get; set; }
        public void OnGet()
        {
            CourseGroups = _courseService.GetAllGroup();
        }
    }
}
