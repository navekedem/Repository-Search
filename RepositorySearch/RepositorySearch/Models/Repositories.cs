using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositorySearch.Models
{
    public class Repositories
    {
        [JsonProperty("items")]
        public List<RepositoryModel> repositories { get; set; }
    }
}