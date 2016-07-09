using aed.org.mt;
using aed.org.mt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Linq;
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
            //This is how it should be, unfortunately there is a bug in this version of the Azure Storage SDK so we have to do it another way
            //var query = new TableQuery<AEDEntity>().Where($"PartitionKey eq '{partitionKey}' AND IsApproved eq true");
            //var aeds = await table.ExecuteQueryAsync(query);

            var query = new TableQuery<AEDEntity>().Where($"PartitionKey eq '{partitionKey}'");
            var aeds = (await table.ExecuteQueryAsync(query)).Where(a => a.IsApproved);

            return View(new HomeIndexModel
            {
                AEDs = aeds
            });
        }

        public async Task<IActionResult> About()
        {
            var sampleAED = new AEDEntity(partitionKey, "Test", "Christopher Demicoli", "99570116", 12.5643, 12415.2112, false);

            //await table.ExecuteAsync(TableOperation.Insert(sampleAED));

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
