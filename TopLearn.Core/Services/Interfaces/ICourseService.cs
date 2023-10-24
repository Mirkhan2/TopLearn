using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using TopLearn.Core.DTOs.Course;
using TopLearn.DataLayeer.Entities.Course;

namespace TopLearn.Core.Services.Interfaces
{
    public interface ICourseService
    {
        #region Group
        List<CourseGroup> GetAllGroup();
        List<SelectListItem> GetGroupForManageCourse();
        List<SelectListItem> GetSubGroupForManageCourse(int groupId);
        List<SelectListItem> GetTeachers();
        List<SelectListItem> GetLevels();
        List<SelectListItem> GetStatues();


        #endregion

        #region Course  

        List<ShowCourseForAdminViewModel> GetCourseForAdmin();
    
        int AddCourse(Course course , IFormFile imgCourse , IFormFile courseDemo);   

        Course GetCourseById(int courseid);

        void UpdateCourse(Course course , IFormFile imgCourse , IFormFile courseDemo);

       Tuple<List<ShowCourseListItemViewModel>,int> GetCourse(int pageId = 1 ,
            string  filter ="", string getType ="all" ,string orderByType = "date",
            int startPrice= 0 , int endPrice=0 ,List<int> selectedGroups = null , int take = 0);

        Course GetCourseForShow(int courseid);
        #endregion

        #region Episode
        List<CourseEpisode> GetListEpisodeCourse(int courseId);
        bool CheckExistFile(string fileName);
        int AddEpisode(CourseEpisode episode , IFormFile episodeFile);
        CourseEpisode GetEpisodeById(int episodeId);
        void EditEpisode(CourseEpisode episode, IFormFile episodeFile);

        #endregion
    }
}
