using System.ComponentModel.DataAnnotations;

namespace InnoviWearStore.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; } = 1;

        public DateTime AddedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual Product? Product { get; set; }
        public virtual User? User { get; set; }
    }
}