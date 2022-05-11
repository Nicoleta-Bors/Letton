using System;
using System.Collections.Generic;
using System.Linq;
using Letton.BusinessLogic.DBModel;
using Letton.Domain.Entities.Product;

namespace Letton.BusinessLogic.Core
{
     internal class ProductApi : BaseApi
     {
          internal AddProductResp AddProductAction(AddProductData data)
          {
               try
               {
                    ProductsDbTable product = new ProductsDbTable()
                    {
                         ProductName = data.ProductName,
                         Price = data.Price,
                         Description = data.Description,
                         Image = data.Image,
                         CreatedDate = data.CreatedDate,
                    };

                    using (var db = new ProductContext())
                    {
                         db.Products.Add(product);
                         db.SaveChanges();
                    }
                    return new AddProductResp() { Status = true };
               }
               catch (Exception ex)
               {
                    return new AddProductResp() { Status = false, StatusMsg = ex.ToString() };
               }
          }

          internal List<ProductsDbTable> GetAllProductsAction()
          {
               List<ProductsDbTable> Products;

               using (var db = new ProductContext())
               {
                    Products = db.Products.ToList();
               }

               return Products;
          }
          
          internal ProductsDbTable GetProductAction(int productId)
          {
               return GetProduct(productId);
          }

          internal DeleteProductResp DeleteProductAction(int productId)
          {
               ProductsDbTable product;

               using (var db = new ProductContext())    //delete product data from Product table in database
               {
                    product = db.Products.FirstOrDefault(m => m.ProductId == productId);
                    db.Products.Remove(product);
                    db.SaveChanges();
               }

               return new DeleteProductResp() { Status = true };
          }

          internal UpdateProductResp ProductUpdateAction(UpdateProductData data)
          {
               ProductsDbTable product;

               using (var db = new ProductContext())
               {
                    product = db.Products.FirstOrDefault(m => m.ProductId == data.ProductId);

                    product.ProductName = data.ProductName;
                    product.Price = data.Price;
                    product.Description = data.Description;
                    product.Image = data.Image;

                    db.SaveChanges();
               }

               return new UpdateProductResp() { Status = true };
          }
     }
}
