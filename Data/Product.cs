using System;
using Newtonsoft.Json;

namespace BFYOC.Function.Data
{
    public sealed class Product{
        [JsonProperty(PropertyName="productId")]
        public Guid ProductId { get; set; }

        [JsonProperty(PropertyName="productName")]
        public string ProductName { get; set; }

        [JsonProperty(PropertyName="productDescription")]
        public string ProductDescription { get; set; }

    }
}