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

        public string Title { get; set; }

        public ICollection<StockProduct> StockProducts { get; } = new List<StockProduct>();

        public ICollection<StockWine> StockWines { get; } = new List<StockWine>();
    }
}