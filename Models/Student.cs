using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudentManagement.Models;

public class Student
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id  { get; set; }
    
    [BsonElement("name")]
    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; } = string.Empty;
    
    [BsonElement("email")]
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email is invalid")]
    public string? Email { get; set; } = string.Empty;
    
    [BsonElement("department_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    [Required(ErrorMessage = "Department is required")]
    public string DepartmentId { get; set; } = string.Empty;
}