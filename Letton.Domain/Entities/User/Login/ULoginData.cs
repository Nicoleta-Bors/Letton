using System;

namespace Letton.Domain.Entities.User.Login
{
     public class ULoginData
     {
          public string Credential { get; set; }
          public string Password { get; set; }
          public string PrivateIp { get; set; }
          public DateTime LastLogin { get; set; }
     }
}
