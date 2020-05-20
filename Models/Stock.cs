using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("stock")]
    public class Stock
    {
        [Key]
        public int Id { get; set; }   

        [Required]
        public float Quantity { get; set; }

        [Required]
        public string Warehouse { get; set; }

        public int EmployeeId { get; set; }
        
        [Required]
        public Employee Employee { get; set; }
        
        public DateTime EntryDate { get; set; }

        public ICollection<StockProduct> StockProducts { get; } = new List<StockProduct>();

        public ICollection<StockWine> StockWines { get; } = new List<StockWine>();
    }
}