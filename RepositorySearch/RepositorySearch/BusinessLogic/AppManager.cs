using Newtonsoft.Json;
using RepositorySearch.InterFaces;
using RepositorySearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace RepositorySearch.BusinessLogic
{
    public class AppManager : IAppManager
    {
        public List<RepositoryModel> repositoryModels { get; set; }

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


        private AppManager()
        {
            repositoryModels = new List<RepositoryModel>();
        }

        public async Task<bool> GetRepositoryModelsByName(string name)
        {
            string url = "https://api.github.com/search/repositories?q=" + name; 
            if (name != null)
            {
                using (var server = new HttpClient())
                {
                    server.BaseAddress = new Uri(url);
                    server.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "text/html,application/json");
                    var response = server.GetAsync(url).Result;
                    Repositories repositories = new Repositories();
                    if (response.IsSuccessStatusCode)
                    {
                        var res = response.Content.ReadAsStringAsync();
                        res.Wait();
                        repositories = JsonConvert.DeserializeObject<Repositories>(res.Result);
                        repositoryModels = repositories.repositories;
                        return true;
                    }
                       

                }
            }
           
            return false;   
        }

                
    }
}