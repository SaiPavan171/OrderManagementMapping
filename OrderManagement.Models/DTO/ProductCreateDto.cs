using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.Models.DTO
{
    public class ProductCreateDto
    {
       
        [Required, MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Required]
        public int DiscountPercent { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public bool IsActive { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        
    }
}
