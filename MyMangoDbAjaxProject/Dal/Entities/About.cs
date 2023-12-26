using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace MyMangoDbAjaxProject.Dal.Entities
{
	public class About
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AboutID { get; set; }
        public string Title1 { get; set; }
        public string Description1 { get; set; }
        public string Title2 { get; set; }
		public string Description2 { get; set; }
		public string Title3 { get; set; }
		public string Description3 { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
    }
}
