using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using ZstdSharp.Unsafe;

namespace MyMangoDbAjaxProject.Dal.Entities
{
	public class Education
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string EducationID { get; set; }
		public string Title { get; set; }
		public string Date { get; set; }
		public string Place { get; set; }
	}
}
