using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MyMangoDbAjaxProject.Dal.Entities
{
    public class MainHome
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MainHomeID { get; set; }
        public string NameSurname { get; set; }
        public string Unvan { get; set; }
        public string ImageUrl { get; set; }
    }
}
