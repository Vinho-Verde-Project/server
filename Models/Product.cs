using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Desc { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public string Type { get; set; }

        public int StepId { get; set; }
        public Step Step { get; set; }

        public ICollection<StockProduct> StockProducts { get; } = new List<StockProduct>();

        public ICollection<ProductCategory> ProductCategories { get; } = new List<ProductCategory>();
    }
}