using DataModels;
using ForeignStudyGrad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignStudyGrad.Services
{
    public class CourseService
    {
        private ForeignstudyDB _db;

        public CourseService(ForeignstudyDB db)
        {
            _db = db;
        }
        public List<Cours> GetAllCourses()
        {
            return _db.Courses.ToList();
        }

        public List<Cours> SearchCoursesWith(string text)
        {
            var q = from c in _db.Courses
                    where c.CourseName.Contains(text)
                    select c;
            return q.ToList();
        }
        public List<Cours> GetCoursesInfoById(List<Guid> courseidlist)
        {
            var q = from c in _db.Courses
                    where courseidlist.Contains(c.CourseId)
                    select c;
            return q.ToList();
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
        public List<TestModel> ConvertDBTestToModel(List<Test> testlist)
        {
            List<TestModel> testModel = new List<TestModel>();
            foreach (Test test in testlist)
            {
                TestModel element = new TestModel();
                element.testname = test.TestName;
                testModel.Add(element);
            }
            return testModel;
        }

        public List<LectureModel> ConvertDBLectureToModel(List<Lecture> lecturelist)
        {
            List<LectureModel> lectureModel = new List<LectureModel>();
            foreach (Lecture lecture in lecturelist)
            {
                LectureModel element = new LectureModel();
                element.lecturefile = lecture.LectureFilelink;
                element.lecturename = lecture.LectureName;
                lectureModel.Add(element);
            }
            return lectureModel;
        }
        public List<Cours> GetUserCourses(string login)
        {
            var _siteService = new AccountService(_db);
            return GetCoursesInfoById(GetUserSubs(login, _siteService));
        }
        public List<Guid> GetUserSubs(string login, AccountService _siteService)
        {
            _siteService.GetByLogin(login);
            var q = from s in _db.Subscriptions
                    where s.UserId == _siteService.GetByLogin(login).UserId
                    select s.CourseId;
            if (q.ToList() != null) return q.ToList();
            else { return new List<Guid>(); };
        }
        public List<Theme> GetCourseThemes(Guid course)
        {
            var q = from c in _db.Themes
                    where c.CourseId == course
                    select c;
            if (q.ToList() != null) return q.ToList();
            else { return new List<Theme>(); }
        }
        public List<Test> GetThemeTests(Guid theme)
        {
            var q = from c in _db.Tests
                    where c.ThemeId == theme
                    select c;
            if (q.ToList() != null) return q.ToList();
            else { return new List<Test>(); }
        }
        public List<Lecture> GetThemeLectures(Guid theme)
        {
            var q = from c in _db.Lectures
                    where c.ThemeId == theme
                    select c;
            if (q.ToList() != null) return q.ToList();
            else { return new List<Lecture>(); }
        }
    }
}
