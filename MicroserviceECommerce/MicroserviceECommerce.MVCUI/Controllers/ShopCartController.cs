using MicroserviceECommerce.MVCUI.Filters;
using MicroserviceECommerce.MVCUI.HTTPHelperMethpds;
using MicroserviceECommerce.MVCUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MicroserviceECommerce.MVCUI.Controllers
{
    public class ShopCartController : Controller
    {
        // GET: ShopCart
        [LoginFilter]
        public ActionResult CartView()
        {
            return View();
        }
        [LoginFilter]
        [HttpGet]
        public ActionResult AddShopCart(int id)
        {
            ProductsModel product = new ProductsModel();
            if (Session["Cart"] == null)
            {
                List<ItemonCartModel> cart = new List<ItemonCartModel>();
                cart.Add(new ItemonCartModel { Product = HTTPHelpers.GetMethod<ProductsModel>("http://localhost:37796/", "Products/GetProductDetail", RestSharp.Method.GET, id), Quantity = 1 });
                Session["Cart"] = cart;
            }
            else
            {
                List<ItemonCartModel> cart = (List<ItemonCartModel>)Session["Cart"];
                int index = cart.FindIndex(a => a.Product.ProductID == id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new ItemonCartModel { Product = HTTPHelpers.GetMethod<ProductsModel>("http://localhost:37796/", "Products/GetProductDetail", RestSharp.Method.GET, id), Quantity = 1 });
                }
                Session["Cart"] = cart;
            }
            return RedirectToAction("CartView");
        }
        [LoginFilter]
        public ActionResult DeleteShopCart(int id)
        {
            List<ItemonCartModel> cart = (List<ItemonCartModel>)Session["Cart"];
            int index = cart.FindIndex(a => a.Product.ProductID == id);
            cart.RemoveAt(index);
            Session["Cart"] = cart;
            return RedirectToAction("CartView");
        }

        //private int ProductExist(int id)
        //{
        //    List<ItemonCartModel> cart = (List<ItemonCartModel>)Session["Cart"];
        //    foreach (var item in cart)
        //    {
        //        if (item.Product.ProductID == id)
        //            return item.Product.ProductID;
        //    }
        //    return 0;

        //}
    }
}