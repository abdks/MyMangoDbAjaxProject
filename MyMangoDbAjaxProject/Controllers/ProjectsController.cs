using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Entities;
using MyMangoDbAjaxProject.Dal.Settings;

namespace MyMangoDbAjaxProject.Controllers
{
	public class ProjectsController : Controller
	{

		private readonly IMongoCollection<Projects> _Projectscollection;

		public ProjectsController(IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_Projectscollection = database.GetCollection<Projects>(_databaseSettings.ProjectsCollectionName);
		}
		public async Task<ActionResult> Index()
		{
			var values = await _Projectscollection.Find(x => true).ToListAsync();
			return View(values);
		}
		[HttpGet]
		public IActionResult CreateProjects()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateProjects(Projects Projects)
		{
			await _Projectscollection.InsertOneAsync(Projects);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> DeleteProjects(string id)
		{
			await _Projectscollection.DeleteManyAsync(x => x.ProjectsID == id);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> UpdateProjects(string id)
		{
			var values = await _Projectscollection.Find<Projects>(x => x.ProjectsID == id).FirstOrDefaultAsync();
			return View(values);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateProjects(Projects Projects)
		{
			await _Projectscollection.FindOneAndReplaceAsync(x => x.ProjectsID == Projects.ProjectsID, Projects);
			return RedirectToAction("Index");
		}
	}
}
