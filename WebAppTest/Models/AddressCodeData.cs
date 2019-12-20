using System.ComponentModel.DataAnnotations;

namespace WebAppTest.Models
{
   public class AddressCodeData
   {
      [Required]
      [MinLength(2)]
      public string Uf { get; set; }

      [Required]
      [MinLength(3)]
      public string City { get; set; }
      
      [Required]
      [MinLength(3)]
      public string Address { get; set; }
   }
}
