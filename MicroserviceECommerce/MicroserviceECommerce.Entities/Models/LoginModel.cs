using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MicroserviceECommerce.MVCUI.Models
{
    public class LoginModel
    {
        [Required]
        public string CustomerID { get; set; }
        [Required]
        public string Password { get; set; }
    }
}