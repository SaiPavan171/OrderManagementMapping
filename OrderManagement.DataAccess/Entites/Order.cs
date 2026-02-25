using System.ComponentModel.DataAnnotations;

namespace OrderManagement.DataAccess.Entites
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required,EmailAddress]
        public string? CustomerEmail { get; set; }
        [Required]
        public string? ProductIds { get; set; }
        public int TotalAmount { get; set; }
        [Required]
        public DateTime? CreatedAt { get; set; }
        [Required]
        public string? Status { get; set; }

    }
}
