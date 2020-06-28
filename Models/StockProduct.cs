using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("stock_product")]
    public class StockProduct
    {
        [Required]
        public int StockId { get; set; }

        [Required]
        public Stock Stock { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public Product Product { get; set; }

        [Required]
        public double MinQantity { get; set; }

        [Required]
        public double Quantity { get; set; }

        public int EmployeeId { get; set; }
        
        [Required]
        public Employee Employee { get; set; }
        
        public DateTime EntryDate { get; set; }

        [Required]
        public string Warehouse { get; set; }
    }   
}