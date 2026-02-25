using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.Models.DTO
{
    public class ProductPublicDto
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string? Name { get; set; }
        public decimal EffectivePrice { get; set; }
        [Required]
        public bool IsDiscounted { get; set; }
        [Required]
        public string? StockStatus { get; set; }

        [Required]
        public string? CategoryName { get; set; }

      
    }
}
