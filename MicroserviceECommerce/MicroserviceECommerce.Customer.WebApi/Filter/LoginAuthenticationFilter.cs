using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace LoginAuthenticationFilter
{
    public class MyAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {

            var token = filterContext.HttpContext.Request.Headers.GetValues("TOKEN").FirstOrDefault();
            if (token==null)
            {
                throw new Exception("Login Olunuz");

            }

            //var customer = GetCustomersFromToken(token);
            //if (customer==null)
            //{
            //    throw new Exception("Login Olunuz");

            //}
            //if (filterContext.HttpContext.Session["Employee"] == null)
            //{
            //    filterContext.Result = new RedirectResult("~/Home/Hata");
            //}
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
        }
    }
}