using MVCCourse2.Models;

namespace MVCCourse2.ViewModels
{
    public class SalesViewModel
    {
        public int SelectedCategoryId {  get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
