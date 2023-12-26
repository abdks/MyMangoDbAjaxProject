using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Entities;
using MyMangoDbAjaxProject.Dal.Settings;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using ZstdSharp.Unsafe;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace MyMangoDbAjaxProject.Controllers
{
    public class MainHomeController : Controller
    {
        private readonly IMongoCollection<MainHome> _mongoCollection;

        public MainHomeController(IDatabaseSettings databaseSettings)
        {
            if (databaseSettings == null)
            {
                throw new ArgumentNullException(nameof(databaseSettings));
            }

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _mongoCollection = database.GetCollection<MainHome>(databaseSettings.MainHomeCollectionName);
        }

        public async Task<ActionResult> Index()
        {
            var values = await _mongoCollection.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateMainHome()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMainHome(MainHome main)
        {
            await _mongoCollection.InsertOneAsync(main);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteMainHome(string id)
        {
            await _mongoCollection.DeleteManyAsync(x => x.MainHomeID == id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateMainHome(string id)
        {
            var values = await _mongoCollection.Find<MainHome>(x => x.MainHomeID == id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateMainHome(MainHome main)
        {
            await _mongoCollection.FindOneAndReplaceAsync(x => x.MainHomeID == main.MainHomeID, main);
            return RedirectToAction("Index");
        }

    }
}
