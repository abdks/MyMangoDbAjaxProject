using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Entities;
using MyMangoDbAjaxProject.Dal.Settings;

namespace MyMangoDbAjaxProject.Controllers
{
    public class ReferencesController : Controller
    {
        private readonly IMongoCollection<References> _ReferencesCollection;

        public ReferencesController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ReferencesCollection = database.GetCollection<References>(_databaseSettings.ReferencesCollectionName);
        }
        public async Task<ActionResult> Index()
        {
            var values = await _ReferencesCollection.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateReferences()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateReferences(References References)
        {
            await _ReferencesCollection.InsertOneAsync(References);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteReferences(string id)
        {
            await _ReferencesCollection.DeleteManyAsync(x => x.ReferencesID == id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateReferences(string id)
        {
            var values = await _ReferencesCollection.Find<References>(x => x.ReferencesID == id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateReferences(References References)
        {
            await _ReferencesCollection.FindOneAndReplaceAsync(x => x.ReferencesID == References.ReferencesID, References);
            return RedirectToAction("Index");
        }
    }
}
