using System.ComponentModel.DataAnnotations;


namespace CashRegister.Models
{
    public class Sale
    {
        public int Id { get; set; }
       
        [Required] 
        public List<SaleItem> Items{ get; set; }
        [Required]
        public DateTime SalesDateTime { get; set; }
        public double TotalAmount { get; set; }
        public double DiscountAmount { get; set; }


        [Required]
        public User Operator { get; set; }
        public User? User { get; set; }
    }
}
