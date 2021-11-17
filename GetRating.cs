using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BFYOC.Function.Data;
using BFYOC.Function.Managers;

namespace BFYOC.Function
{
    public static class GetRating
    {
        private static RatingManager ratingManager = new RatingManager();

        [FunctionName("GetRating")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string ratingId = req.Query["ratingId"];

            //TODO add guards for null inputs
            
            UserRating rating = await ratingManager.GetRating(ratingId);

            return new OkObjectResult(rating);
        }
    }
}
