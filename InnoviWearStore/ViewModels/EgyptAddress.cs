using System.ComponentModel.DataAnnotations;

namespace InnoviWearStore.Models
{
    public class EgyptAddress
    {
        public string Governorate { get; set; } = string.Empty;
        public List<string> Cities { get; set; } = new List<string>();
        public List<string> Districts { get; set; } = new List<string>();
    }

    public class ShippingAddress
    {
        [Required]
        [Display(Name = "Governorate")]
        public string Governorate { get; set; } = string.Empty;

        [Required]
        [Display(Name = "City")]
        public string City { get; set; } = string.Empty;

        [Required]
        [Display(Name = "District/Area")]
        public string District { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Street Address")]
        [StringLength(200)]
        public string StreetAddress { get; set; } = string.Empty;

        [Display(Name = "Building Number")]
        public string? BuildingNumber { get; set; }

        [Display(Name = "Apartment Number")]
        public string? ApartmentNumber { get; set; }

        [Display(Name = "Landmark")]
        public string? Landmark { get; set; }

        [Display(Name = "Phone Number")]
        [Phone]
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        public string FullAddress => $"{StreetAddress}, {District}, {City}, {Governorate}";
    }
}