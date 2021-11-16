using System;
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
        public UserRating GetRating(Guid ratingId){
            return ratingProvider.GetRatingById(ratingId);
        }
    }
}