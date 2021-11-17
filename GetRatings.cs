using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using BFYOC.Function.Data;
using BFYOC.Function.Managers;

namespace BFYOC.Function
{
    public static class GetRatings
    {
        private static RatingManager ratingManager = new RatingManager();
        private static UserManager userManager = new UserManager();

        [FunctionName("GetRatings")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string userId = req.Query["userId"];

            if(string.IsNullOrEmpty(userId))
                return new BadRequestResult();

            var user = userManager.GetUser(userId);
            if(user == null)
            {
                return new NotFoundObjectResult(userId);
            }


            List<UserRating> ratings = await ratingManager.GetRatingForUser(userId);

            return new OkObjectResult(ratings);
        }
    }
}
