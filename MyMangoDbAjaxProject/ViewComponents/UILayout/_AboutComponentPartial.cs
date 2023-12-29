using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Entities;
using MyMangoDbAjaxProject.Dal.Settings;

namespace MyMangoDbAjaxProject.ViewComponents.UILayout
{
    public class _AboutComponentPartial : ViewComponent
    {
        private readonly IMongoCollection<About> _aboutcollection;

        public _AboutComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _aboutcollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName);
        }

        // _MainPageComponentPartial.cs dosyanızdaki InvokeAsync metodu
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutcollection.Find(x => true).ToListAsync();
            return View(values);
        }
       
    }
}
