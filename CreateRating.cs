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

namespace BFYOC.Function
{
    public static class CreateRating
    {
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
            newRating.Id = Guid.NewGuid();
            newRating.Timestamp = DateTime.UtcNow;
            newRating.ProductId = request.ProductId;
            newRating.UserId = request.UserId;
            newRating.Rating = request.Rating;
            newRating.UserNotes = request.UserNotes;

            //TODO Create Rating element in Database            

            return new OkObjectResult(newRating);
        }
    }
}
