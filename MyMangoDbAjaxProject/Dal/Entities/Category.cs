using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MyMangoDbAjaxProject.Dal.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
