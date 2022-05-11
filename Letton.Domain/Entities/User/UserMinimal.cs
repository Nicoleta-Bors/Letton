using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Letton.Domain.Enums;

namespace Letton.Domain.Entities.User
{
     public class UserMinimal
     {
          public int Id { get; set; }
          public string UserName { get; set; }
          public string Email { get; set; }
          public URole Level { get; set; }
     }
}