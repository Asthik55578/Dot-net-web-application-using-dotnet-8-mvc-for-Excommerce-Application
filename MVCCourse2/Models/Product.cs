using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MVCCourse2.Models
{
    public class Product
    {
        [Name("ProductID")]
        [Required]
        public int ProductId { get; set; }

        [Name("ProductName")]
        public string ProductName { get; set; } = string.Empty;

        [Name("Category")]
        public string CategoryName { get; set; } = string.Empty;

        [Name("Price")]
        public decimal Price { get; set; }

        [Name("ImageURL")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
