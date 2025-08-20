using System;
using Azure.Storage.Queues.Models;
using Project.common;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ReadFromQueue
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;
        private readonly IOptions<StorageConnectionString> _options;

        public Function1(ILogger<Function1> logger,IOptions<StorageConnectionString> options)
        {
            _logger = logger;
            _options = options;
        }

        [Function(nameof(Function1))]
        public void Run([QueueTrigger(_options.Value.ConnectionString, Connection = "ddfasfdasdfsadfasdf")] QueueMessage message)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {message.MessageText}");
        }
    }
}
