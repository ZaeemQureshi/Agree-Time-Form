namespace Agritime.Models
{
    public class Employees : UserActivitycs
    {
        public int ID { get; set; }

        public  string EmpNo { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FullName => $" {FirstName} {MiddleName} {LastName}";

        public int Phone { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Shift { get; set; }

        public string Designation { get; set; }

        public string Department { get; set; }

    }
}
