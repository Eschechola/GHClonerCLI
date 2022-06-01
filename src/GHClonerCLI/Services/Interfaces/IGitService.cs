using GHClonerCLI.Entities;
using System.Collections.Generic;

namespace GHClonerCLI.Services.Interfaces;

public interface IGitService
{
    bool CloneRepositories(string path, IList<Repository> repositories);
}

