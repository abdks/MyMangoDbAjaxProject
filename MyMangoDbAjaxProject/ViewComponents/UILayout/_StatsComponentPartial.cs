using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyMangoDbAjaxProject.Dal.Entities;
using MyMangoDbAjaxProject.Dal.Settings;

namespace MyMangoDbAjaxProject.ViewComponents.UILayout
{
    public class _StatsComponentPartial : ViewComponent
    {
        private readonly IMongoCollection<Stats> _statscollection;
        private readonly IMongoCollection<Education> _educationCollection;
        private readonly IMongoCollection<Experince> _experienceCollection;

        public _StatsComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);

            // İlgili koleksiyonları burada ayarlayın
            _statscollection = database.GetCollection<Stats>(_databaseSettings.StatsCollectionName);
            _educationCollection = database.GetCollection<Education>(_databaseSettings.EducationCollectionName);
            _experienceCollection = database.GetCollection<Experince>(_databaseSettings.ExperinceCollectionName);
        }
        public class StatsEducationExperienceViewModel
        {
            public List<Stats> Stats { get; set; }
            public List<Education> Education { get; set; }
            public List<Experince> Experince { get; set; }
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Stats koleksiyonundan veri çekmek için
            var statsValues = await _statscollection.Find(x => true).ToListAsync();

            // Education koleksiyonundan veri çekmek için
            var educationValues = await _educationCollection.Find(x => true).ToListAsync();

            // Experience koleksiyonundan veri çekmek için
            var experienceValues = await _experienceCollection.Find(x => true).ToListAsync();

            // Verileri StatsEducationExperienceViewModel içine yerleştir
            var viewModel = new StatsEducationExperienceViewModel
            {
                Stats = statsValues,
                Education = educationValues,
                Experince = experienceValues
            };

            return View(viewModel);
        }

    }
}
