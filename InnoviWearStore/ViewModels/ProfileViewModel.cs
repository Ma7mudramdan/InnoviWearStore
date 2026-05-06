using System.ComponentModel.DataAnnotations;

namespace InnoviWearStore.Models
{
    public class ProfileViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [StringLength(200)]
        [Display(Name = "Address")]
        public string? Address { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }
    }
}