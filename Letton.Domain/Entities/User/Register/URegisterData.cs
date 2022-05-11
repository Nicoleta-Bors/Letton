using System;
using Letton.Domain.Enums;

namespace Letton.Domain.Entities.User.Register
{
     public class URegisterData
     {
          public string UserName { get; set; }
          public string Email { get; set; }
          public string Password { get; set; }
          public URole Level { get; set; }
          public DateTime RegisterDate { get; set; }
          public string PrivateIp { get; set; }
          public DateTime LastLogin { get; set; }
     }
}
