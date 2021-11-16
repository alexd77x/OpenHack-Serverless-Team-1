using System;

namespace BFYOC.Function.Data
{
    public sealed class UserRating{
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime Timestamp { get; set; }
        public string LocationName { get; set; }
        public int Rating { get; set; }      
        public string UserNotes { get; set; }
    }
}