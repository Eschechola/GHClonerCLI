using Newtonsoft.Json;

namespace GHClonerCLI.Entities;

public class Repository
{
    [JsonProperty("Id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("clone_url")]
    public string CloneUrl { get; set; }

}