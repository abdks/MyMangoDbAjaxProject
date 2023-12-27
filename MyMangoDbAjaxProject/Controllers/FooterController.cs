using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Entities;
using MyMangoDbAjaxProject.Dal.Settings;
using Newtonsoft.Json;

namespace MyMangoDbAjaxProject.Controllers
{
    public class FooterController : Controller
    {
        private readonly IMongoCollection<Footer> _FooterCollection;

        public FooterController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _FooterCollection = database.GetCollection<Footer>(_databaseSettings.FooterCollectionName);
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> FooterList()
        {
            var values = await _FooterCollection.Find(x => true).ToListAsync();
            var jsonFooter = JsonConvert.SerializeObject(values);
            return Json(jsonFooter);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooter(Footer Footer)
        {
            await _FooterCollection.InsertOneAsync(Footer);
            var values = JsonConvert.SerializeObject(Footer);
            return Json(values);
        }
        public async Task<IActionResult> GetFooter(string FooterId)
        {
            var values = await _FooterCollection.Find(x => x.FooterID == FooterId).FirstOrDefaultAsync();
            var jsonvalues = JsonConvert.SerializeObject(values);
            return Json(jsonvalues);

        }
        public async Task<IActionResult> DeleteFooter(string id)
        {
            await _FooterCollection.DeleteOneAsync(x => x.FooterID == id);
            return NoContent();
        }
        public async Task<IActionResult> UpdateFooter(Footer Footer)
        {
            var values = await _FooterCollection.FindOneAndReplaceAsync(x => x.FooterID == Footer.FooterID, Footer);
            return NoContent();
        }

    }
}
