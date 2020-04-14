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
        public List<String> CheckLogin(string username, string password)
        {
            var users = new List<User>();
            users = _db.Users.ToList();
            foreach (var user in users)
            {
                if ((username == user.UserLogin) && (password == user.UserPassword))
                {
                    return new List<String> { user.UserLogin, user.UserPassword, Convert.ToString(user.UserId) };
                }
                else
                    if ((username == user.UserEmail) && (password == user.UserPassword))
                {
                    return new List<String> { user.UserLogin, user.UserPassword, Convert.ToString(user.UserId) };
                }
            }
            return null;
        }

        public User GetByLogin(string username)
        {
            var q = from u in _db.Users
                    where u.UserLogin == username || u.UserEmail == username
                    select u;
            return q.FirstOrDefault();
        }

        public bool CheckIfEmailVacant(string email)
        {
            var q = from u in _db.Users
                    where u.UserEmail == email
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
                    where u.UserLogin == login
                    select u;
            if (q.FirstOrDefault() == null)
            {
                return true;
            }
            else
                return false;
        }

        public void AddNewUser(string login, string password, string email, string role)
        {
            User user = new User();
            user.UserEmail = email;
            user.UserId = Guid.NewGuid();
            user.UserLogin = login;
            user.UserPassword = password;
            _db.Insert(user);
        }

        
    }
}
