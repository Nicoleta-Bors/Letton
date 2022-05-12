using Letton.Domain.Enums;

namespace Letton.Domain.Entities.Product
{
     public class ProductDetailData
     {
          public int Id { get; set; }
          public string UserName { get; set; }
          public string Email { get; set; }
          public URole Level { get; set; }
          public ProductsDbTable Product { get; set; }
     }
}
