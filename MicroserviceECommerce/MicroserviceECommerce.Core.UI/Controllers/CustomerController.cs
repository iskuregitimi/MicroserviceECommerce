using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroserviceECommerce.Core.UI.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace MicroserviceECommerce.Core.UI.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<CustomerModel> customerList = new List<CustomerModel>();
            customerList = HttpHelper.GetData<List<CustomerModel>>("http://localhost:37776/", "api/Customer/GetCustomers", Method.GET);
            return View(customerList);
        }

        [HttpGet]
        public IActionResult List()
        {
            List<Customers> customerList = new List<Customers>();
            customerList = HttpHelper.GetData<List<Customers>>("https://localhost:44376", "api/Customer/List", Method.GET);
            return View(customerList);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            CustomerModel customer = new CustomerModel();
            customer = HttpHelper.SendIdGetData<CustomerModel>("http://localhost:37776", "api/Customer/GetCustomer", Method.GET, id);
            return View(customer);
        }

        [HttpGet]
        public IActionResult InsertCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertCustomer(CustomerModel customer)
        {
            HttpHelper.SendData("http://localhost:37776", "api/Customer/InsertCustomer", Method.POST, customer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteCustomer(string id)
        {
            CustomerModel customer = new CustomerModel();
            customer = HttpHelper.SendIdGetData<CustomerModel>("http://localhost:37776", "api/Customer/GetCustomer", Method.GET, id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult DeleteCustomer(string id, string maydi) //maydi değişkeni sırf HttpGet ile çalışan DeleteCustomer actionından farklı olsun diye eklendi. aynı parametrelerle aynı isimde ikinci action açamıyosun.
        {
            HttpHelper.SendId("http://localhost:37776", "api/Customer/DeleteCustomer", Method.DELETE, id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCustomer(string id)
        {
            CustomerModel customer = new CustomerModel();
            customer = HttpHelper.SendIdGetData<CustomerModel>("http://localhost:37776", "api/Customer/GetCustomer", Method.GET, id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(CustomerModel customer)
        {
            HttpHelper.SendData("http://localhost:37776", "api/Customer/UpdateCustomer", Method.PUT, customer);
            return RedirectToAction("Index");//TODO: Aslında Customer/Details/ANTON adresine göndermek istedim olmadı. Garip ama api'ye model boş gidiyo onu yapmaya çalıştığımda.
        }
    }
}