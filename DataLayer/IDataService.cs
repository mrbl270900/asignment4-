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
        List<Product> GetProducts();
        Product? GetProduct(int id);
        Category CreateCategory(string name, string desc);
        Category CreateCategory(Category category);
        Category UpdateCategory(Category category);

        bool UpdateCategory(int id, string name, string desc);
        bool DeleteCategory(int id);

        List<ProductSearchModel> GetProductByName(string search);
    }
}
