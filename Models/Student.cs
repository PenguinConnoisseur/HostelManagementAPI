using System;
using System.ComponentModel.DataAnnotations;

namespace HostelManagementAPI.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }

        public int DormID { get; set; }


    }
}
