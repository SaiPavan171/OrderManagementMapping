using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Models.DTO
{
    public class OrderCreateDto
    {
        [Required, EmailAddress]
        public string? CustomerEmail { get; set; }
        [Required]
        public int[]? ProductIds { get; set; }
    }
}
