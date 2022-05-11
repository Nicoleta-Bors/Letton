using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Letton.Domain.Entities.Session
{
     public class SessionsDbTable
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }

          [Required]
          public string Username { get; set; }

          [Required]
          public string CookieString { get; set; }

          [Required]
          public DateTime ExpireTime { get; set; }
     }
}
