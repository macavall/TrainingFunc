using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Text.Json;

namespace httpFunc
{
    public class http1
    {
        private readonly ILogger _logger;
        private bool AlreadyFailed = false;

        public http1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<http1>();
        }

        [Function("http1")]
        public async Task<string> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation(req.Body.ToString());

            // Set response string variable to Empty
            string response = String.Empty;

            _logger.LogInformation("C# HTTP trigger function processed a request.");

            // Read the request body and parse it into a JSON object
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonDocument.Parse(requestBody);

            // Extract the 'name' property from the JSON object
            if (data.RootElement.TryGetProperty("name", out var nameElement))
            {
                var name = nameElement.GetString();
                // Now you can use the 'name' variable in your code
            }
            else
            {
                _logger.LogInformation("Name not found in the request body.");
            }

            return response;
        }

        public async Task ThrowException()
        {
            if (AlreadyFailed == false)
            {
                throw new System.Exception();
            }
        }
    }
}
