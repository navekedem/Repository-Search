using Backend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Backend.BusinessLogic
{
    public class AppManager
    {
        public List<RepositoryModel> repositoryModels { get; set; }
        public List<RepositoryModel> MyBookmarks { get; set; }

        //singelton
        private static AppManager _Instance;
        public static AppManager Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AppManager();
                }
                return _Instance;
            }
        }

        //ctor
        private AppManager()
        {
            MyBookmarks = new List<RepositoryModel>();
            repositoryModels = new List<RepositoryModel>();
        }

        //get repository from api
        public async Task<bool> GetRepositoryModelsByName(string name)
        {
            if (name != null)
            {
                string url = "https://api.github.com/search/repositories?q=" + name;
                using (var server = new HttpClient())
                {
                    server.BaseAddress = new Uri(url);
                    server.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "text/html,application/json");
                    var response = server.GetAsync(url).Result;
                    Repositories repositories = new Repositories();
                    if (response.IsSuccessStatusCode)
                    {
                        var res = await response.Content.ReadAsStringAsync();
                        repositories = JsonConvert.DeserializeObject<Repositories>(res);
                        repositoryModels = repositories.repositories;
                      
                        return true;
                    }


                }
            }

            return false;
        }
        //add bookmark to list of the guest
        public void AddBookmark(int repositoryId)
        {
            var model = GetRepository(repositoryId);
            if (model != null)
            {
                model.IsBookmark = true;
                MyBookmarks.Add(model);

            }
            else return;
        }



        // get repository from all repositories list
        public RepositoryModel GetRepository(int id)
        {
            RepositoryModel model = new RepositoryModel();
            model = repositoryModels.Where(m => m.Id == id).FirstOrDefault();

            return model;
        }


    }
}

