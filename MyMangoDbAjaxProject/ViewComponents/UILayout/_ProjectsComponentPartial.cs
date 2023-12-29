using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Entities;
using MyMangoDbAjaxProject.Dal.Settings;

namespace MyMangoDbAjaxProject.ViewComponents.UILayout
{
    public class _ProjectsComponentPartial : ViewComponent
    {
        private readonly IMongoCollection<Projects> ProjectsCollectionName;

        public _ProjectsComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            ProjectsCollectionName = database.GetCollection<Projects>(_databaseSettings.ProjectsCollectionName);
        }

        // _MainPageComponentPartial.cs dosyanızdaki InvokeAsync metodu
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await ProjectsCollectionName.Find(x => true).ToListAsync();
            return View(values);
        }
    }
}
