using System.ComponentModel.DataAnnotations;

namespace MiniProject2_OnlineFoodOrderingSystemWebAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "CustomerId is required")]
        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        [Range(0.00, double.MaxValue, ErrorMessage = "TotalPrice must be a positive value")]
        public double TotalPrice { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [RegularExpression("Processed|Delivered|Canceled", ErrorMessage = "Status must be 'Processed', 'Delivered', or 'Canceled'")]
        public string Status { get; set; } = "Processed";

        [StringLength(500, ErrorMessage = "Note can't be longer than 500 characters")]
        public string Note { get; set; } = "-";


        public List<Menu> OrderedItems { get; set; } = new List<Menu>();

        public double CalculateTotalOrder()
        {
            return OrderedItems.Sum(menu => menu.Price);
        }
    }

}
