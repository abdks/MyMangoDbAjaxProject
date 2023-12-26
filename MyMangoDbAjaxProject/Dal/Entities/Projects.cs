using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Microsoft.CodeAnalysis;

namespace MyMangoDbAjaxProject.Dal.Entities
{
	public class Projects
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string ProjectsID { get; set; }
		public string ImageUrl { get; set; }
	}
}
