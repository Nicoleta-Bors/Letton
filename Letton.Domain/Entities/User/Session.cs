using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letton.Domain.Entities.User
{
     public class Session
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }

          [Required]
          [StringLength(30)]
          public string UserEmail { get; set; }

          [Required]
          public string CookieString { get; set; }

          [Required]
          public DateTime ExpireTime { get; set; }
     }
}
