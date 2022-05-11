using System;

namespace Letton.Domain.Entities.Product
{
     public class AddProductData
     {
          public string ProductName { get; set; }
          public double Price { get; set; }
          public string Description { get; set; }
          public string Image { get; set; }
          public DateTime CreatedDate { get; set; }
     }
}
