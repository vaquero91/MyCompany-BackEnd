using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCompany_BackEnd.Models
{

    [Table("Departments")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PK_Department { get; set; }
        public string? DepartmentName { get; set; }
        public bool Active { get; set; }

    }
}
