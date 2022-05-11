using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Letton.Domain.Entities.Product
{
     public class ProductsDbTable
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int ProductId { get; set; }

          [Required]
          [Display(Name = "Product Name")]
          public string ProductName { get; set; }

          [Required]
          [Display(Name = "Price")]
          public double Price { get; set; }

          [Required]
          [Display(Name = "Description")]
          public string Description { get; set; }

          [Required]
          public string Image { get; set; }

          [DataType(DataType.Date)]
          public DateTime CreatedDate { get; set; }
     }
}
