using aed.com.mt;
using aed.com.mt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;

namespace aed.org.mt.Controllers
{
    public class HomeController : Controller
    {
        const string partitionKey = "Malta";
        CloudTable table;
        public HomeController(IConfigurationRoot configuration)
        {
            var azureConnectionString = configuration.GetValue<string>("MicrosoftAzureStorage:aedmalta_AzureStorageConnectionString");
            var storageAccount = CloudStorageAccount.Parse(azureConnectionString);

            var tableClient = storageAccount.CreateCloudTableClient();
            table = tableClient.GetTableReference("AEDs");
        }
        public async Task<IActionResult> Index()
        {
            var query = new TableQuery<AEDEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));
            var aeds = await table.ExecuteQueryAsync(query);
            return View();
        }

        public async Task<IActionResult> About()
        {
            var sampleAED = new AEDEntity(partitionKey, "Test", "Christopher Demicoli", "99570116", 12.5643, 12415.2112);

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
