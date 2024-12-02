using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using System.IO;

namespace MVCCourse2.Models
{
    public class ProductsRepository
    {
        private static List<Product> _products = LoadProductsFromCsv();
        private static List<PurchaseHistory> _history = LoadHistoryFromCsv();

        private static List<PurchaseHistory> LoadHistoryFromCsv()
        {
            return File.ReadAllLines("D:\\MVCCourse2\\MVCCourse2\\Data\\Purchase_history.csv")
           .Skip(1)
           .Select(line => line.Split(','))
           .Select(parts => new PurchaseHistory
           {
               //ProductId = int.Parse(parts[0]),
               //// Username is the second column
               //ProductName = parts[1],
               //CategoryName = parts[2],
               //Price = int.Parse(parts[3]),
               //ImageUrl = parts[4],
               //// Password is the third column
               UserID = int.Parse(parts[0]),
               ProductID = int.Parse(parts[1]),
               PurchaseDate= DateTime.Parse(parts[2]),

           })
           .ToList();
        }

        public static void AddProduct(Product product)
        {
            if (_products != null && _products.Count > 0)
            {
                var maxId = _products.Max(x => x.ProductId);
                product.ProductId = maxId + 1;
            }
            else
            {
                product.ProductId = 1;
            }
            _products?.Add(product);
            SaveProductsToCsv();
        }

        public static List<Product> GetProducts(bool loadCategory = false)
        {
            return _products ?? new List<Product>();
           //return _products;
        }

        public static Product? GetProductById(int productId, bool loadCategory = false)
        {
            return _products.FirstOrDefault(x => x.ProductId == productId);
        }

        public static void UpdateProduct(int productId, Product product)
        {
            if (productId != product.ProductId) return;

            var productToUpdate = _products.FirstOrDefault(x => x.ProductId == productId);
            if (productToUpdate != null)
            {
                productToUpdate.ProductName = product.ProductName;
                productToUpdate.Price = product.Price;
                productToUpdate.CategoryName = product.CategoryName;
                productToUpdate.ImageUrl = product.ImageUrl;
            }
            SaveProductsToCsv();
        }

        public static void DeleteProduct(int productId)
        {
            var product = _products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                _products.Remove(product);
            }
            SaveProductsToCsv();
        }

        public static List<Product> GetProductByCategoryId(string category)
        {
            return _products.Where(x => x.CategoryName.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static List<Product> LoadProductsFromCsv()
        {
            //var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "products.csv");

            //if (!File.Exists(path))
            //    return new List<Product>();

            //using var reader = new StreamReader(path);
            //using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
            //return csv.GetRecords<Product>().ToList();
             return  File.ReadAllLines("D:\\MVCCourse2\\MVCCourse2\\Data\\Products.csv")
            .Skip(1)
            .Select(line => line.Split(','))
            .Select(parts => new Product
            {
                ProductId = int.Parse(parts[0]),
                // Username is the second column
                ProductName = parts[1],
                CategoryName=parts[2],
                Price=int.Parse(parts[3]),
                ImageUrl=parts[4],
                // Password is the third column
            })
            .ToList();
        }

        private static void SaveProductsToCsv()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "products.csv");

            using var writer = new StreamWriter(path);
            using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture));
            csv.WriteRecords(_products);
        }
        public static List<PurchaseHistory> GetHistory(bool loadCategory = false)
        {
            return _history ?? new List<PurchaseHistory>();
            //return _products;
        }
    }
}
