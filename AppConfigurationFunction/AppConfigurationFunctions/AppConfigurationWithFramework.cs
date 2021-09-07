using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Azure.Data.AppConfiguration;

namespace AppConfigurationFunction
{
    /// <summary>
    /// The AppConfigurationWithFramework class.
    /// </summary>
    public static class AppConfigurationWithFramework
    {
        /// <summary>
        /// The AppConfigurationWithFramework azure function.
        /// </summary>
        /// <param name="req">The incoming http request.</param>
        /// <param name="log">The logger.</param>
        /// <returns>An IActionResult.</returns>
        [FunctionName("AppConfigurationWithFramework")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string initialValue = "1234567890";

            Console.WriteLine($"Starting ConfigurationClient with initialValue: {initialValue}");
            var connectionString = Environment.GetEnvironmentVariable("appConfigurationConnectionString");
            var client = new ConfigurationClient(connectionString);

            Console.WriteLine("Sending GET Request");
            var temp = client.GetConfigurationSetting("TestKey", "Testing");
            var temp2 = temp.Value;
            initialValue = temp2.Value;
            Console.WriteLine($"Updated Value is: {initialValue}");

            return new OkObjectResult("Updated Value is: " + initialValue);
        }
    }
}
