﻿using MicroserviceECommerce.Entities;
using MicroserviceECommerce.MVCUI.HttpHelpers;

using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroserviceECommerce.MVCUI.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(Entities.Models.)
        {
            //Customer customer = HttpHelperMethods.Login<Customer>("http://localhost:37786/", "api/Customer/LoginUser", Method.GET, model.Customer,model.Password);
            //return View(customer);
         

            //if (ModelState.IsValid)
            //{
               
            //    return RedirectToAction("GetAllCustomers");
                

            //    if (customer == null)
            //    {
            //        ModelState.AddModelError("", "Böyle Bir Kullanıcı Yok");


            //        ViewBag.Result = "Mail Adresi Kayıtlı Değil.";
            //        ViewBag.Status = "danger";
            //        return View();
            //    }
            //    else
            //    {
            //        Session["Customer"] = customer;
            //        return RedirectToAction("homepage", "Home");
            //    }
            }


            return null;
        }
    }
}