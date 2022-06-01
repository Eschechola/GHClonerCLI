using GHClonerCLI.Services.Interfaces;
using System.Threading.Tasks;

namespace GHClonerCLI.Services;

public class ClonerService : ICloneService
{
    private readonly IGithubService _githubService;
    private readonly IGitService _gitService;

    public ClonerService()
    {
        _githubService = new GithubService();
        _gitService = new GitService();
    }

    public async Task<bool> StartClone(string githubToken, string folderToSave, int repositoriesPage)
    {
        var repositories = await _githubService.GetRepositoriesAsync(githubToken, repositoriesPage);
        _gitService.CloneRepositories(folderToSave, repositories);

        return true;
    }
}