namespace MVCCourse2.Models
{
    public class CategoriesRepository
    {
       
        private static List<Category> _categories = new List<Category>()
        {
            new Category { CategoryId=1,Name="Tops",Description="A top is an item of clothing that covers at least the chest, but which usually covers most of the upper human body between the neck and the waistline. The bottom of tops can be as short as mid-torso, or as long as mid-thigh. Men's tops are generally paired with pants, and women's with pants or skirts."},
            new Category { CategoryId=2,Name="Bottoms",Description="Jeans, leggings, skirts, shorts, palazzos, and Joggers are some of the most popular types of women's bottomwear. Each category offers a unique look and feel, making it easy for women to choose what suits their style. Jeans are a wardrobe staple for every fashion-forward female, offering a versatile, durable option."},
            new Category { CategoryId=3,Name="Outwear",Description="Outerwear is clothing and accessories worn outdoors, or clothing designed to be worn outside other garments, as opposed to underwear. It can be worn for formal or casual occasions, or as warm clothing during winter."}
        };

        public static void AddCategory(Category category)
        {

            if (_categories != null && _categories.Count > 0)
            {
                var maxId = _categories.Max(c => c.CategoryId);
                category.CategoryId = maxId + 1;
            }
            else
            {
                category.CategoryId = 1;    
            }
            if (_categories == null) _categories = new List<Category>();
            _categories.Add(category);
        }

        public static List<Category> GetCategories() => _categories;

        public static Category? GetCategoryById(int categoryid)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryId ==categoryid);
            if (category != null)
            {
                return new Category
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description
                };
            }
            return null;
        }

        public static void UpdateCategory(int categoryid, Category category)
        {
            if (categoryid != category.CategoryId) return;

            var categoryToUpdate = _categories.FirstOrDefault(c => c.CategoryId == categoryid);
            if (category != null)
                if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }

        public static void DeleteCategory(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}

