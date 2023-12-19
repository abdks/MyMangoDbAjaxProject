using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Entities;
using MyMangoDbAjaxProject.Dal.Settings;
using Newtonsoft.Json;
using ZstdSharp.Unsafe;

namespace MyMangoDbAjaxProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMongoCollection<Employee> _employeeCollection;

        public EmployeeController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _employeeCollection = database.GetCollection<Employee>(_databaseSettings.EmployeeCollectionName);
        }

        public IActionResult Index()
        {
            return View();
        }
     
        public async Task<IActionResult> EmployeeList()
        {
            var values = await _employeeCollection.Find(x => true).ToListAsync();
            var jsonEmployee = JsonConvert.SerializeObject(values);
            return Json(jsonEmployee);
        }
        [HttpPost]
        public async Task<IActionResult>CreateEmployee(Employee employee)
        {
            await _employeeCollection.InsertOneAsync(employee);
            var values = JsonConvert.SerializeObject(employee);
            return Json(values);
        }
        public async Task<IActionResult> GetEmployee(string EmployeeId)
        {
            var values = await _employeeCollection.Find(x => x.EmployeID == EmployeeId).FirstOrDefaultAsync();
            var jsonvalues = JsonConvert.SerializeObject(values);
            return Json(jsonvalues);

        }
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            await _employeeCollection.DeleteOneAsync(x => x.EmployeID == id);
            return NoContent();
        }
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            var values = await _employeeCollection.FindOneAndReplaceAsync(x => x.EmployeID == employee.EmployeID, employee);
            return NoContent();
        }
    }
}


