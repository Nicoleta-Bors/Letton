using System.Data.Entity;
using Letton.Domain.Entities.User;
using Letton.Domain.Entities.Session;

namespace Letton.BusinessLogic.DBModel
{
     public class UserContext : DbContext
     {
          public UserContext() : base("name = LETTON") // connectionstring name define in your web.config
          {
          }
          public virtual DbSet<SessionsDbTable> Sessions { get; set; }
          public virtual DbSet<UDbTable> Users { get; set; }
     }
}
