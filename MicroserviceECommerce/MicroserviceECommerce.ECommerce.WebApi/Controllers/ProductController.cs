using MicroserviceECommerce.ECommerce.WebApi.Models;
using MicroserviceECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MicroserviceECommerce.ECommerce.WebApi.Controllers
{
    public class ProductController:ApiController
    {
        DataContext db = new DataContext();
        [HttpGet]
        public List<ProductModel> Products()
        {
            List<ProductModel> productlist = db.Products.Select(x => new ProductModel
            {
                ProductID=x.ProductID,
                ProductName=x.ProductName,
                SupplierID=x.SupplierID,
                CategoryID=x.CategoryID,
                QuantityPerUnit=x.QuantityPerUnit,
                UnitPrice=x.UnitPrice,
                UnitsInStock=x.UnitsInStock,
                UnitsOnOrder=x.UnitsOnOrder,
                ReorderLevel=x.ReorderLevel,
                Discontinued=x.Discontinued
            }).ToList();
            return productlist;
        }
        [HttpGet]
        public ProductModel ProductDetail(int id)
        {
            ProductModel product = db.Products.Where(x => x.ProductID == id).Select(x => new ProductModel
            {
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                SupplierID = x.SupplierID,
                CategoryID = x.CategoryID,
                QuantityPerUnit = x.QuantityPerUnit,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                UnitsOnOrder = x.UnitsOnOrder,
                ReorderLevel = x.ReorderLevel,
                Discontinued = x.Discontinued
            }).FirstOrDefault();
            return product;
        }
    }
}