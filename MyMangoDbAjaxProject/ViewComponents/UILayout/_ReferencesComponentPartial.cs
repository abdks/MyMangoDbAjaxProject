using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Entities;
using MyMangoDbAjaxProject.Dal.Settings;

namespace MyMangoDbAjaxProject.ViewComponents.UILayout
{
    public class _ReferencesComponentPartial : ViewComponent
    {
        private readonly IMongoCollection<References> _Referencescollection;

        public _ReferencesComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _Referencescollection = database.GetCollection<References>(_databaseSettings.ReferencesCollectionName);
        }

        // _MainPageComponentPartial.cs dosyanızdaki InvokeAsync metodu
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _Referencescollection.Find(x => true).ToListAsync();
            return View(values);
        }

    }
}
