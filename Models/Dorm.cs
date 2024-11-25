using System.ComponentModel.DataAnnotations;

namespace HostelManagementAPI.Models
{
    public class Dorm
    {
        [Key]
        public int DormID { get; set; }

        [Required]
        [MaxLength(100)]
        public string DormName { get; set; }

        public int Capacity { get; set; }

        public int OccupiedSlots { get; set; }

        [Required]
        [MaxLength(10)]
        public string GenderAllowed { get; set; }
    }
}
