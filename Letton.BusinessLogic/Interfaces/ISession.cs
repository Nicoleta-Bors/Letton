using System.Web;
using Letton.Domain.Entities.User;

namespace Letton.BusinessLogic.Interfaces
{
     public interface ISession
     {
          ULoginResp UserLogin(ULoginData data);
          /*HttpCookie GenCookie(string loginCredential);*/
          UserMinimal GetUserByCookie(string apiCookieValue);
     }
}
