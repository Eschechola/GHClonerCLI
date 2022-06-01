using GHClonerCLI.Entities;
using GHClonerCLI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace GHClonerCLI.Services;

public class GitService : IGitService
{
    public bool CloneRepositories(string path, IList<Repository> repositories)
    {
        using (var ps = PowerShell.Create())
        {
            foreach (var repository in repositories)
            {
                Console.WriteLine(repository.Id + " - Clonning: " + repository.Name);

                var pathToCloneProject = path + "//" + repository.Name;

                ps.AddScript("mkdir " + pathToCloneProject);
                ps.AddScript("git clone " + repository.CloneUrl + " " + pathToCloneProject);
                ps.Invoke();
            }
        }
        
        return true;
    }
}

