using System.ComponentModel.DataAnnotations;

namespace InnoviWearStore.Models
{
    public class CheckoutViewModel
    {
        [Required]
        [Display(Name = "Governorate")]
        public string Governorate { get; set; } = string.Empty;

        [Required]
        [Display(Name = "City")]
        public string City { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Area / District")]
        public string District { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Street Address")]
        [StringLength(200)]
        public string StreetAddress { get; set; } = string.Empty;

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }

        public string FullAddress => $"{StreetAddress}, {District}, {City}, {Governorate}";
    }
}