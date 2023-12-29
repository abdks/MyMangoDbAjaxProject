namespace MyMangoDbAjaxProject.Dal.Settings
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string EmployeeCollectionName { get; set; }
        public string MainHomeCollectionName { get; set; }
        public string AboutCollectionName { get; set; }
        public string StatsCollectionName { get; set; }
        public string ExperinceCollectionName { get; set; }
        public string EducationCollectionName { get; set; }
        public string ServicesCollectionName { get; set; }
        public string ProjectsCollectionName { get; set; }
        public string ReferencesCollectionName { get; set; }
        public string ContactCollectionName { get; set; }
        public string FooterCollectionName { get; set; }
    }
}
