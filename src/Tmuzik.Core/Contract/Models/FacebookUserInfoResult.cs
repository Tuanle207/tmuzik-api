using System;
using System.Text.Json.Serialization;

namespace Tmuzik.Core.Contract.Models
{
    public class FacebookUserInfoResult
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("picture")]
        public FacebookPicture Picture { get; set; }
    }

    public class FacebookPicture
    {
        [JsonPropertyName("data")]
        public FacebookPictureData Data { get; set; }
    }

    public class FacebookPictureData
    {
        [JsonPropertyName("height")]
        public long Height { get; set; }

        [JsonPropertyName("is_silhouette")]
        public bool IsSilhouette { get; set; }

        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        [JsonPropertyName("width")]
        public long Width { get; set; }
    }
}