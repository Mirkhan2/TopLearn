using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopLearn.Core.Services.Interfaces;
using TopLearn.DataLayeer.Context;
using TopLearn.DataLayeer.Entities.Course;

namespace TopLearn.Core.Services
{
    public class CourseService : ICourseService
    {
       private TopLearnContext _context;
        public CourseService(TopLearnContext context)
        {
            _context = context;
        }

        public List<CourseGroup> GetAllGroup()
        {
           return _context.CourseGroups.ToList();
        }
    }
}
