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
    public static class CreateRating
    {
        private static RatingManager ratingManager = new RatingManager();
        
        [FunctionName("CreateRating")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            RatingRequest request = JsonConvert.DeserializeObject<RatingRequest>(requestBody);

            //TODO Validate UserId Exists

            //TODO Validate ProductId Exists

            UserRating newRating = new UserRating();
            newRating.Id = Guid.NewGuid().ToString();
            newRating.Timestamp = DateTime.UtcNow.ToString();
            newRating.ProductId = request.ProductId;
            newRating.UserId = request.UserId;
            newRating.Rating = request.Rating;
            newRating.UserNotes = request.UserNotes;
            newRating.LocationName = request.LocationName;

            var createdRating = await ratingManager.AddRating(newRating);

            return new OkObjectResult(createdRating);
        }
    }
}
