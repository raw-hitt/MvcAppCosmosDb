using MvcAppCosmosDb.Models.Base;

namespace MvcAppCosmosDb.Models
{
    public class Employees: BaseModel
    {

        public string Name { get; set; }
        public bool IsManager { get; set; }
        public int empId { get; set; }
    }
}
