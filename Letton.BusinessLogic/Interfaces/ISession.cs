using System.Web;
using Letton.Domain.Entities.User;
using Letton.Domain.Entities.User.Login;
using Letton.Domain.Entities.User.Register;


namespace Letton.BusinessLogic.Interfaces
{
     public interface ISession
     {
          ULoginResp UserLogin(ULoginData data);
          URegisterResp UserRegister(URegisterData data);
          HttpCookie GenCookie(string loginCredential);
          UserMinimal GetUserByCookie(string apiCookieValue);
     }
}
