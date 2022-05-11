using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Letton.BusinessLogic.Core;
using Letton.BusinessLogic.Interfaces;
using Letton.Domain.Entities.Product;

namespace Letton.BusinessLogic
{
     internal class ProductBL : ProductApi, IProduct
     {
          public AddProductResp AddProduct(AddProductData product)
          {
               return AddProductAction(product);
          }

          public List<ProductsDbTable> GetAllProducts()
          {
               return GetAllProductsAction();
          }

          public ProductsDbTable GetProductById(int productId)
          {
               return GetProductAction(productId);
          }

          public DeleteProductResp DeleteProduct(int productId)
          {
               return DeleteProductAction(productId);
          }

          public UpdateProductResp UpdateProduct(UpdateProductData data)
          {
               return ProductUpdateAction(data);
          }
     }
}
