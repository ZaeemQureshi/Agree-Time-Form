namespace Agritime.Models
{
    public class UserActivitycs
    {
        public string? CreatedById { get; set; }

        public DateTime CreatedOn { get; set; }

        public string? ModifiedById { get; set; }

        public DateTime ModifiedOn { get; set; }

    }

    public class ApprovalActivity: UserActivitycs
    {
        public string? ApprovedById { get; set; }

        public DateTime ApprovedOn { get; set; }

    }
}
