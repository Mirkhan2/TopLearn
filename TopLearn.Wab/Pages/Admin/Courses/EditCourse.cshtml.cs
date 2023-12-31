using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayeer.Entities.Course;

namespace TopLearn.Wab.Pages.Admin.Courses
{
    public class EditCourseModel : PageModel
    {
        ICourseService _courseService;
        public EditCourseModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [BindProperty]
        public Course Course { get; set; }
        public void OnGet(int id)
        {
            Course = _courseService.GetCourseById(id);


            var groups = _courseService.GetGroupForManageCourse();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text" , Course.GroupId);

            List<SelectListItem> subgroups = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Choose it",
                    Value = ""

                }
            };
            subgroups.AddRange(_courseService.GetSubGroupForManageCourse(Course.CourseId));
            string selectedSubGroups = null;
            if (Course.SubGroup != null)
            {
                selectedSubGroups = Course.SubGroup.ToString();
            }

            ViewData["SubGroups"] = new SelectList(subgroups, "Value", "Text", selectedSubGroups);

            var teachers = _courseService.GetTeachers();
            ViewData["Teachers"] = new SelectList(teachers, "Value", "Text",Course.TeacherId);

            var levels = _courseService.GetLevels();
            ViewData["levels"] = new SelectList(levels, "Value", "Text" ,Course.LevelId);

            var statues = _courseService.GetStatues();
            ViewData["statues"] = new SelectList(statues, "Value", "Text" , Course.StatusId);

        }
        public IActionResult OnPost(IFormFile imgCourseUp , IFormFile demoUp)
        {
            if (!ModelState.IsValid)
            
                return Page();
            
            _courseService.UpdateCourse(Course , imgCourseUp, demoUp);
            return RedirectToPage("Index");
        }
    }
}
