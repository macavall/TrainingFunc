using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace httpFunc
{
    public class http1
    {
        private readonly ILogger _logger;

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

            //Thread.Sleep(20000);

            // Try Catch Example for catching an Exception
            try
            {
                ThrowException();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.StackTrace);
                System.Console.WriteLine(ex.StackTrace);
            }

            return response;
        }

        public async Task ThrowException()
        {
            throw new System.Exception();
        }
    }
}
