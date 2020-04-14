using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignStudyGrad.Services
{
    public class CourseService
    {
        private MainDb _db;

        public CourseService(MainDb db)
        {
            _db = db;
        }

        public List<Cours> GetAllCourses()
        {
            return _db.Courses.ToList();
        }

        public List<Cours> GetCoursesById(List<Guid> courseidlist)
        {
            var q = from c in _db.Courses
                    where courseidlist.Contains(c.CourseId)
                    select c;

            return q.ToList();
        }
        public List<Cours> GetUserCourses(string login)
        {
            var _siteService = new SiteService(_db);
            return GetCoursesById(GetUserSubs(login, _siteService));
        }
        public List<Guid> GetUserSubs(string login, SiteService _siteService)
        {
            _siteService.GetByLogin(login);
            var q = from s in _db.Subscriptions
                    where s.UserId == _siteService.GetByLogin(login).UserId
                    select s.CourseId;
            return q.ToList();
        }
    }
}
