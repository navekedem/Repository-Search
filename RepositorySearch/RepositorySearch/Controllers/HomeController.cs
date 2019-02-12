
using Backend.BusinessLogic;

using Backend.Models;
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
        static List<RepositoryModel> repositories  = new List<RepositoryModel>();

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
                bool res = appManager.GetRepositoryModelsByName(name).Result;
                if (res)
                {
                    
                    repositories = appManager.repositoryModels;
                }
                              
            }
            return View("Index");
        }

        //dispaly all repositories from api 
        public ActionResult DisplayReposList()
        {
            
            return PartialView("PartialRepos",repositories);
        }

        [HttpGet]
        public ActionResult AddBookMark(int id)
        {
            appManager.AddBookmark(id);
            //Session["Guest"] = appManager.MyBookmarks;
            return View("Index");
        }

        //bookmark page
        public ActionResult BookmarksPage()
        {
            return View("Bookmarks");
           
        }
        //display bookmarks repostories from session 
        public ActionResult DisplayBookmarks()
        {
            var list = Session["Guest"] as List<RepositoryModel>;
            return PartialView("PartialBookmarks", list);
        }
    }
}