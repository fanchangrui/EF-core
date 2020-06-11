using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Stripe;


namespace TinyShop.Controllers
{
    public class ProductController : Controller
    {
        private ProductService _productService;

        public ProductController(DataContext context)
        {
            _productService = new ProductService((IStripeClient)context);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductDO product)
        {
            var productDo = new ProductDO
            {
                ProductNumber = product.ProductNumber,
                ProductName = product.ProductName,
                Price = product.Price
            };

            try
            {
                var insertedProduct = false;

                return Json(new
                {
                    code = "success",
                    data = insertedProduct
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    code = "fail",
                    message = ex.Message
                });
            }
        }
    }
}

