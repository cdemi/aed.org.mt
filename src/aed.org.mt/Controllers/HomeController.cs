using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using aed.com.mt.Models;

namespace aed.org.mt.Controllers
{
    public class HomeController : Controller
    {
        private IConfigurationRoot configuration;
        public HomeController(IConfigurationRoot IConfigurationRoot)
        {
            this.configuration = IConfigurationRoot;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            var azureConnectionString = configuration.GetValue<string>("MicrosoftAzureStorage:aedmalta_AzureStorageConnectionString");
            var storageAccount = CloudStorageAccount.Parse(azureConnectionString);

            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference("AEDs");

            await table.CreateIfNotExistsAsync();

            var sampleAED = new AEDEntity("Test","Christopher Demicoli", "99570116", 12.5643, 12415.2112);

            await table.ExecuteAsync(TableOperation.Insert(sampleAED));

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
