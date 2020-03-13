using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ForeignStudyGrad.Models;
using LinqToDB;
using LinqToDB.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using DataModels;

namespace ForeignStudyGrad.Services
{
    public class SiteService
    {
        private MainDb _db;

        public SiteService(MainDb db)
        {
            _db = db;
        }
        public bool IsUsersSiteAlreadyInDB(Site site)
        {
            return _db.Sites.Where(p => p.UserId == site.UserId).Any(o => o.Url == site.Url);
        }

        public Site GetSite(Guid id)
        {
            return _db.Sites.Find(id);
        }
        public List<String> CheckLogin(string username, string password)
        {
            var users = new List<User>();
            users = _db.Users.ToList();
            foreach (var user in users)
            {
                if ((username == user.Login) && (password == user.Password))
                {
                    return new List<String> { user.Login, user.Password, Convert.ToString(user.Id) };
                }
                else
                    if ((username == user.Email) && (password == user.Password))
                {
                    return new List<String> { user.Login, user.Password, Convert.ToString(user.Id) };
                }
            }
            return null;
        }

        public User GetByLogin(string username)
        {
            var q = from u in _db.Users
                    where u.Login == username || u.Email == username
                    select u;
            return q.FirstOrDefault();
        }

        public bool CheckIfEmailVacant(string email)
        {
            var q = from u in _db.Users
                    where u.Email == email
                    select u;
            if (q.FirstOrDefault() == null)
            {
                return true;
            }
            else
                return false;
        }

        public bool CheckIfLoginVacant(string login)
        {
            var q = from u in _db.Users
                    where u.Login == login
                    select u;
            if (q.FirstOrDefault() == null)
            {
                return true;
            }
            else
                return false;
        }

        public DateTime AddTime(Guid userId, Guid siteId)
        {
            return _db.Sites.Where(p => p.UserId == userId).Where(p => p.Id == siteId).FirstOrDefault().AddTime;
        }
        public List<Site> GetSites(Guid userId)
        {
            var query = from sites in _db.Sites
                        where sites.UserId == userId
                        select sites;
            return query.ToList();
        }
        public List<Site> GetAllSites()
        {
            return _db.Sites.ToList();
        }
        public List<Visit> GetSiteVisits(string url)
        {
            var visits = _db.Visits.Where(p => p.Url == url).OrderBy(p => p.VisitTime);
            return visits.ToList();
        }
        public void EditSite(Site site)
        {
            if (_db.Sites.Where(p => p.Url == site.Url).FirstOrDefault() == null)
            {
                _db.Sites.Where(p => p.Id == site.Id)
            .Set(p => p.Url, site.Url)
            .Update();
            }
        }
        public void UpdateLastStatus(Guid id, int status)
        {
            _db.Sites.Where(p => p.Id == id)
            .Set(p => p.LastStatus, status)
            .Update();
        }
        public void UpdateSite(Site site, int status)
        {
            _db.Sites.Where(p => p.Id == site.Id)
         .Set(p => p.LastStatus, status)
         .Update();
        }
        public DateTime FirstVisit(Guid userId, Guid siteId)
        {
            var query = from v in _db.Visits
                        join vr in _db.Sites on v.SiteId equals vr.Id
                        where vr.UserId == userId
                        where vr.Id == siteId
                        orderby v.VisitTime
                        select v;
            var time = query.OrderBy(p => p.VisitTime).FirstOrDefault();
            return time.VisitTime;
        }

        public void AddNewUser(string login, string password, string email)
        {
            User user = new User();
            user.Email = email;
            user.Id = Guid.NewGuid();
            user.Login = login;
            user.Password = password;
            _db.Insert(user);
        }

        //public List<Visit> GetVisits(Guid userId, Guid siteId)
        //{
        //    var query = from v in _db.Visits
        //                join vr in _db.Sites on v.SiteId equals vr.Id
        //                where vr.UserId == userId
        //                where vr.Id == siteId
        //                orderby v.VisitTime descending
        //                select v;
        //    return query.ToList();
        //}
        //public void SaveSite(Site site)
        //{
        //    if ((site.Url != null) && (!IsUsersSiteAlreadyInDB(site)))
        //    {
        //        _db.Insert(site);
        //    }
        //}

        //public void SaveVisit(Visit visit)
        //{
        //    _db.Insert(visit);
        //    _db.Sites.Where(p => p.Id == visit.SiteId)
        //        .Set(p => p.LastStatus, visit.Status)
        //        .Update();
        //}

        //public int GetSiteStatus(string url)
        //{
        //    try
        //    {
        //        HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        //        HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
        //        if ((int)myHttpWebResponse.StatusCode == 200)
        //        {
        //            return (int)myHttpWebResponse.StatusCode;
        //        }
        //        else return 0;

        //    }
        //    catch (WebException e)
        //    {
        //        return (int)e.Status;
        //    }
        //}
    }
}
