using System;
using System.Collections;
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
        void AddGroup(CourseGroup group);
        void UpdateGroup(CourseGroup group);
        CourseGroup GetById(int groupId);

       



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

        List<ShowCourseListItemViewModel> GetPopularCourse();
        bool IsFree(int courseId);
        List<Course> GetAllMasterCourses(string userName);
        List<CourseEpisode> GetCourseEpisodesByCourseId(int courseId);
        bool AddEpisode(AddEpisodeViewModel episodeViewModel  , string userName);
        #endregion

        #region Episode
        List<CourseEpisode> GetListEpisodeCourse(int courseId);
        bool CheckExistFile(string fileName);
        int AddEpisode(CourseEpisode episode , IFormFile episodeFile);
        CourseEpisode GetEpisodeById(int episodeId);
        void EditEpisode(CourseEpisode episode, IFormFile episodeFile);

        #endregion

        #region Comments

        void AddComment(CourseComment comment);
       Tuple<List<CourseComment>,int> GetCourseComments(int courseId, int pageId = 1);
        IEnumerable GetSubGroupForManageCourse(CourseGroup courseGroup);


        #endregion
        #region  Course Vote

        void AddsVote(int userId, int courseId, bool vote);
        Tuple<int , int> GetCourseVotes(int courseId);
        ///istrahati  maasdomiiii

        #endregion
    }
}
