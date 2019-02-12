using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Repositories
    {
        [JsonProperty("items")]
        public List<RepositoryModel> repositories { get; set; }
    }
}
