using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class RepositoryModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string RepositoryName { get; set; }
        [JsonProperty("owner")]
        public OwnerModel Owner { get; set; }
        public bool IsBookmark { get; set; }
    }
}
