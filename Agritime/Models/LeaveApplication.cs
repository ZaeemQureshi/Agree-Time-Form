namespace Agritime.Models
{
    public class LeaveApplication: ApprovalActivity
    {
        public int Id { get; set; }

        public int EmployeeId { get; set;}
        public Employees Employee { get; set; }

        public int NoOfDays { get; set; }

        public DateTime  StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int DurationId { get; set; }

        public SystemCodeDetails Duration { get; set; }

        public int LeaveTypeId { get; set; }

        public LeaveType LeaveType { get; set; }

        public string? Attachment { get; set; }

        public string? Description { get; set;  }

        public int? StatusId { get; set; }

        public SystemCodeDetails Status { get; set; }


    }
}
