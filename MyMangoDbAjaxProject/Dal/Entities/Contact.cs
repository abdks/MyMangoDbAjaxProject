using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace MyMangoDbAjaxProject.Dal.Entities
{
	public class Contact
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string ContactID { get; set; }
		public string Office { get; set; }
		public	string No {  get; set; }
		public	string Mail {  get; set; }
		public	string Instagram {  get; set; }
		public	string Linkedin {  get; set; }

	}
}
