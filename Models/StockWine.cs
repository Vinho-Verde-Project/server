using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("stock_wine")]
    public class StockWine
    {
        [Required]
        public int StockId { get; set; }

        [Required]        
        public Stock Stock { get; set; }

        [Required]
        public int WineId { get; set; }

        [Required]
        public Wine Wine { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required]
        public string Unit { get; set; }

        public int EmployeeId { get; set; }
        
        [Required]
        public Employee Employee { get; set; }
        
        public DateTime EntryDate { get; set; }
    }   
}