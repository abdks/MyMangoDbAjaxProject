using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Entities;
using MyMangoDbAjaxProject.Dal.Settings;

namespace MyMangoDbAjaxProject.ViewComponents.UILayout
{
    public class _MainPageComponentPartial : ViewComponent
    {
        private readonly IMongoCollection<MainHome> _MainHomecollection;

        public _MainPageComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _MainHomecollection = database.GetCollection<MainHome>(_databaseSettings.MainHomeCollectionName);
        }

        // _MainPageComponentPartial.cs dosyanızdaki InvokeAsync metodu
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _MainHomecollection.Find(x => true).ToListAsync();
            return View(values);
        }

    }
}
