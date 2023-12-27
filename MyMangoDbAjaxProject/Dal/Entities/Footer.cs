using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MyMangoDbAjaxProject.Dal.Entities
{
    public class Footer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FooterID { get; set; }
        public string Name { get; set; }
        public string Designer { get; set; }
    }
}
