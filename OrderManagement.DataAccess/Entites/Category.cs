using System.ComponentModel.DataAnnotations;

namespace OrderManagement.DataAccess.Entites
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public List<Product>? Products { get; set; }
    }
}
