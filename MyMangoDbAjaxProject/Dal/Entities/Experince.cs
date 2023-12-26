using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace MyMangoDbAjaxProject.Dal.Entities
{
	public class Experince
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string ExperinceID { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Place { get; set; }

    }
}
