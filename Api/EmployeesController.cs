using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcAppCosmosDb.Models;
using MvcAppCosmosDb.Models.Data;
using Newtonsoft.Json;

namespace MvcAppCosmosDb.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(ILogger<EmployeesController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
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

                _logger.Log(LogLevel.Error, "GetAllEmployees : " + ex.Message);
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
