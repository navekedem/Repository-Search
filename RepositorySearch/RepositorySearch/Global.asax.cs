using Backend.BusinessLogic;
using Backend.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RepositorySearch
{
    public class MvcApplication : System.Web.HttpApplication
    {
        AppManager appManager = AppManager.Instance;
        protected void Application_Start()
        {
           
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        //add session to user
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            context.Session["Guest"] = appManager.MyBookmarks;
            
            
        }
    }
}
