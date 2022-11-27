using System.ComponentModel.DataAnnotations;

namespace CashRegister.Models
{
    public class User
    {
        public int Id { get; set; }
       
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Designation { get; set; }
        
        [Required]
        public Contact Contact { get; set; }

        public UserTypes UserType { get; set; }
    }


    public enum UserTypes
    {
        USER ,
        OPERATOR
    }
}
