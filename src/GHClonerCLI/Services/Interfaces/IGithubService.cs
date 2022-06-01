using GHClonerCLI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHClonerCLI.Services.Interfaces;

public interface IGithubService
{
    Task<IList<Repository>> GetRepositoriesAsync(string githubToken, int repositoriesPage);
}

