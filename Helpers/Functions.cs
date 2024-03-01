using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace StockJobsScheduler.Helpers
{
    public class Functions
    {
        public static void ProcessQueueMessage([QueueTrigger("sdkjobqueue")] string message, ILogger logger)
        {
            message = "Execute";
            logger.LogInformation(message);
        }
    }
}
