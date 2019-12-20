using System.ComponentModel.DataAnnotations;

namespace WebAppTest.Models
{
   public class ZipCodeData
   {
      [Required]
      public string Value { get; set; }
   }
}
