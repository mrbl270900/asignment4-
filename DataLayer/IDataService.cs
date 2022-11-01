using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IDataService
    {
        List<Category> GetCategories();
        Category? GetCategory(int id);
        Product? GetProduct(int id);
        List<Product> GetProducts();
        Category CreateCategory(Category input);

        List<Product> GetProductByCategory(int id);

        Category CreateCategory(string name, string description);

        bool UpdateCategory(int id, string name, string desc);
        bool DeleteCategory(int id);


        List<Product> GetProductByName(string input);
    }
}
