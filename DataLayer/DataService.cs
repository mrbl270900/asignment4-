using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace DataLayer
{
    public class DataService
    {

        public NorthwindContext db = new NorthwindContext();


        public IList<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            Category category = db.Categories.FirstOrDefault(x => x.Id == id);
            return category;
        }

        public Category CreateCategory(string name, string description)
        {
            var maxId = db.Categories.Max(x => x.Id);
            Category newCat = new Category()
            {
                Id = maxId + 1,
                Name = name,
                Description = description
            };
            db.Categories.Add(newCat);
            db.SaveChanges();
            return newCat;
        }

        public bool DeleteCategory(int id)
        {
            var dbCat = GetCategory(id);
            if (dbCat == null)
            {
                return false;
            }
            db.Categories.Remove(dbCat);
            db.SaveChanges();
            return true;
        }

        public bool UpdateCategory(int id, string name, string description)
        {
            var dbCat = GetCategory(id);
            if (dbCat == null)
            {
                return false;
            }
            dbCat.Name = name;
            dbCat.Description = description;
            db.SaveChanges();
            return true;
        }



        //produckt

        public Product GetProduct(int id)
        {
            Product product = db.Products.FirstOrDefault(x => x.Id == id);
            product.Category = GetCategory(product.CategoryId);
            product.CategoryName = product.Category.Name;
            return product;
        }

        public List<Product> GetProductByCategory(int id)
        {
            List<Product> list = new List<Product>();
            List<Category> categories = new List<Category>();
            foreach (var element in db.Categories)
            {
                categories.Add(element);
            }
            foreach (var element in db.Products)
            {
                if (element.CategoryId == id)
                {
                    element.Category = categories.FirstOrDefault(x => x.Id == element.CategoryId);
                    element.CategoryName = element.Category.Name;
                    list.Add(element);
                }
            }
            return list;
        }


        public List<Product> GetProductByName(string input)
        {
            List<Product> list = new List<Product>();
            foreach (Product element in db.Products)
            {
                element.ProductName = element.Name;
                if (element.Name.Contains(input)) { list.Add(element); }
            }

            return list;
        }


        //order
        public Order GetOrder(int id)
        {
            Order order = db.Orders.FirstOrDefault(x => x.Id == id);
            //var list = db.OrderDetails.FirstOrDefault(x => x.OrderId == id);
            //order.OrderDetails = list;
            return order;

        }

        public List<Order> GetOrders()
        {
            return db.Orders.ToList();

        }

        //order details

        public List<OrderDetails> GetOrderDetailsByOrderId(int id)
        {
            Order order = db.Orders.FirstOrDefault(x => x.Id == id);
            List<OrderDetails> list = new List<OrderDetails>();
            list = order.OrderDetails.ToList();
            return list;

        }

        public List<OrderDetails> GetOrderDetailsByProductId(int id)
        {
            return null;

        }
    }
}