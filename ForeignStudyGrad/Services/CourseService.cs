using DataModels;
using ForeignStudyGrad.Models;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignStudyGrad.Services
{
    public class CourseService
    {
        private ForeignstudyDB _db;
        private AccountService _accService;

        public CourseService(ForeignstudyDB db, AccountService accService)
        {
            _db = db;
            _accService = accService;
        }
        public void SubscribeUserToCourse(Guid courseid, string username)
        {
            Subscription subscription = new Subscription()
            {
                SubId = new Guid(),
                CourseId = courseid,
                UserId = _accService.GetByLogin(username).UserId
            };
            _db.Insert(subscription);
        }
        public void MatchWithSubscriptions(List<CourseModel> courseList, string username)
        {
            List<CourseModel> userCourseList = ConvertDBCourseToModel(GetUserCourses(username));
            if (userCourseList.Count() != 0)
                for (int i = 0; i < userCourseList.Count(); i++)
                {
                    string foundSub = courseList.Find(x => x.id == userCourseList[i].id).name;
                    courseList.Find(x => x.name == foundSub).ifSubscribed = true;
                }
        }
        public List<Cours> SearchCoursesWith(string text)
        {
            var q = from c in _db.Courses
                    where c.CourseName.Contains(text)
                    select c;
            return q.ToList();
        }
        public List<PairModel> ConvertDBDictionaryPairsToModel(List<Dictionary> dList)
        {
            List<PairModel> pairModel = new List<PairModel>();
            foreach (Dictionary dic in dList)
            {
                PairModel element = new PairModel()
                {
                    Original = dic.WordOriginal,
                    Translation = dic.WordTranslation
                };
                pairModel.Add(element);
            }
            return pairModel;
        }
        public List<CourseModel> ConvertDBCourseToModel(List<Cours> courselist)
        {
            List<CourseModel> courseModel = new List<CourseModel>();
            foreach (Cours course in courselist)
            {
                CourseModel element = new CourseModel();
                element.name = course.CourseName;
                element.id = course.CourseId;
                courseModel.Add(element);
            }
            return courseModel;
        }
        public List<ThemeModel> ConvertDBThemeToModel(List<Theme> themelist)
        {
            List<ThemeModel> themeModel = new List<ThemeModel>();
            foreach (Theme theme in themelist)
            {
                ThemeModel element = new ThemeModel();
                element.themeName = theme.ThemeName;
                element.themeId = theme.ThemeId;
                themeModel.Add(element);
            }
            return themeModel;
        }
        public List<Cours> GetUserCourses(string login)
        {
            return GetCoursesInfoById(GetUserSubs(login));
        }
        public List<Guid> GetUserSubs(string login)
        {
            _accService.GetByLogin(login);
            var q = from s in _db.Subscriptions
                    where s.UserId == _accService.GetByLogin(login).UserId
                    select s.CourseId;
            if (q.ToList() != null) return q.ToList();
            else { return new List<Guid>(); };
        }
        public List<Theme> GetCourseThemes(Guid course)
        {
            var q = from c in _db.Themes
                    where c.CourseId == course
                    select c;
            if (q.ToList() != null) return q.OrderBy(theme => theme.ThemeNumber).ToList();
            else { return new List<Theme>(); }
        }
        public List<Cours> GetCoursesInfoById(List<Guid> courseidlist)
        {
            var q = from c in _db.Courses
                    where courseidlist.Contains(c.CourseId)
                    select c;
            return q.ToList();
        }
        public List<Dictionary> GetUserDictionary(string username)
        {
            var q = from d in _db.Dictionaries
                    where d.UserId == _accService.GetByLogin(username).UserId
                    select d;
            if (q.ToList() != null) return q.ToList();
            else { return new List<Dictionary>(); }
        }
        public List<Cours> GetAllCourses()
        {
            return _db.Courses.ToList();
        }
    }
}
