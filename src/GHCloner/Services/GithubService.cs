using GHClonerCLI.Entities;
using GHClonerCLI.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GHClonerCLI.Services;

public class GithubService : IGithubService
{
    private const string _userAgent = @"Mozilla/5.0 (Windows NT 10; Win64; x64; rv:60.0) Gecko/20100101 Firefox/60.0";

    public async Task<IList<Repository>> GetRepositoriesAsync(string githubToken, int repositoriesPage)
    {
        var url = BuildApiUrl(repositoriesPage);

        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", _userAgent);

        var request = new HttpRequestMessage();

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", githubToken);
        request.RequestUri = new Uri(url);
        request.Method = HttpMethod.Get;

        var response = await client.SendAsync(request);
        var responseContent = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<IList<Repository>>(responseContent);
    }

    private string BuildApiUrl(int repositoriesPage)
        => $"https://api.github.com/user/repos?page={repositoriesPage}&per_page=100";
}

