using RepositorySearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorySearch.InterFaces
{
    interface IAppManager
    {
        List<RepositoryModel> repositoryModels { get; set; }

        Task<bool> GetRepositoryModelsByName(string name);
       
    }
}
