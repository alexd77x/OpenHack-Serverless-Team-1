
using System;
using Newtonsoft.Json;

namespace BFYOC.Function.Data
{
    public sealed class User{
        [JsonProperty(PropertyName="userId")]
        public Guid UserId { get; set; }

        [JsonProperty(PropertyName="userName")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName="fullName")]
        public string FullName { get; set; }

    }
}