using MVCCourse2.Models;
namespace MVCCourse2.ViewModels
{
    public class ProductViewModel
    {
        // List of categories for dropdown or selection
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        // The product details to bind in forms or display
        public Product Product { get; set; } = new Product();

        // Added: List of products for scenarios like displaying all products on a page
        public IEnumerable<Product> Products { get; set; } = new List<Product>();

        // Added: Error message or status for form validations or user feedback
        public string? ErrorMessage { get; set; }

        // Added: Success message or status for operations like add, update, or delete
        public string? SuccessMessage { get; set; }

        // Added: Filter option for product search by category or keyword
        public string? FilterCategory { get; set; }
        public string? SearchKeyword { get; set; }
    }
}
