using System.ComponentModel.DataAnnotations;

namespace MiniProject2_OnlineFoodOrderingSystemWebAPI.Models
{
    public class Customer
    {
        public int CustomerId {  get; set; }
        
        [Required(ErrorMessage ="Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage ="Name must be between 2 - 100 characters")]
        public string Name {  get; set; }

        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage ="Invalid email format")]
        public string Email {  get; set; }

        [Phone(ErrorMessage ="Invalid phone number format")]
        public string PhoneNumber {  get; set; }

        [StringLength(200, ErrorMessage ="Address can't be longer than 200 characters")]
        public string Address { get; set; }
        
        public DateTime RegistrationDate { get; set; }
    }
}
