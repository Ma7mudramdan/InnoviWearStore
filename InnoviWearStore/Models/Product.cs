using System.ComponentModel.DataAnnotations;

namespace InnoviWearStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0, 10000)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        [StringLength(200)]
        public string ImageUrl { get; set; } = string.Empty;

        [Range(0, 1000)]
        public int StockQuantity { get; set; }

        [StringLength(50)]
        public string? Size { get; set; }

        [StringLength(20)]
        public string? Color { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}