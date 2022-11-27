using System.ComponentModel.DataAnnotations;

namespace CashRegister.Models
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required]
        public string? CategoryName { get; set; }
        public string? Description { get; set; }

    }
}
