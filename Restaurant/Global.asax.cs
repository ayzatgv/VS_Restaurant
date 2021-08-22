using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace Restaurant
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }
        
        //protected void Application_AuthorizeRequest()
        //{
        //    var authcookie = Request.Cookies[FormsAuthentication.FormsCookieName];
        //    if (authcookie != null)
        //    {
        //        FormsAuthenticationTicket ticket = null;
        //        try
        //        {
        //            ticket = FormsAuthentication.Decrypt(authcookie.Value);
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //        if(ticket!=null)
        //        {
        //            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(ticket.Name), null);
        //            HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(ticket.Name), null);
        //        }
        //    }
        //}
       
    }
}
