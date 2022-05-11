using System;
using System.Linq;
using System.Web;
using Letton.Helpers;
using Letton.Domain.Entities.User;
using Letton.Domain.Entities.User.Login;
using Letton.Domain.Entities.User.Register;
using Letton.Domain.Entities.Session;
using Letton.BusinessLogic.DBModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Letton.BusinessLogic.Core
{
     public class UserApi
     {
          internal ULoginResp UserLoginAction(ULoginData data)
          {

               UDbTable result;
               var validate = new EmailAddressAttribute();
               if (validate.IsValid(data.Credential))  // Email log-in
               {
                    var pass = LoginHelper.HashGen(data.Password);
                    using (var db = new UserContext())
                    {
                         result = db.Users.FirstOrDefault(u => u.Email == data.Credential && u.Password == pass);
                    }

                    if (result == null)
                    {
                         return new ULoginResp { Status = false, StatusMsg = "The Email or Password is Incorrect" };
                    }

                    using (var todo = new UserContext())
                    {
                         result.PrivateIp = data.PrivateIp;
                         result.LastLogin = data.LastLogin;
                         todo.Entry(result).State = EntityState.Modified;
                         todo.SaveChanges();
                    }

                    return new ULoginResp { Status = true };
               }
               else  // UserName log-in
               {
                    var pass = LoginHelper.HashGen(data.Password);
                    using (var db = new UserContext())
                    {
                         result = db.Users.FirstOrDefault(u => u.UserName == data.Credential && u.Password == pass);
                    }

                    if (result == null)
                    {
                         return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                    }

                    using (var todo = new UserContext())
                    {
                         result.PrivateIp = data.PrivateIp;
                         result.LastLogin = data.LastLogin;
                         todo.Entry(result).State = EntityState.Modified;
                         todo.SaveChanges();
                    }

                    return new ULoginResp { Status = true };
               }
          }

          public URegisterResp UserRegisterAction(URegisterData data)
          {
               UDbTable register = new UDbTable()
               {
                    UserName = data.UserName,
                    Email = data.Email,
                    Password = LoginHelper.HashGen(data.Password),
                    Level = data.Level,
                    RegisterDate = data.RegisterDate,
                    PrivateIp = data.PrivateIp,
                    LastLogin = data.LastLogin,
               };

               UDbTable result;
               using (var db = new UserContext())
               {
                    result = db.Users.FirstOrDefault(m => m.UserName == register.UserName);
                    if (result != null)
                    {
                         return new URegisterResp() { Status = false, StatusMsg = "User already exists." };
                    }

                    result = db.Users.FirstOrDefault(m => m.Email == register.Email);
                    if (result != null)
                    {
                         return new URegisterResp() { Status = false, StatusMsg = "User already exists." };
                    }

                    db.Users.Add(register);
                    db.SaveChanges();
               }

               return new URegisterResp() { Status = true };
          }

          public HttpCookie Cookie(string loginCredential)
          {
               var apiCookie = new HttpCookie("X-KEY")
               {
                    Value = CookieGenerator.Create(loginCredential)
               };

               using (var db = new SessionContext())
               {
                    SessionsDbTable curent;
                    var validate = new EmailAddressAttribute();
                    if (validate.IsValid(loginCredential))
                    {
                         curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                    }
                    else
                    {
                         curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                    }

                    if (curent != null)
                    {
                         curent.CookieString = apiCookie.Value;
                         curent.ExpireTime = DateTime.Now.AddMinutes(60);
                         apiCookie.Expires = curent.ExpireTime;
                         using (var todo = new SessionContext())
                         {
                              todo.Entry(curent).State = EntityState.Modified;
                              todo.SaveChanges();
                         }
                    }
                    else
                    {
                         db.Sessions.Add(new SessionsDbTable
                         {
                              Username = loginCredential,
                              CookieString = apiCookie.Value,
                              ExpireTime = DateTime.Now.AddMinutes(60)
                         });
                         db.SaveChanges();
                    }
               }

               return apiCookie;
          }
          internal UserMinimal UserCookie(string cookie)
          {
               SessionsDbTable session;
               UDbTable curentUser;

               using (var db = new UserContext())
               {
                    session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
               }

               if (session == null) return null;
               using (var db = new UserContext())
               {
                    var validate = new EmailAddressAttribute();
                    if (validate.IsValid(session.Username))
                    {
                         curentUser = db.Users.FirstOrDefault(u => u.Email == session.Username);
                    }
                    else
                    {
                         curentUser = db.Users.FirstOrDefault(u => u.Email == session.Username);
                    }
               }

               if (curentUser == null) return null;
               var userprofile = new UserMinimal
               {
                    Id = curentUser.Id,
                    UserName = curentUser.UserName,
                    Email = curentUser.Email,
                    Level = curentUser.Level
               };

               return userprofile;
          }
     }
}
