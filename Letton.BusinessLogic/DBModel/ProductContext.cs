using System.Data.Entity;
using Letton.Domain.Entities.Product;

namespace Letton.BusinessLogic.DBModel
{
     public class ProductContext : DbContext
     {
          public ProductContext() : base("name = LETTON") // connectionstring name define in your web.config
          {
          }

          public virtual DbSet<ProductsDbTable> Products { get; set; }
     }
}
