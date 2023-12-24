using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Table;
//using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Table;
using MvcAppCosmosDb.Models;
using MvcAppCosmosDb.Models.Data;
using MvcAppCosmosDb.Services;
using Newtonsoft.Json;

namespace MvcAppCosmosDb.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly CosmosClient _cosmosClient;

        public EmployeesController(ILogger<EmployeesController> logger, CosmosClient cosmosClient)
        {
            _logger = logger;
            _cosmosClient = cosmosClient;

        }


        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {

                #region getting data
                string connectionString = "DefaultEndpointsProtocol=https;AccountName=rohitpawar;AccountKey=WLjhe30V2efFBdYns9jTpUGaQXJ8ZTaGE8VCrPhMkdqstPAFGVnMHzYpQedephsAWMynm7D1F6rMACDboGKIAA==;TableEndpoint=https://rohitpawar.table.cosmos.azure.com:443/;";
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();








                #endregion



                List<Employees> emp = new List<Employees>();


                Employees employee = new Employees()
                {
                    empId = 007,
                    IsManager = true,
                    Name = "James Bond",
                    PartitionKey = Guid.NewGuid().ToString(),
                    RowKey = Guid.NewGuid().ToString(),
                    TimeStamp = DateTime.Now
                };

                emp.Add(employee);

                return new ObjectResult(new ResponseData
                {
                    Data = JsonConvert.SerializeObject(emp),
                    Message = "Success",
                    StatusCode = 200
                });
            }
            catch (Exception ex)
            {

                _logger.Log(Microsoft.Extensions.Logging.LogLevel.Error, "GetAllEmployees : " + ex.Message);
                return new ObjectResult(new ResponseData
                {
                    Data = "",
                    Message = "Failed , Internal Server Error",
                    StatusCode = 500
                });
            }
        }
    }
}
