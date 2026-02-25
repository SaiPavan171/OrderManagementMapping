using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Models.DTO
{
    public class OrderDto
    {
        [Key]
        public int Id { get; set; }
        [Required, EmailAddress]
        public string? CustomerEmail { get; set; }
        public int ProductCount { get; set; }
       
        public int TotalAmount { get; set; }
        [Required]
        public DateTime? CreatedAt { get; set; }
        [Required]
        public string? Status { get; set; }
    }
}
