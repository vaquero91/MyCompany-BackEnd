using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCompany_BackEnd.Models
{
    [Table("AllEmployees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PK_Employee { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public bool Active { get; set; }
        public int FK_Department { get; set; }
        //TODO: DTO - data transfer object, crear una version de employee y department
        // Automaper 

        [ForeignKey("FK_Department")]
        public virtual Department? department { get; set; }

        public Employee() { }

        public Employee(string FName, string LName, int FKDepartment)
        {
            this.LastName = LName;
            this.FirstName = FName;
            this.FK_Department = FKDepartment;
        }
    }
}
