using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyCompany_BackEnd.Models
{

    [Table("Departments")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("PK_Department")]
        public int PK_Department { get; set; }
        [JsonPropertyName("DepartmentName")]
        public string? DepartmentName { get; set; }
        [JsonPropertyName("Active")]
        public bool Active { get; set; }

    }
}
