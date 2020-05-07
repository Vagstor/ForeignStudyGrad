using DataModels;
using ForeignStudyGrad.Models;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignStudyGrad.Services
{
    public class ThemeService
    {
       private ForeignstudyDB _db;
       private AccountService _accService;
        public ThemeService(ForeignstudyDB db, AccountService accountService)
        {
            _db = db;
            _accService = accountService;
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
        public bool CheckIfWordPresent(string word)
        {
            var q = from d in _db.Dictionaries
                    where d.WordOriginal == word
                    select d;
            if (q.Count() == 0)
                return false;
            else return true;
        }
        public void AddDictionaryWords(List<TranslationPairs> pairs, string username)
        {
            foreach (TranslationPairs pair in pairs)
            {
                if (!CheckIfWordPresent(pair.Word))
                {
                    Dictionary dic = new Dictionary();
                    dic.UserId = _accService.GetByLogin(username).UserId;
                    dic.WordId = Guid.NewGuid();
                    dic.WordOriginal = pair.Word;
                    dic.WordTranslation = pair.Translation;
                    _db.Insert(dic);
                }
                else 
                {
                    Dictionary dic = new Dictionary();
                    //dic.UserId = _accService.GetByLogin(username).UserId;
                    //dic.WordId = Guid.NewGuid();
                    dic.WordOriginal = pair.Word;
                    dic.WordTranslation = pair.Translation;
                    _db.Update(dic);
                }
            }
        }
    }
}
