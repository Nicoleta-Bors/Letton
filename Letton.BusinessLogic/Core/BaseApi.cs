using System.Linq;
using Letton.Domain.Entities.Product;
using Letton.BusinessLogic.DBModel;

namespace Letton.BusinessLogic.Core
{
     public class BaseApi
     {
          internal ProductsDbTable GetProduct(int productId)
          {
               ProductsDbTable product;

               using (var db = new ProductContext())
               {
                    product = db.Products.FirstOrDefault(x => x.ProductId == productId);
               }

               return product;
          }
     }
}
