using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace AppConfigurationFunction
{
    /// <summary>
    /// The AppConfigurationWithDependencyInjection class.
    /// </summary>
    public class AppConfigurationWithDependencyInjection
    {
        /// <summary>
        /// The configuration attribut.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// The c'tor creating the AppConfiguration injected by startup.
        /// </summary>
        /// <param name="configuration"></param>
        public AppConfigurationWithDependencyInjection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// The AppConfigurationWithDependencyInjection azure function.
        /// </summary>
        /// <param name="req">The incoming http request.</param>
        /// <param name="log">The log.</param>
        /// <returns>An IActionResult.</returns>
        [FunctionName("AppConfigurationWithDependencyInjection")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string initialValue = "1234567890";

            Console.WriteLine($"Starting configuration update with initialValue: {initialValue}");
            initialValue = _configuration["ConnectionStringCosmosDb"];
            Console.WriteLine($"Updated Value is: {initialValue}");

            return new OkObjectResult("Updated Value is: " + initialValue);
        }
    }
}
