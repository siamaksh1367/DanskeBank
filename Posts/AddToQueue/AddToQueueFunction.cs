using System;
using Project.core.Services.ContentStorage;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AddToQueue
{
    public class AddToQueueFunction
    {
        private readonly ILogger _logger;
        private readonly IContentStorage _contentStorage;

        public AddToQueueFunction(ILoggerFactory loggerFactory, IContentStorage contentStorage)
        {
            _logger = loggerFactory.CreateLogger<AddToQueueFunction>();
            _contentStorage = contentStorage;
        }

        [Function("AddToQueueFunction")]
        public async Task RunAsync([TimerTrigger("*/10 * * * * *")] TimerInfo myTimer)
        {
            await _contentStorage.AddMessageToQueuessync(string.Format("I ask you to work together at {0} ", DateTime.Now));
        }
    }
}
