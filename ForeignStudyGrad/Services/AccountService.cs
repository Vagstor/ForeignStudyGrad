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
    public class AccountService
    {
        private ForeignstudyDB _db;

        public AccountService(ForeignstudyDB db)
        {
            _db = db;
        }
        public List<UserLogModel> ConvertDbUserToLogModel(List<User> userlist)
        {
            //конвертирует список ORM объектов (из базы данных) в список моделей UserLogModel
            List<UserLogModel> userLogModel = new List<UserLogModel>();
            foreach (User user in userlist)
            {
                UserLogModel element = new UserLogModel();
                element.Password = user.Password;
                element.Login = user.Login;
                userLogModel.Add(element);
            }
            return userLogModel;
        }

        public UserLogModel ConvertDbUserToLogModel(User user)
        {
            //конвертирует список ORM объектов (из базы данных) в список моделей UserLogModel
            UserLogModel userLogModel = new UserLogModel();
            userLogModel.Password = user.Password;
            userLogModel.Login = user.Login;
            return userLogModel;
        }

        public bool CheckLogin(LoginViewModel userToCheck)
        {
            //проверка логина. Если параметры, переданные с формы Login не совпадают ни с одной учетной записью, функция возвращает false, иначе true
            var users = _db.Users.ToList();
            foreach (var user in users)
            {
                if ((userToCheck.user.Login == user.Login) && (userToCheck.user.Password == user.Password))
                {
                    return true;
                }
                else
                    if ((userToCheck.user.Login == user.Email) && (userToCheck.user.Password == user.Password))
                {
                    return true;
                }
            }
            return false;
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

        public void AddNewUser(string login, string password, string email, string role)
        {
            User user = new User();
            user.Email = email;
            user.UserId = Guid.NewGuid();
            user.Login = login;
            user.Password = password;
            _db.Insert(user);
        }
    }
}
