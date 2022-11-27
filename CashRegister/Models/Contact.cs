
using System.ComponentModel.DataAnnotations;

namespace CashRegister.Models
{
    public class Contact
    {
        public int ID { get; set; }
        
        [Required] 
        public string Email { get; set; }
        
        [Required]
        public string Address { get; set; }
        public string? City { get; set; }
        
        [Required] 
        public string Phone { get; set; }
    }
}
