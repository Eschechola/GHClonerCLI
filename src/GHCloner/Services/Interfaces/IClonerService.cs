using System.Threading.Tasks;

namespace GHClonerCLI.Services.Interfaces;

public interface ICloneService
{
    Task<bool> StartClone(string githubToken, string folderToSave, int repositoriesPage);
}