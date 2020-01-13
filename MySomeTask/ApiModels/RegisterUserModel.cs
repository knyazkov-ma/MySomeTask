using Newtonsoft.Json;

namespace MySomeTask.ApiModels
{
  public class RegisterUserModel
  {
    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("password")]
    public string Password { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("province")]
    public string Province { get; set; }
  }
}
