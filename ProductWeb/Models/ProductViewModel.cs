using System.ComponentModel.DataAnnotations;
using ProductInfrastructure.Model;

namespace ProductWeb.Models
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        public string Producer { get; set; }

        [Required]
        public string Supplier { get; set; }

        [Required]
        public decimal Price { get; set; }

        public Category Category { get; set; }

        public string CategoryName { get; set; }
    }
}