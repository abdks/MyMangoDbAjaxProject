using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Entities;
using MyMangoDbAjaxProject.Dal.Settings;

namespace MyMangoDbAjaxProject.ViewComponents.UILayout
{
    public class _FooterComponentPartial : ViewComponent
    {
        private readonly IMongoCollection<Footer> _Footercollection;

        public _FooterComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _Footercollection = database.GetCollection<Footer>(_databaseSettings.FooterCollectionName);
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _Footercollection.Find(x => true).ToListAsync();
            return View(values);
        }
    }
}
