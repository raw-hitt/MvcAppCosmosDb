using System.Threading.Tasks;


namespace MvcAppCosmosDb.Services.Interfaces
{
    public interface ITableService
    {
        Task GetAllEmployees();
    }
}
