using RepositorySearch.BusinessLogic;
using RepositorySearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepositorySearch.Controllers
{
    public class HomeController : Controller
    {
        AppManager appManager = AppManager.Instance;
        

        //home page index
        public ActionResult Index()
        {
            
            return View();
        }

        //get search name for repository
        [HttpGet]
        public ActionResult GetRepo(string name)
        {
            if (name == null)
            {
                RedirectToAction("Index");
            }
            else
            {
               bool Res = appManager.GetRepositoryModelsByName(name).Result;
                              
            }
            return View("Index");
        }


        public ActionResult DisplayReposList()
        {
          
            return PartialView("PartialReposList", appManager.repositoryModels);
        }
    }
}