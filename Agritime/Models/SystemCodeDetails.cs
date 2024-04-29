using System.ComponentModel.DataAnnotations;

namespace Agritime.Models
{
    public class SystemCodeDetails:UserActivitycs
    {
        [Key]

        public int Id { get; set; }

        public int SystemCodeID { get; set; }

        public SystemCode SystemCode { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string OrderNo { get; set; }
    }
}
