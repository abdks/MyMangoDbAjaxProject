using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Entities;
using MyMangoDbAjaxProject.Dal.Settings;

namespace MyMangoDbAjaxProject.Controllers
{
	public class AboutController : Controller
	{
		private readonly IMongoCollection<About> _aboutcollection;

		public AboutController(IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_aboutcollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName);
		}
		public async Task<ActionResult> Index()
		{
			var values = await _aboutcollection.Find(x => true).ToListAsync();
			return View(values);
		}
		[HttpGet]
		public IActionResult CreateAbout()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateAbout(About About)
		{
			await _aboutcollection.InsertOneAsync(About);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> DeleteAbout(string id)
		{
			await _aboutcollection.DeleteManyAsync(x => x.AboutID == id);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> UpdateAbout(string id)
		{
			var values = await _aboutcollection.Find<About>(x => x.AboutID == id).FirstOrDefaultAsync();
			return View(values);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateAbout(About About)
		{
			await _aboutcollection.FindOneAndReplaceAsync(x => x.AboutID == About.AboutID, About);
			return RedirectToAction("Index");
		}
	}
}
