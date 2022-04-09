using System.Web;
using Letton.BusinessLogic.Core;
using Letton.BusinessLogic.Interfaces;
using Letton.Domain.Entities.User;


namespace Letton.BusinessLogic
{
     public class SessionBL : UserApi, ISession  //clasa SessionBL mosteneste UserApi si ISession
     {
          public ULoginResp UserLogin(ULoginData data)
          {
               return UserLoginAction(data);
          }

     /*     public HttpCookie GenCookie(string loginCredential)
          {
               return Cookie(loginCredential);
          }*/

          public UserMinimal GetUserByCookie(string apiCookieValue)
          {
               return UserCookie(apiCookieValue);
          }
     }
}
