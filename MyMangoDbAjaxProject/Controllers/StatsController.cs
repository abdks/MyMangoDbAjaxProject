using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Entities;
using MyMangoDbAjaxProject.Dal.Settings;

namespace MyMangoDbAjaxProject.Controllers
{
    public class StatsController : Controller
    {
        private readonly IMongoCollection<Stats> _Statscollection;

        public StatsController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _Statscollection = database.GetCollection<Stats>(_databaseSettings.StatsCollectionName);
        }
        public async Task<ActionResult> Index()
        {
            var values = await _Statscollection.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateStats()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateStats(Stats Stats)
        {
            await _Statscollection.InsertOneAsync(Stats);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteStats(string id)
        {
            await _Statscollection.DeleteManyAsync(x => x.StatsID == id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateStats(string id)
        {
            var values = await _Statscollection.Find<Stats>(x => x.StatsID == id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStats(Stats Stats)
        {
            await _Statscollection.FindOneAndReplaceAsync(x => x.StatsID == Stats.StatsID, Stats);
            return RedirectToAction("Index");
        }
    }
}
