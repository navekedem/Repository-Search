using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    interface IAppManager
    {
        List<RepositoryModel> repositoryModels { get; set; }
        List<RepositoryModel> MyBookmarks { get; set; }
        void AddBookmark(int repositoryId);
        Task<bool> GetRepositoryModelsByName(string name);
        RepositoryModel GetRepository(int id);
    }
}
