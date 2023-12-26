using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Entities;
using MyMangoDbAjaxProject.Dal.Settings;

namespace MyMangoDbAjaxProject.Controllers
{
	public class ExperinceController : Controller
	{
		private readonly IMongoCollection<Experince> _Experincecollection;

		public ExperinceController(IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_Experincecollection = database.GetCollection<Experince>(_databaseSettings.ExperinceCollectionName);
		}
		public async Task<ActionResult> Index()
		{
			var values = await _Experincecollection.Find(x => true).ToListAsync();
			return View(values);
		}
		[HttpGet]
		public IActionResult CreateExperince()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateExperince(Experince Experince)
		{
			await _Experincecollection.InsertOneAsync(Experince);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> DeleteExperince(string id)
		{
			await _Experincecollection.DeleteManyAsync(x => x.ExperinceID == id);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> UpdateExperince(string id)
		{
			var values = await _Experincecollection.Find<Experince>(x => x.ExperinceID == id).FirstOrDefaultAsync();
			return View(values);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateExperince(Experince Experince)
		{
			await _Experincecollection.FindOneAndReplaceAsync(x => x.ExperinceID == Experince.ExperinceID, Experince);
			return RedirectToAction("Index");
		}
	}
}
