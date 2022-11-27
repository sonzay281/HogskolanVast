using System.ComponentModel.DataAnnotations;

namespace CashRegister.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        [Required] 
        public Product Product{ get; set; }
        
        [Required] 
        public int Quantity { get; set; }
        
        [Required] 
        public DateTime ExpiryDate { get; set; }
        
        [Required] 
        public float Price { get; set; }
        public float Discount { get; set; } = 0;
    }
}
