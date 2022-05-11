using System.Data.Entity;
using Letton.Domain.Entities.Session;

namespace Letton.BusinessLogic.DBModel
{
     public class SessionContext : DbContext
     {
          public SessionContext() : base("name = LETTON") // connectionstring name define in your web.config
          {
          }

          public virtual DbSet<SessionsDbTable> Sessions { get; set; }
     }
}
