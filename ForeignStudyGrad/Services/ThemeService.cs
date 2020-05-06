using DataModels;
using ForeignStudyGrad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignStudyGrad.Services
{
    public class ThemeService
    {
       private ForeignstudyDB _db;
        public ThemeService(ForeignstudyDB db)
        {
            _db = db;
        }
        public ThemeViewModel GetThemeInfoById(Guid id)
        {
            var q = from t in _db.Themes
                    where t.ThemeId == id
                    select t;
            ThemeViewModel output = new ThemeViewModel()
            {
                Goal = q.FirstOrDefault().ThemeGoal,
                Themename = q.FirstOrDefault().ThemeName,
                Link = q.FirstOrDefault().Viewname
            };
            return output;
        }
        public List<Cours> SearchCoursesWith(string text)
        {
            var q = from c in _db.Courses
                    where c.CourseName.Contains(text)
                    select c;
            return q.ToList();
        }
    }
}
