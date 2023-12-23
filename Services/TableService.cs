using Microsoft.Azure.Cosmos;
using MvcAppCosmosDb.Models;
using MvcAppCosmosDb.Services.Interfaces;

namespace MvcAppCosmosDb.Services
{
    public class TableService : ITableService
    {
        private readonly CosmosClient _cosmosClient;
        private readonly string _databaseName;

        public TableService(CosmosDbSettings cosmosDbSettings)
        {
            _cosmosClient = new CosmosClient(cosmosDbSettings.Endpoint, cosmosDbSettings.Key);
            _databaseName = cosmosDbSettings.DatabaseName;
        }

        public async Task GetAllEmployees()
        {
            Database database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(_databaseName);
            Container container = database.GetContainer("employees");
            var query = container.GetItemQueryIterator<Employees>("SELECT * FROM employees");

            // Query for all items in the container
            //var query = new QueryDefinition("SELECT * FROM employees");
        }
    }
}
