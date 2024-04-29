using System.ComponentModel.DataAnnotations;

namespace Agritime.Models
{
    public class SystemCode:UserActivitycs
    {
        [Key]
        public int Id { get; set; }

        public string Code { get; set; }

        public  string  Description { get; set; }
    }
}
