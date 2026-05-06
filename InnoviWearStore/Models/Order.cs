using System.ComponentModel.DataAnnotations;

namespace InnoviWearStore.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Pending";

        [Required]
        [Range(0, 100000)]
        public decimal TotalAmount { get; set; }

        [StringLength(500)]
        public string? ShippingAddress { get; set; }

        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        // Increase the length to 50 characters to accommodate "Cash on Delivery"
        [StringLength(50)]
        public string? PaymentMethod { get; set; }

        // Navigation properties
        public virtual User? User { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}