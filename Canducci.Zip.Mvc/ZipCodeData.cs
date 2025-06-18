using System.ComponentModel.DataAnnotations;
namespace Canducci.Zip.Mvc
{
    public sealed class ZipCodeData
    {
        private const string ValidationFormatExpression = @"^(\d{5}-\d{3}|\d{8}|(\d{2}\.\d{3}-\d{3}))$";

        [Required(ErrorMessage = "Invalid Zip Code")]
        [RegularExpression(ValidationFormatExpression, ErrorMessage = "Invalid Zip Code format (#####-###)")]
        public string Value { get; set; }
    }
}
