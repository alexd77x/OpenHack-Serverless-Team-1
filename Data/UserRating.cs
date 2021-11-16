using System;
using Newtonsoft.Json;

namespace BFYOC.Function.Data
{
    public sealed class UserRating{
        [JsonProperty(PropertyName="id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName="userId")]
        public string UserId { get; set; }
        [JsonProperty(PropertyName="productId")]
        public string ProductId { get; set; }
        [JsonProperty(PropertyName="timestamp")]
        public string Timestamp { get; set; }
        [JsonProperty(PropertyName="locationName")]
        public string LocationName { get; set; }
        [JsonProperty(PropertyName="rating")]
        public int Rating { get; set; }      
        [JsonProperty(PropertyName="userNotes")]
        public string UserNotes { get; set; }
    }
}