using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace MyMangoDbAjaxProject.Dal.Entities
{
	public class References
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string ReferencesID { get; set; }
		public string NameSurname { get; set; }
		public string Description { get; set; }
		public string Unvan {  get; set; }

		public string Image { get; set; }
	}
}
