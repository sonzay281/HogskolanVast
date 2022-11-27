using System.ComponentModel.DataAnnotations;


namespace CashRegister.Models
{
    public class SaleItem
    {
        public int Id { get; set; }
       
        [Required]
        public int Quantity { get; set; }
        
        [Required] 
        public Inventory Inventory{ get; set; }

    }
}
