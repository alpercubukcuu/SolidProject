﻿using BussinesLayer.Concrete;
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
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        CustomerValidator validationRules = new CustomerValidator();
        public IActionResult Index()
        {
          
            var products = customerManager.TGetList();
            return View(products);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            ValidationResult result = validationRules.Validate(customer);
            if (result.IsValid)
            {
                customerManager.TInsert(customer);
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
        public IActionResult UpdateCustomer(int id)
        {
            var customer = customerManager.TGetById(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            ValidationResult result = validationRules.Validate(customer);
            if (result.IsValid)
            {
                customerManager.TUpdate(customer);
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



        public IActionResult DeleteCustomer(int id)
        {
            var customer = customerManager.TGetById(id);
            customerManager.TDelete(customer);
            return RedirectToAction("Index");
        }

    }
}
