using System.Text.Json.Serialization;

namespace Tmuzik.Core.Contract.Models
{
    public partial class FacebookTokenValidationResult
    {
        [JsonPropertyName("data")]
        public FacebookTokenValidationResultData Data { get; set; }
    }

    public partial class FacebookTokenValidationResultData
    {
        [JsonPropertyName("app_id")]
        public string AppId { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("application")]
        public string Application { get; set; }

        [JsonPropertyName("data_access_expires_at")]
        public long DataAccessExpiresAt { get; set; }

        [JsonPropertyName("expires_at")]
        public long ExpiresAt { get; set; }

        [JsonPropertyName("is_valid")]
        public bool IsValid { get; set; }

        [JsonPropertyName("scopes")]
        public string[] Scopes { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }
}