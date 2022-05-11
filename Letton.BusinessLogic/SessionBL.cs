using System.Web;
using Letton.BusinessLogic.Core;
using Letton.BusinessLogic.Interfaces;
using Letton.Domain.Entities.User.Login;
using Letton.Domain.Entities.User.Register;
using Letton.Domain.Entities.User;


namespace Letton.BusinessLogic
{
     public class SessionBL : UserApi, ISession  //clasa SessionBL mosteneste UserApi si ISession
     {
          public ULoginResp UserLogin(ULoginData data)
          {
               return UserLoginAction(data);
          }
          public URegisterResp UserRegister(URegisterData data)
          {
               return UserRegisterAction(data);
          }
          public HttpCookie GenCookie(string loginCredential)
          {
               return Cookie(loginCredential);
          }

          public UserMinimal GetUserByCookie(string apiCookieValue)
          {
               return UserCookie(apiCookieValue);
          }
     }
}
