using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MyMangoDbAjaxProject.Dal.Entities
{
    public class Messages
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MessagesID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
