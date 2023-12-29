using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Entities;
using MyMangoDbAjaxProject.Dal.Settings;

namespace MyMangoDbAjaxProject.ViewComponents.UILayout
{
    public class _ContactComponentPartial : ViewComponent
    {
        private readonly IMongoCollection<Contact> _Contactcollection;

        public _ContactComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _Contactcollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
        }

        // _MainPageComponentPartial.cs dosyanızdaki InvokeAsync metodu
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _Contactcollection.Find(x => true).ToListAsync();
            return View(values);
        }
    }
}
