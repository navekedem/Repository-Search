using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class OwnerModel
    {
        [JsonProperty("avatar_url")]
        public string AvatarUrlPath { get; set; }
    }
}
