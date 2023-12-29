using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Entities;
using MyMangoDbAjaxProject.Dal.Settings;

namespace MyMangoDbAjaxProject.ViewComponents.UILayout
{
    public class _ServicesComponentPartial : ViewComponent
    {
        private readonly IMongoCollection<Services> ServicesCollectionName;

        public _ServicesComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            ServicesCollectionName = database.GetCollection<Services>(_databaseSettings.ServicesCollectionName);
        }

        // _MainPageComponentPartial.cs dosyanızdaki InvokeAsync metodu
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await ServicesCollectionName.Find(x => true).ToListAsync();
            return View(values);
        }
    }
}
