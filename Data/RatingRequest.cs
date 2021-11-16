using System;
using Newtonsoft.Json;

namespace BFYOC.Function.Data
{
    public sealed class RatingRequest{
        [JsonProperty(PropertyName="userId")]
        public Guid UserId { get; set; }
        [JsonProperty(PropertyName="productId")]
        public Guid ProductId { get; set; }
        [JsonProperty(PropertyName="locationName")]
        public string LocationName { get; set; }
        [JsonProperty(PropertyName="rating")]
        public int Rating { get; set; }      
        [JsonProperty(PropertyName="userNotes")]
        public string UserNotes { get; set; }
    }
}