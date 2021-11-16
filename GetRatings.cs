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

        [FunctionName("GetRatings")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string userId = req.Query["userId"];

            //TODO Validate User Id

            //TODO add guards for null inputs

            List<UserRating> ratings = await ratingManager.GetRatingForUser(userId);

            return new OkObjectResult(ratings);
        }
    }
}
