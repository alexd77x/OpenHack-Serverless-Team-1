using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BFYOC.Function.Data;
using BFYOC.Function.Providers;

namespace BFYOC.Function.Managers
{
    public sealed class RatingManager {

        private static RatingCosmosProvider ratingProvider;

        public RatingManager()
        {
            ratingProvider = new RatingCosmosProvider();
        }
        public async Task<UserRating> AddRating(UserRating rating){
            return await ratingProvider.CreateRating(rating);
        }

        public async Task<UserRating> GetRating(string ratingId){
            return await ratingProvider.GetRatingById(ratingId);
        }

        public async Task<List<UserRating>> GetRatingForUser(string userId)
        {
            return await ratingProvider.GetRatingsByUser(userId);
        }
    }
}