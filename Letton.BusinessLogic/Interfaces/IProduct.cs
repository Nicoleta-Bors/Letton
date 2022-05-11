using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Letton.Domain.Entities.Product;

namespace Letton.BusinessLogic.Interfaces
{
     public interface IProduct
     {
          AddProductResp AddProduct(AddProductData data);
          List<ProductsDbTable> GetAllProducts();
          ProductsDbTable GetProductById(int productId);
          DeleteProductResp DeleteProduct(int productId);
          UpdateProductResp UpdateProduct(UpdateProductData data);
     }
}
