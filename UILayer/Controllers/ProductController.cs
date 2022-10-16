using BussinesLayer.Concrete;
using BussinesLayer.FluentValidation;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UILayer.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        ProductValidator validationRules = new ProductValidator();
        public IActionResult Index()
        {
          
            var products = productManager.TGetList();
            return View(products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            ValidationResult result = validationRules.Validate(product);
            if (result.IsValid)
            {
                productManager.TInsert(product);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var product = productManager.TGetById(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            ValidationResult result = validationRules.Validate(product);
            if (result.IsValid)
            {
                productManager.TUpdate(product);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }



        public IActionResult DeleteProduct(int id)
        {
            var product = productManager.TGetById(id);
            productManager.TDelete(product);
            return RedirectToAction("Index");
        }

    }
}
