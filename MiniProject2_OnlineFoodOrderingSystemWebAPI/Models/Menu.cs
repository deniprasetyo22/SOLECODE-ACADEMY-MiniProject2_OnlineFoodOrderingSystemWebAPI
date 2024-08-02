using System.ComponentModel.DataAnnotations;

namespace MiniProject2_OnlineFoodOrderingSystemWebAPI.Models
{
    public class Menu
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage ="Name must be between 2 - 100 characters")]
        public string Name { get; set; }

        [Range(0.01, 100000, ErrorMessage ="Price must be between 0.01 - 100000")]
        public double Price {  get; set; }

        [RegularExpression("Food|Beverage|Dessert", ErrorMessage ="Category must be 'Food', 'Beverage', or 'Dessert'")]
        public string Category {  get; set; }

        [Range(0, 5, ErrorMessage ="Rating must be between 1 - 5")]
        public double Rating {  get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public bool IsAvailable {  get; set; } = true;

        private List<int> Ratings { get; set; } = new List<int>();

        public void AddRating(int rating)
        {
            Ratings.Add(rating);
            Rating = Ratings.Average();
        }

    }
}
