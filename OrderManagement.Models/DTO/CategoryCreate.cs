using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Models.DTO
{
    public class CategoryCreate
    {
       
        [Required, MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        public bool IsActive { get; set; }

    }
}
