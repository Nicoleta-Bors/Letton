namespace Letton.Domain.Entities.Product
{
     public class UpdateProductData
     {
          public int ProductId { get; set; }

          public string ProductName { get; set; }

          public double Price { get; set; }

          public string Description { get; set; }

          public string Image { get; set; }
     }
}
