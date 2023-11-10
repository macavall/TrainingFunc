using System;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace httpFunc
{
    public class queueTrigger
    {
        private readonly ILogger<queueTrigger> _logger;

        public queueTrigger(ILogger<queueTrigger> logger)
        {
            _logger = logger;
        }

        [Function(nameof(queueTrigger))]
        public void Run([QueueTrigger("myqueue-items", Connection = "")] QueueMessage message)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {message.MessageText}");
        }
    }
}
