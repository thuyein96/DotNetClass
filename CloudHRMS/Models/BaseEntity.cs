using System.ComponentModel.DataAnnotations;

namespace CloudHRMS.Models
{
    public class BaseEntity
    {
        [Key]
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; }
        public string IpAddress { get; set; }
        public bool IsInActive { get; set; }
    }
}
