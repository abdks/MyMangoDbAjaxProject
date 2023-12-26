using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MyMangoDbAjaxProject.Dal.Entities
{
    public class Stats
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string StatsID { get; set; }
        public string title { get; set; }
        public int Amount { get; set; }
    }
}
