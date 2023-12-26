using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Entities;
using MyMangoDbAjaxProject.Dal.Settings;

namespace MyMangoDbAjaxProject.Controllers
{
	public class EducationController : Controller
	{
		private readonly IMongoCollection<Education> _Educationcollection;

		public EducationController(IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_Educationcollection = database.GetCollection<Education>(_databaseSettings.EducationCollectionName);
		}
		public async Task<ActionResult> Index()
		{
			var values = await _Educationcollection.Find(x => true).ToListAsync();
			return View(values);
		}
		[HttpGet]
		public IActionResult CreateEducation()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateEducation(Education Education)
		{
			await _Educationcollection.InsertOneAsync(Education);
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> DeleteEducation(string id)
		{
			await _Educationcollection.DeleteManyAsync(x => x.EducationID == id);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public async Task<IActionResult> UpdateEducation(string id)
		{
			var values = await _Educationcollection.Find<Education>(x => x.EducationID == id).FirstOrDefaultAsync();
			return View(values);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateEducation(Education Education)
		{
			await _Educationcollection.FindOneAndReplaceAsync(x => x.EducationID == Education.EducationID, Education);
			return RedirectToAction("Index");
		}
	}
}
