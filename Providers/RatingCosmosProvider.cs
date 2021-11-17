using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BFYOC.Function.Data;
using MongoDB.Driver;

namespace BFYOC.Function.Providers
{
    public sealed class RatingCosmosProvider
    {
        private static MongoClient _client;

        public RatingCosmosProvider()
        {
            _client = new MongoClient(Environment.GetEnvironmentVariable("BFYOCConnStr"));
        }

        public async Task<UserRating> CreateRating(UserRating rating)
        {
            var db = _client.GetDatabase("admin");
            var collection = db.GetCollection<UserRating>("ratings");

            await collection.InsertOneAsync(rating);

            return rating;
        }
        
        public async Task<UserRating> GetRatingById(string ratingId)
        {   
            return await _client.GetDatabase("admin").GetCollection<UserRating>("ratings").Find(r => r.Id == ratingId).FirstOrDefaultAsync();
        }

        public async Task<List<UserRating>> GetRatingsByUser(string userId)
        {
            var db = _client.GetDatabase("admin");
            return await db.GetCollection<UserRating>("ratings").Find(r => r.UserId == userId).ToListAsync();
        }
    }
}