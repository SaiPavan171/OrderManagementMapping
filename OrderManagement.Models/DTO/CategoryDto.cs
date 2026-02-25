using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Models.DTO
{
    public class CategoryDto
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
