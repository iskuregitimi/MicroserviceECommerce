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
        public ActionResult CartView()
        {
            return View();
        }
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
                int productid = ProductExist(id);
                if (productid != 0)
                {
                    cart[productid].Quantity++;
                }
                else
                {
                    cart.Add(new ItemonCartModel { Product = HTTPHelpers.GetMethod<ProductsModel>("http://localhost:37796/", "Products/GetProductDetail", RestSharp.Method.GET, id), Quantity = 1 });
                }
                Session["Cart"] = cart;
            }
            return RedirectToAction("CartView");
        }

        public ActionResult DeleteShopCart(int id)
        {
            List<ItemonCartModel> cart = (List<ItemonCartModel>)Session["Cart"];
            int productid = ProductExist(id);
            cart.RemoveAt(productid);
            Session["Cart"] = cart;
            return RedirectToAction("CartView");
        }

        private int ProductExist(int id)
        {
            List<ItemonCartModel> cart = (List<ItemonCartModel>)Session["Cart"];
            foreach (var item in cart)
            {
                if (item.Product.ProductID == id)
                    return item.Product.ProductID;
            }
            return 0;

        }
    }
}