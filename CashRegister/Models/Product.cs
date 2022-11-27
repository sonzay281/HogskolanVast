using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CashRegister.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required] 
        public string? Name { get; set; }
        public string? Description { get; set; }
        
        [Required] 
        public Category? Category{ get; set; }

    }
}
