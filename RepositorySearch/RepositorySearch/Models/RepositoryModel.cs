using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositorySearch.Models
{
    public class RepositoryModel
    {
        [JsonProperty("id")]
        internal int Id { get; set; }
        [JsonProperty("name")]
        public string RepositoryName { get; set; }
        [JsonProperty("owner")]
        public OwnerModel Owner { get; set; }
        internal bool IsBookmark { get; set; }

    }
}