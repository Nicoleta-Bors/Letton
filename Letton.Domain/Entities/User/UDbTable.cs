using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Letton.Domain.Enums;

namespace Letton.Domain.Entities.User
{
     public class UDbTable
     {
          //Id
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }

          //UserName
          [
              Display(Name = "Prenume"),
              Required(ErrorMessage = "Acest câmp este obligatoriu."),
              MinLength(4, ErrorMessage = "Lungimea minimă 4 caractere."),
              MaxLength(20, ErrorMessage = "Lungimea maximă 20 caractere.")
          ]
          public string UserName { get; set; }

          //Email
          [
              Display(Name = "Adresa de email"),
              Required(ErrorMessage = "Acest câmp este obligatoriu."),
              DataType(DataType.EmailAddress, ErrorMessage = "Introduce-ți o adresă de email validă.")
          ]
          public string Email { get; set; }

          //Password
          [
              Display(Name = "Parolă"),
              Required(ErrorMessage = "Acest câmp este obligatoriu."),
              MinLength(8, ErrorMessage = "Lungimea minimă 8 caractere."),
              MaxLength(40, ErrorMessage = "Lungimea maximă 40 caractere."),
              DataType(DataType.Password)
          ]
          public string Password { get; set; }

          //Level
          public URole Level { get; set; }

          //RegisterDate
          [DataType(DataType.Date)]
          public DateTime RegisterDate { get; set; }


          //PrivateIp
          [StringLength(15)]
          public string PrivateIp { get; set; }

          //LastLogin
          [DataType(DataType.Date)]
          public Nullable<DateTime> LastLogin { get; set; }

     }
}
