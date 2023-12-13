using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyMangoDbAjaxProject.Dal.Entities
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EmployeID { get; set; }
        public string EmployeName { get; set; }
        public string EmployeSurname { get; set; }
        public decimal EmployeeSalary { get; set; }
    }
}
