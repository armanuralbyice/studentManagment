using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudentManagement.Models;

public class Department
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    [BsonElement("department_name")]
    [Required(ErrorMessage = "Department name is required")]
    public string Name { get; set; } = string.Empty;
    
    [BsonElement("department_code")]
    [Required(ErrorMessage = "Department code is required")]
    public string Code { get; set; } = string.Empty;
}