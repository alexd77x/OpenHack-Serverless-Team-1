using System;
using Newtonsoft.Json;

namespace BFYOC.Function.Data
{
    public sealed class UserRating{
        [JsonProperty(PropertyName="id")]
        public Guid Id { get; set; }
        [JsonProperty(PropertyName="userId")]
        public Guid UserId { get; set; }
        [JsonProperty(PropertyName="productId")]
        public Guid ProductId { get; set; }
        [JsonProperty(PropertyName="timestamp")]
        public DateTime Timestamp { get; set; }
        [JsonProperty(PropertyName="locationName")]
        public string LocationName { get; set; }
        [JsonProperty(PropertyName="rating")]
        public int Rating { get; set; }      
        [JsonProperty(PropertyName="userNotes")]
        public string UserNotes { get; set; }
    }
}