namespace MyCompany_BackEnd.DTO
{
    public class UpdateEmployeeDTO
    {
        public int PK_Employee { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FK_Department { get; set; }
    }
}
