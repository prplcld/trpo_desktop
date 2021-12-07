using Newtonsoft.Json;

namespace DatabaseApp
{
    class Tokens 
    {
        public Tokens(string accessToken, string refreshToken)
        {
            access_token = accessToken;
            refresh_token = refreshToken;
        }
        [JsonProperty(PropertyName = "access-token")]
        public string access_token { get; set; }
        [JsonProperty(PropertyName = "refresh-token")]
        public string refresh_token { get; set; }
    }
}