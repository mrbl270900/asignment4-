using AutoMapper;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataLayer.Model;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private IDataService _dataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        public ProductsController(IDataService dataService, LinkGenerator generator, IMapper mapper)
        {
            _dataService = dataService;
            _generator = generator;
            _mapper = mapper;
        }

        [HttpGet("name/{search}")]
        public IActionResult GetProducts(string? search = null)
        {
            if (string.IsNullOrEmpty(search))
            {
                var products =
                    _dataService.GetProducts().Select(x => CreateProductListModel(x));
                return Ok(products);
            }

            var data = _dataService.GetProductByName(search);
            foreach (var product in data)
            {
                return Ok(data);

            }

            return NotFound(data);
        }


        [HttpGet("{id}", Name = nameof(GetProduct))]
        public IActionResult GetProduct(int id)
        {
            var product = _dataService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            var model = CreateProductModel(product);

            return Ok(model);

        }


        [HttpGet("category/{id}", Name = nameof(getProductsByCategory))]
        public IActionResult getProductsByCategory(int id)
        {

            var products = _dataService.GetProductByCategory(id);
            // prolly needs some mapping
            foreach (var product in products)
            {
                return Ok(products);
            }



            return NotFound(products);

        }





        private ProductListModel CreateProductListModel(Product product)
        {
            var model = _mapper.Map<ProductListModel>(product);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetProduct), new { product.Id });
            return model;
        }

        private ProductModel CreateProductModel(Product product)
        {
            var model = _mapper.Map<ProductModel>(product);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetProduct), new { product.Id });
            model.Category.Url = _generator.GetUriByName(HttpContext, nameof(CategoriesController.GetCategory), new { product.Category.Id });
            return model;
        }
    }
}